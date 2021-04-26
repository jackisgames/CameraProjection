using UnityEngine;

public class RotateAround : MonoBehaviour
{
	[SerializeField]
	private Vector3 m_axis;

	[SerializeField]
	private Transform m_target;

    private void Update()
    {
        transform.Rotate( m_axis, 100 * Time.deltaTime );
	    transform.position = m_target.position + transform.forward * 5.0f;
    }
}
