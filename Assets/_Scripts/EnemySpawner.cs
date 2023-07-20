using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField, Min(0)] private int _count = 1;
    [SerializeField] private float _enemySpread;
    private void OnEnable()
    {
        _player = FindAnyObjectByType<Player>();
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void Start()
    {
        Spawn(_firstDistance);
    }

    private void Update()
    {
        if (_player.transform.position.x>_lastGeneratedX - _generationGap)
        {
            Spawn(_lastGeneratedX + _distanceBetween);
        }
    }

    protected override void Spawn(float desiredX)
    {
        for (int i = 0; i < _count; i++)
        {
            float y = Random.Range(_minY, _maxY);
            float x = Random.Range(desiredX - _enemySpread/2, desiredX + _enemySpread/2);

            Instantiate(_prefab, new Vector3(x, y), Quaternion.identity);
        }
        _lastGeneratedX = desiredX;
    }

    private void OnScoreChanged(int score)
    {
        _count = Random.Range(_count, score / 2 + 2);
    }
}
