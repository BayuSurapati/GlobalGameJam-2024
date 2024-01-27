using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField]float elapsedTime;

    public GameObject LoseScreen;
    public GameObject playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int miliseconds = Mathf.FloorToInt(elapsedTime % 1 * 1000);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("0");

        if(elapsedTime <= 0)
        {
            
            LoseScreen.SetActive(true);
            playerSprite.SetActive(false);
        }
    }
}
