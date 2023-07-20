using UnityEngine;

public class Follower : MonoBehaviour
{
    private float _offsetX;                   
    private Transform _target;                


    private void Start()
    {
        _target = FindAnyObjectByType<Player>().transform;
        _offsetX = transform.position.x - _target.position.x;
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(_target.position.x + _offsetX, transform.position.y, transform.position.z);

        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = desiredPosition;
    }
}
