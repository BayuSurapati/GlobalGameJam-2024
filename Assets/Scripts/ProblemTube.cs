using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemTube : MonoBehaviour
{
    public int tubeID; //indetifikasi nomor dari tubenya

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //apakah ini playernya?
        if (collision.CompareTag("Player"))
        {
            //beri tahu game manager bahwa player memasuki tube ini
            GameManager.instance.OnPlayerEnterTube(tubeID);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
