using UnityEngine;

public class TrailController : MonoBehaviour
{
    [SerializeField] private GameObject _echo;
    [SerializeField] private float _startTimeBtwSpawns = 0.1f;

    private float _timeBtwSpawns;

    private void Awake()
    {
        _timeBtwSpawns = _startTimeBtwSpawns;
    }

    void LateUpdate()
    {

        if (_timeBtwSpawns <= 0)
        {
            // spawn echo game object |
            GameObject instance = Instantiate(_echo, transform.position, Quaternion.identity);
            _timeBtwSpawns = _startTimeBtwSpawns;
        }
        else
        {
            _timeBtwSpawns -= Time.deltaTime;
        }
    }

}
