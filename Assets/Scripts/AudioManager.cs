using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;

    public AudioSource[] BGM;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSFX(int SFXnumber)
    {
        if(SFXnumber < soundEffects.Length)
        {
            soundEffects[SFXnumber].Play();
        }
    }

    public void stopSFX(int SFXnumber)
    {
        if(SFXnumber < soundEffects.Length)
        {
            soundEffects[SFXnumber].Stop();
        }
    }
}
