using UnityEngine;

public class Scene : MonoBehaviour
{
	[SerializeField]
	private Transform m_cameraTransform;

	public Transform GetCameraTransform
	{
		get { return m_cameraTransform; }
	}

	[SerializeField]
	private SceneObject[] m_objects;

	public SceneObject[] SceneObjects
	{
		get { return m_objects; }
	}


	private void OnDrawGizmos()
	{
		UnityEditor.Handles.color = Color.red;
		UnityEditor.Handles.ArrowHandleCap( 0, m_cameraTransform.position, m_cameraTransform.rotation, 1.0f , EventType.Repaint );
		UnityEditor.Handles.Label( m_cameraTransform.position, "Virtual Camera" );
	}
}
