using UnityEngine;
using System.Collections;


public class TerrainOffset : MonoBehaviour
{

	public float m_YOffset = 0.0f;

	public ProcTerrain m_Terrain;

	private void Start()
	{
		if (m_Terrain == null)
			return;

		Vector3 position = transform.position;

		transform.position = m_Terrain.GetWorldPosition(position.x, position.z, m_YOffset);
	}
}
