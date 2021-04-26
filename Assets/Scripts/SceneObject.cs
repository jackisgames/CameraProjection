using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SceneObject : MonoBehaviour
{
	[SerializeField]
	private Color m_color = Color.white;

	public Color Color
	{
		get { return m_color; }
	}

	public Vector3[] GetVertices()
	{
		return GetComponent<MeshFilter>().sharedMesh.vertices;
	}

	public int[] GetTriangles()
	{
		return GetComponent<MeshFilter>().sharedMesh.triangles;
	}
}
