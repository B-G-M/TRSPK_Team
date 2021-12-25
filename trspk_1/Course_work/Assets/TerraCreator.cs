using System;
using UnityEngine;
public class TerraCreator : MonoBehaviour
{
	private static int count = 9;
	private static int iWorld = 0;
	private static int jWorld = 0;
	private static int  x, z;
	private DiamondSquare diamondSquare;
	//public float mHeight = 0.0f;
	private static int n = 10;
	private static int quality = 100;
	private float mWidth;
	private Vector3 step;

	static private DiamondSquare [,] world = new DiamondSquare [100,100];

	private void ConstructQuadForMesh(MeshCreator meshCreator, Vector3 position, Vector2 uv,
		bool buildTriangles, int vertsPerRow)
	{
		meshCreator.Vertices.Add(position);
		meshCreator.UVs.Add(uv);

		if (!buildTriangles)
			return;

		int basePos = meshCreator.Vertices.Count - 1;

		int pos0 = basePos;
		int pos1 = basePos - 1;
		int pos2 = basePos - vertsPerRow;
		int pos3 = basePos - vertsPerRow - 1;

		meshCreator.AddTriangle(pos0, pos2, pos1);
		meshCreator.AddTriangle(pos2, pos3, pos1);
		
	}

	public void Start()
	{
		MeshCreator meshCreator = new MeshCreator();
		mWidth = (float)Math.Pow(2, n) + 1;

		int mapRang = (int)Mathf.Sqrt((quality + 1) * (quality + 1));
		int lenght = 0;
		for (int i = 0; lenght < mapRang; i++)
		{
			lenght = (int)Mathf.Pow(2, i) + 1;
		}
		quality = lenght - 1;

		float scale = mWidth / quality;//размер сегментов

		diamondSquare = new DiamondSquare();

		diamondSquare.heightMap = new float[(quality + 1), (quality + 1)];
		if (jWorld != 0)
		{
			
			for (int i = 0; i < quality + 1; i++)
			{
				diamondSquare.heightMap[i, 0] = world[iWorld, jWorld - 1].heightMap[i, world[iWorld, jWorld - 1].mapRang - 1];
			}
		}
		if (iWorld != 0)
		{
			//diamondSquare.heightMap = new float[(quality + 1), (quality + 1)];
			for (int i = 0; i < quality + 1; i++)
			{
				diamondSquare.heightMap[0, i] = world[iWorld - 1, jWorld].heightMap[world[iWorld - 1, jWorld].mapRang - 1, i];
			}
		}

		diamondSquare.Nachalo(quality + 1, scale);
		//Matrix4x4 meshTransform = transform.localToWorldMatrix; хз что это, может быть нужное 

		for (int i = 0; i <= quality; i++)
		{
			float z = scale * i;
			float v = (1.0f / quality) * i;
			float y;
			for (int j = 0; j <= quality; j++)
			{
				float x = scale * j;
				float u = (1.0f / quality) * j;

				y = diamondSquare.GetY(i, j);

				meshCreator.colors.Add(diamondSquare.GetColor(y));

				Vector3 offset = new Vector3(x, y, z);

				Vector2 uv = new Vector2(u, v);

				bool buildTriangles = i > 0 && j > 0;

				ConstructQuadForMesh(meshCreator, offset, uv, buildTriangles, quality + 1);
			}
		}

		Mesh mesh = meshCreator.GetMesh();

		gameObject.transform.position = new	Vector3(x, 0, z);

		world[iWorld, jWorld] = diamondSquare;
		if (step != null)
			step = meshCreator.Vertices[meshCreator.Vertices.Count - 1];

		x += (int)step.x;
		jWorld++;
		if (jWorld == count)
		{
			jWorld = 0;
			iWorld++;
			x = 0;
			z += (int)step.x;
		}
		MeshFilter filter = GetComponent<MeshFilter>();

		if (filter != null)
			filter.sharedMesh = mesh;
	}
}
