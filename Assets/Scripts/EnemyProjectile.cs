using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float timeToLive = 5f;
    public float timeSinceSpawned = 0f;

    public int damageAmount = 1;

    //public DamagePlayer damagePlayer;
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position += moveSpeed * transform.right * Time.deltaTime;

        timeSinceSpawned += Time.deltaTime;

        if(timeSinceSpawned >= timeToLive)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;

        if(other.gameObject.name == "Player")
        {
            PlayerHealthController.instance.DamagePlayer(damageAmount);
        }
    }
}
