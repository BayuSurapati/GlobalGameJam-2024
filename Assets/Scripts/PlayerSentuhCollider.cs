using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSentuhCollider : MonoBehaviour
{
    public int damageAmount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.name== "Player")
        {
            PlayerHealthController.instance.DamagePlayer(damageAmount);
        }
    }
}
