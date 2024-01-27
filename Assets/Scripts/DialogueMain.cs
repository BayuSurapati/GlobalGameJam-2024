using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueMain : MonoBehaviour
{
    public GameObject MonoDialogBox;

    public GameObject charGema;
    public GameObject charImroatus;

    public TextMeshProUGUI textComponent;
    public string[] Lines;

    public float textSpeed;
    public int index;

    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == Lines[index])
            {
                NextLines();
                //source.PlayOneShot(clip);

            }
            else
            {
                StopAllCoroutines();
                textComponent.text = Lines[index];
                //source.Stop();
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in Lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLines()
    {
        if (index < Lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

            if(index == 2)
            {
                charGema.SetActive(true);
                charImroatus.SetActive(true);
            }
        }
        else
        {
            charGema.SetActive(false);
            charImroatus.SetActive(false);
            SceneManager.LoadScene(sceneToLoad);
            gameObject.SetActive(false);
        }
    }
}
