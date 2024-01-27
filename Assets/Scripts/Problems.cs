using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Problem
{
    public float firstNumber; //nomor pertama di soal
    public float secondNumber; //nomor kedua di soal
    public MathOperation operation; // operasi diantara kedua nomornya
    public float[] answers; //array yang menyimpan semua jawaban termasuk yang benar

    [Range(0, 3)]
    public int correctTube; //index dari tube yang memiliki jawaban yang benar

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum MathOperation
{
    Addition,
    Substraction,
    Multiplication,
    Division
}
