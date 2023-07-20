using UnityEngine;


public class Enemy : Danger
{
    [SerializeField] private float _amplitude = 1f;   
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _lifeTime = 10f;

    private float _initialY;     
    private int _direction;      

    private void Start()
    {
        _initialY = transform.position.y;
        _direction = Random.Range(0, 2) == 0 ? -1 : 1;
        Destroy(gameObject,_lifeTime);
    }

    private void FixedUpdate()
    {
        float newY = _initialY + _direction * _amplitude * Mathf.Sin(Time.time * _speed);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
