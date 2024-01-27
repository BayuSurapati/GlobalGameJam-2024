using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Problem[] problems; //list soal-soal mat nya
    public int curProblem; //soal yang sekarang yang perlu player selesaikan
    public float timeProblem; //waktu yang diberikan untuk menjawab soal

    public float remainingTime; //waktu yang tersisa

    public PlayerJetpack player; //player Object

    public GameObject portalOn;
    public GameObject portalOff;

    public GameObject deathScreen;
    public GameObject playerGema;

    // Start is called before the first frame update
    void Start()
    {
        //Set initial problem
        SetProblem(0);
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;

        //apakah waktu yang tersisa sudah habis?
        if (remainingTime <= 0.0f)
        {
            Lose();
        }
    }

    //instance
    public static GameManager instance;

    private void Awake()
    {
        //set instance to this script
        instance = this;
    }

    // dipanggil saat semua soal dijawab oleh player
    void Win()
    {
        //Portal
        portalOff.SetActive(false);
        portalOn.SetActive(true);
        
    }

    //dipanggil jika waktu di soal sudah habis atau 0
    void Lose()
    {
        Time.timeScale = 0.0f;
        //Set UI Text
        deathScreen.SetActive(true);
        playerGema.SetActive(false);

        if (deathScreen.activeInHierarchy)
        {
            Time.timeScale = 1f;
        }
    }

    //Set the current problem
    void SetProblem(int problem)
    {
        curProblem = problem;
        UI.instance.SetProblemText(problems[curProblem]);
        remainingTime = timeProblem;
        //Set UI Text to show problem dan answer
    }

    //dipanggil ketika player masuk ke tube yang benar
    void CorrectAnswers()
    {
        //is this the last answers?
        if (problems.Length - 1 == curProblem)
            Win();
        else
            SetProblem(curProblem + 1);
    }

    //dipanggil saat player salah memasuki tube
    void IncorrectAnswers()
    {
        
    }
    //dipanggil saat player memasuki tube
    public void OnPlayerEnterTube(int tube)
    {
        //apakah player memasuki tube yang benar?
        if (tube == problems[curProblem].correctTube)
            CorrectAnswers();
        else
            IncorrectAnswers();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
