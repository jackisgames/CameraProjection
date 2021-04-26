using UnityEngine;

public class RotateObject : MonoBehaviour
{
	[SerializeField]
	private Vector3 m_axis;

	private void Update()
    {
        transform.Rotate(m_axis, 360 * Time.deltaTime );
    }
}
