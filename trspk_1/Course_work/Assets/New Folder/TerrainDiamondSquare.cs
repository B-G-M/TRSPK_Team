using UnityEngine;
using System.Collections;


public class TerrainDiamondSquare : ProcTerrain
{

	public float m_NoiseScale = 1;

	private float[] m_HeightValues;


	private int m_ValueSegmentCount;


	private Texture2D m_HeightTexture;


	private float m_MaxHeight = 0.0f;
	private float m_MinHeight = 0.0f;

	public override float GetY(float x, float z)
	{
		if (m_HeightTexture != null)
		{
			Color col = m_HeightTexture.GetPixelBilinear(x / m_Width, z / m_Width);
			return col.a * m_Height;
		}

		return 0.0f;
	}

	protected override void Start()
	{
		m_ValueSegmentCount = Mathf.NextPowerOfTwo(m_SegmentCount);

		m_HeightValues = new float[m_ValueSegmentCount * m_ValueSegmentCount];

		for (int i = 0; i < m_HeightValues.Length; i++)
		{
			m_HeightValues[i] = 0.0f;
		}

		int stepSize = Mathf.NextPowerOfTwo(Mathf.RoundToInt(m_NoiseScale * m_ValueSegmentCount));
		float scale = 1.0f;

		for (int y = 0; y < m_ValueSegmentCount; y += stepSize)
		{
			for (int x = 0; x < m_ValueSegmentCount; x += stepSize)
			{
				m_HeightValues[GetHeightIndex(x, y)] = Random.Range(-1.0f, 1.0f);
			}
		}

		while (stepSize > 1)
		{
			DiamondSquarePass(stepSize, scale);
			stepSize /= 2;
			scale *= 0.5f;
		}

		float scaleToNormalise = 1.0f / (m_MaxHeight - m_MinHeight);
		Color[] pixelValues = new Color[m_HeightValues.Length];
		m_HeightTexture = new Texture2D(m_ValueSegmentCount, m_ValueSegmentCount, TextureFormat.Alpha8, false, true);

		for (int i = 0; i < m_HeightValues.Length; i++)
		{
			float val = (m_HeightValues[i] - m_MinHeight) * scaleToNormalise;
			pixelValues[i] = new Color(val, val, val, val);
		}

		m_HeightTexture.SetPixels(pixelValues);
		m_HeightTexture.Apply();

		m_HeightValues = null;

		base.Start();
	}

	/// <summary>
	/// Performs a single diamond-square pass over the data grid.
	/// </summary>
	/// <param name="stepSize">The current grid size.</param>
	/// <param name="scale">The scale to apply to the random offset.</param>
	private void DiamondSquarePass(int stepSize, float scale)
	{
		int halfStep = stepSize / 2;

		for (int row = halfStep; row < m_ValueSegmentCount + halfStep; row += stepSize)
		{
			for (int col = halfStep; col < m_ValueSegmentCount + halfStep; col += stepSize)
			{
				SquareStep(col, row, halfStep, scale);
			}
		}

		for (int row = 0; row < m_ValueSegmentCount; row += stepSize)
		{
			for (int col = 0; col < m_ValueSegmentCount; col += stepSize)
			{
				DiamondStep(col + halfStep, row, halfStep, scale);
				DiamondStep(col, row + halfStep, halfStep, scale);
			}
		}
	}

	/// <summary>
	/// Calculates the height value of a point based on the surrounding points.
	/// </summary>
	/// <param name="col">The collumn within the values grid.</param>
	/// <param name="row">The row within the values grid.</param>
	/// <param name="stepSize">The size of the area to check.</param>
	/// <param name="heightScale">The scale to apply to the random offset.</param>
	private void SquareStep(int col, int row, int stepSize, float heightScale)
	{
		float height = 0.0f;

		height += m_HeightValues[GetHeightIndex(col - stepSize, row - stepSize)] * 0.25f;
		height += m_HeightValues[GetHeightIndex(col + stepSize, row - stepSize)] * 0.25f;
		height += m_HeightValues[GetHeightIndex(col - stepSize, row + stepSize)] * 0.25f;
		height += m_HeightValues[GetHeightIndex(col + stepSize, row + stepSize)] * 0.25f;

		float newValue = height + Random.Range(-1.0f, 1.0f) * heightScale;
		m_HeightValues[GetHeightIndex(col, row)] = newValue;

		m_MaxHeight = Mathf.Max(m_MaxHeight, newValue);
		m_MinHeight = Mathf.Min(m_MinHeight, newValue);
	}

	/// <summary>
	/// Calculates the height value of a point based on the surrounding points.
	/// </summary>
	/// <param name="col">The collumn within the values grid.</param>
	/// <param name="row">The row within the values grid.</param>
	/// <param name="stepSize">The size of the area to check.</param>
	/// <param name="heightScale">The scale to apply to the random offset.</param>
	private void DiamondStep(int col, int row, int stepSize, float heightScale)
	{
		float height = 0.0f;

		height += m_HeightValues[GetHeightIndex(col - stepSize, row)] * 0.25f;
		height += m_HeightValues[GetHeightIndex(col + stepSize, row)] * 0.25f;
		height += m_HeightValues[GetHeightIndex(col, row - stepSize)] * 0.25f;
		height += m_HeightValues[GetHeightIndex(col, row + stepSize)] * 0.25f;

		float newValue = height + Random.Range(-1.0f, 1.0f) * heightScale;
		m_HeightValues[GetHeightIndex(col, row)] = newValue;

		m_MaxHeight = Mathf.Max(m_MaxHeight, newValue);
		m_MinHeight = Mathf.Min(m_MinHeight, newValue);
	}

	/// <summary>
	/// Gets the index of the values array at the given row and collumn.
	/// </summary>
	/// <param name="col">The collumn within the values grid.</param>
	/// <param name="row">The row within the values grid.</param>
	/// <returns></returns>
	private int GetHeightIndex(int col, int row)
	{
		row = (int)Mathf.Repeat((float)row, (float)m_ValueSegmentCount);
		col = (int)Mathf.Repeat((float)col, (float)m_ValueSegmentCount);

		return row * m_ValueSegmentCount + col;
	}
}

