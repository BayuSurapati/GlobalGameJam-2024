using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;

    public float moveSpeed, waitAtPoints;
    private float waitCounter;

    public float jumpForce;

    public Rigidbody2D enemyRB;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoints;

        foreach(Transform pPoint in patrolPoints)
        {
            pPoint.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs (transform.position.x - patrolPoints[currentPoint].position.x) > .2f)
        {
            if(transform.position.x < patrolPoints[currentPoint].position.x)
            {
                enemyRB.velocity = new Vector2(moveSpeed, enemyRB.velocity.y);
                transform.localScale = Vector3.one;
            }
            else
            {
                enemyRB.velocity = new Vector2(-moveSpeed, enemyRB.velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if(transform.position.y < patrolPoints[currentPoint].position.y - .5f && enemyRB.velocity.y < .1f)
            {
                enemyRB.velocity = new Vector2(enemyRB.velocity.x, jumpForce);
            }
        }
        else
        {
            enemyRB.velocity = new Vector2(0f, enemyRB.velocity.y);
            waitCounter -= Time.deltaTime;
            if(waitCounter <= 0)
            {
                waitCounter = waitAtPoints;
                currentPoint += 1;

                if(currentPoint >= patrolPoints.Length)
                {
                    currentPoint = 0;
                }
            }
        }
    }
}
