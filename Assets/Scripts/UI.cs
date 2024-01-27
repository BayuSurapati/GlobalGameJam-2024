using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Text problemText; //text yang menampilkan soal math nya
    public Text[] answersTexts; //array dari 4 jawaban

    public Image remainingTimeDial; //remaining time dengan image yang tadi
    public float remainingTimeDialRate; // 1.0 / time per problem

    public Text endText; //text yang akan ditampilkan di tengah (Menang atau Kalah)
    // Start is called before the first frame update
    void Start()
    {
        //set the remaining time dial rate
        //

        remainingTimeDialRate = 1.0f / GameManager.instance.timeProblem;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTimeDial.fillAmount = remainingTimeDialRate * GameManager.instance.remainingTime;
    }

    //instance
    public static UI instance;

    private void Awake()
    {
        //set instance untuk script ini
        instance = this;
    }

    public void SetProblemText(Problem problem)
    {
        string operatorText = "";

        //Meng convert operatornya menjadi simbol nyata
        switch (problem.operation)
        {
            case MathOperation.Addition: operatorText = " + "; break;
            case MathOperation.Substraction: operatorText = " - "; break;
            case MathOperation.Multiplication: operatorText = " x "; break;
            case MathOperation.Division: operatorText = " : "; break;
        }
        //set the the problem untuk muncul di problem teks
        problemText.text = problem.firstNumber + operatorText + problem.secondNumber;

        //set jawabannya di masing-masing tube
        for (int index = 0; index < answersTexts.Length; index++)
        {
            answersTexts[index].text = problem.answers[index].ToString();
        }
    }

    //set teks akhir dari game jika player menang ataupun kalah
    public void SetEndText(bool win)
    {
        //mengaktifkan teks akhir
        endText.gameObject.SetActive(true);

        //apakah playernya menang?
        if (win)
        {
            endText.text = "Anda Menang";
            endText.color = Color.green;
        }
        //apakah playernya kalah?
        else
        {
            endText.text = "Anda Kalah";
            endText.color = Color.red;
        }
    }
}
