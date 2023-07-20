
using UnityEngine;

public class BonusSpawner : Spawner
{
    // Start is called before the first frame update
    private void Update()
    {
        if (_player.transform.position.x > _lastGeneratedX - _generationGap)
        {
            Spawn(_lastGeneratedX + _distanceBetween);
        }
    }

    protected override void Spawn(float desiredX)
    {
        
        float y = Random.Range(_minY, _maxY);

        Instantiate(_prefab, new Vector3(desiredX, y), Quaternion.identity);
        _lastGeneratedX = desiredX;
    }
}
