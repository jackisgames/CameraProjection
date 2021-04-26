using System.Collections.Generic;
using UnityEngine;

public class CameraProjectionDemo : MonoBehaviour
{
	[SerializeField]
	private Scene m_scene;

	[SerializeField]
	private float m_fov = 60.0f;

	private void Update()
	{

		Matrix4x4 cameraMatrix = BuildProjectionMatrix(.3f, 1000.0f, m_fov );

		List<Vector3> projectedVerts = new List<Vector3>(1024);

        //render objects
		foreach (var obj in m_scene.SceneObjects)
		{
			Matrix4x4 vertToCameraSpace = m_scene.GetCameraTransform.worldToLocalMatrix * obj.transform.localToWorldMatrix;
			//project vertices
			projectedVerts.Clear();
			foreach (var vert in obj.GetVertices())
			{
				Vector4 projectedVert = cameraMatrix * vertToCameraSpace * new Vector4( vert.x, vert.y, vert.z, 1.0f );
				projectedVert /= projectedVert.w;//convert to 'normal' space

				//remember to discard the a or y value that's less than -1 or more than 1
				projectedVerts.Add( projectedVert );
            }

			//draw triangles
			int[] tris = obj.GetTriangles();

            for (int i = 0; i < tris.Length; i += 3)
			{
				Debug.DrawLine(projectedVerts[tris[i]], projectedVerts[tris[i + 1 ]], obj.Color , 0.0f, true );
				Debug.DrawLine(projectedVerts[tris[i + 1]], projectedVerts[tris[i + 2 ]], obj.Color, 0.0f, true);
				Debug.DrawLine(projectedVerts[tris[i + 2]], projectedVerts[tris[i]], obj.Color, 0.0f, true);
			}
        }
    }

	private Matrix4x4 BuildProjectionMatrix( float near, float far, float fov)
	{
        float s = 1.0f / Mathf.Tan( fov * .5f * Mathf.Deg2Rad );
		float r = far - near;

		Matrix4x4 cameraMatrix = new Matrix4x4();

		cameraMatrix[0, 0] = s;
		cameraMatrix[1, 1] = s;
		cameraMatrix[2, 2] = far/ r;
		cameraMatrix[3, 2] = (far * near ) / r;
        cameraMatrix[2, 3] = -1;
		cameraMatrix[3, 3] = 0;

        return cameraMatrix;
	}
}
