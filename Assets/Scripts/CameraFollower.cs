using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Vector3 _offset = new Vector3(0, 3f, -10f);

    private void LateUpdate()
    {
        transform.position = _followTarget.position + _offset;
    }
}
