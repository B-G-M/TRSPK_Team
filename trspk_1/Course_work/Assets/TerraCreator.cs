using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraCreator : MonoBehaviour
{
	public float mHeight = 0.0f;
	public float mWidth = 10.0f;
	public int quality = 10;

	private void ConstructQuadForMesh(MeshCreator meshCreator, Vector3 position,Vector2 uv,
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


	private void Start()
	{
		MeshCreator meshCreator = new MeshCreator();

		float scale = mWidth / quality;//размер сегментов

		Matrix4x4 meshTransform = transform.localToWorldMatrix;

		float y = 0.0f;
		for (int i = 0; i <= quality; i++)
		{
			float z = scale * i;
			float v = (1.0f / quality) * i;

			for (int j = 0; j <= quality; j++)
			{
				float x = scale * j;
				float u = (1.0f / quality) * j;
				
				Vector3 offset = new Vector3(x, y, z);

				Vector2 uv = new Vector2(u, v);

				bool buildTriangles = i > 0 && j > 0;

				ConstructQuadForMesh(meshCreator, offset, uv, buildTriangles, quality + 1);
			}
		}

		Mesh mesh = meshCreator.GetMesh();

		MeshFilter filter = GetComponent<MeshFilter>();

		if(filter != null)
			filter.sharedMesh = mesh;
	}
}
