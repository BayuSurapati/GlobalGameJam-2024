using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D bulletRB;

    public Vector2 moveDir;
    public GameObject bulletImpactEffect;

    public int bulletMaxAmount;
    public int bulletCurrentAmount;

    public int damageAmount;
    public GameObject ez;
    // Start is called before the first frame update
    void Start()
    {
        bulletCurrentAmount = bulletMaxAmount;
    }

    // Update is called once per frame
    void Update()
    {
        bulletRB.velocity = moveDir * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(bulletImpactEffect != null)
        {
            Instantiate(bulletImpactEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthController>().DamageEnemy(damageAmount);
        }
        if(other.tag == "Boss")
        {
            SceneManager.LoadScene("Ending");
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
