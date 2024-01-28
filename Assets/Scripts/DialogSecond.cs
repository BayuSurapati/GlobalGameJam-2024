using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogSecond : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Image characterImage;
    public Sprite[] characterSprites;
    public string[] dialogueLines;
    private int dialogueIndex;
    public float typingSpeed = 0.05f; // Kecepatan ketik

    public GameObject dialogBox,player,boss,introDummy,camera;
    void Start()
    {
        dialogueIndex = 0;
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Mengganti KeyCode.Space dengan klik kiri mouse
        {
            AudioManager.instance.stopSFX(0);
            if (dialogueText.text == dialogueLines[dialogueIndex]) // Cek apakah sudah selesai mengetik
            {
                AudioManager.instance.stopSFX(0);
                NextLine();
            }
            else // Jika teks belum selesai, tampilkan semua sekaligus
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[dialogueIndex];
            }
        }
    }

    void NextLine()
    {
        if (dialogueIndex < dialogueLines.Length - 1)
        {
            dialogueIndex++;
            dialogueText.text = "";
            StartCoroutine(TypeLine());
            UpdateDialogue();
        }
        else
        {
            // Akhir dialog
            dialogueText.text = "";
            characterImage.gameObject.SetActive(false);
            dialogueText.gameObject.SetActive(false);
            dialogBox.SetActive(false);
            player.SetActive(true);
            boss.SetActive(true);
            introDummy.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueLines[dialogueIndex].ToCharArray())
        {
            dialogueText.text += c;
            AudioManager.instance.playSFX(0);
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    void UpdateDialogue()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        characterImage.sprite = characterSprites[dialogueIndex]; // Pastikan baris ini ada
        StartCoroutine(TypeLine());
    }
}
