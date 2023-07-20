using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected float _firstDistance;
    [SerializeField] protected float _distanceBetween;
    [SerializeField] protected float _minY;
    [SerializeField] protected float _maxY;
    [SerializeField] protected Player _player;
    [SerializeField] protected float _generationGap = 3f;

    protected float _lastGeneratedX = 0;
    protected abstract void Spawn(float desiredX);


    
}
