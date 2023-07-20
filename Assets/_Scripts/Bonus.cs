using System;
using UnityEngine;

public class Bonus: MonoBehaviour
{
    [SerializeField] private float _lifeTime = 20f;

    private void Start()
    {
        Destroy(gameObject,_lifeTime);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player potentialPlayer = collision.gameObject.GetComponent<Player>();
        if (potentialPlayer is Player)
        {
            potentialPlayer.BonusCollected();
            Destroy(gameObject);
        }
    }
}
