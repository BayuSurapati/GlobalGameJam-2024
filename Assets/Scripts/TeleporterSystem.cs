using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterSystem : MonoBehaviour
{
    [SerializeField] GameObject teleporter;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = new Vector2(teleporter.transform.position.x, teleporter.transform.position.y);
            AudioManager.instance.playSFX(7);
        }
    }
}
