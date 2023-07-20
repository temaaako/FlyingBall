using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private GameObject _magneticObject;
    [SerializeField] private float _power;
    private GameObject _target;
    private bool _isAttracted;

    private void LateUpdate()
    {
        if (_isAttracted && _magneticObject != null && _target != null)
        {
            Vector3 direction = _target.transform.position - _magneticObject.transform.position;
            float distance = direction.magnitude;

            // ���������, ������� ����������� ����� ������� �� ���� �����
            float moveAmount = Mathf.Min(distance, _power * Time.fixedDeltaTime);

            // ����������� ������ ����������� � �������� �� ����������� �����������
            Vector3 moveVector = direction.normalized * moveAmount;

            // ���������� ������
            _magneticObject.transform.position += moveVector;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player potentialPlayer = collision.gameObject.GetComponent<Player>();
        if (potentialPlayer is Player)
        {
            _isAttracted = true;
            _target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _target)
        {
            _isAttracted = false;
            _target = null;
        }
    }
}