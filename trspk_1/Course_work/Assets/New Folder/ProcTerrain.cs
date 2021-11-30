using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProcTerrain : MonoBehaviour
{
    public float m_Height = 1.0f;
    public float m_Width = 20.0f;
    public int m_SegmentCount = 100;

    public abstract float GetY(float x, float z);

    public Vector3 GetWorldPosition(float xPosition, float zPosition, float yOffset)
    {
        Vector3 localGroundPos = transform.worldToLocalMatrix.MultiplyPoint3x4(new Vector3(xPosition, 0.0f, zPosition));
        localGroundPos.y = GetY(localGroundPos.x, localGroundPos.z) + yOffset;

        return transform.localToWorldMatrix.MultiplyPoint3x4(localGroundPos);
    }

    protected virtual void Start()
    {
        MeshBuilder meshBuilder = new MeshBuilder();

        float segmentSize = m_Width / m_SegmentCount;

        Matrix4x4 meshTransform = transform.localToWorldMatrix;

        for (int i = 0; i <= m_SegmentCount; i++)
        {
            float z = segmentSize * i;
            float v = (1.0f / m_SegmentCount) * i;

            for (int j = 0; j <= m_SegmentCount; j++)
            {
                float x = segmentSize * j;
                float u = (1.0f / m_SegmentCount) * j;

                Vector3 offset = new Vector3(x, GetY(x, z), z);

                Vector2 uv = new Vector2(u, v);
                bool buildTriangles = i > 0 && j > 0;

                BuildQuadForGrid(meshBuilder, offset, uv, buildTriangles, m_SegmentCount + 1);
            }
        }

        Mesh mesh = meshBuilder.CreateMesh();
        mesh.RecalculateNormals();

        //Look for a MeshFilter component attached to this GameObject:
        MeshFilter filter = GetComponent<MeshFilter>();

        //If the MeshFilter exists, attach the new mesh to it.
        //Assuming the GameObject also has a renderer attached, our new mesh will now be visible in the scene.
        if (filter != null)
        {
            filter.sharedMesh = mesh;
        }
    }

    private void BuildQuadForGrid(MeshBuilder meshBuilder, Vector3 position, Vector2 uv, bool buildTriangles, int vertsPerRow)
    {
        meshBuilder.Vertices.Add(position);
        meshBuilder.UVs.Add(uv);

        if (buildTriangles)
        {
            int baseIndex = meshBuilder.Vertices.Count - 1;

            int index0 = baseIndex;
            int index1 = baseIndex - 1;
            int index2 = baseIndex - vertsPerRow;
            int index3 = baseIndex - vertsPerRow - 1;

            meshBuilder.AddTriangle(index0, index2, index1);
            meshBuilder.AddTriangle(index2, index3, index1);
        }
    }
}
