using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent (typeof(TextMeshPro))]
public class TypeWriterText : MonoBehaviour
{
    TextMeshPro textMesh;
    string[] textCharacter;
    public bool isActive;
    public float timeInSeconds;
    float timer;
    int charCount;
    //public GameObject[] speechBoxes;
    //public TextMeshProUGUI txt;
    //public Text txt;
    //public string characterSpeech;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        textCharacter = new string[textMesh.text.Length];
        for(int i = 0; i < textMesh.text.Length; i++)
        {
            textCharacter[i] = textMesh.text.Substring(i, 1);
        }
        textMesh.text = "";
        charCount = 0;
        timer = 0;
        //txt = GetComponent<TextMeshProUGUI>();
        //characterSpeech = txt.text;
        //txt.text = "";
    }

    void Update()
    {
        if (isActive)
        {
            if(charCount < textCharacter.Length)
            {
                timer += Time.deltaTime;
            }
            if(timer >= timeInSeconds)
            {
                textMesh.text += textCharacter[charCount];
                charCount++;
                timer = 0;
            }
        }
        if(charCount == textCharacter.Length)
        {
            if(transform.childCount > 0)
            {
                transform.GetChild(0).GetComponent<TypeWriterText>().isActive = true;
                charCount++;
            }
        }
    }

    /*IEnumerator PlayText()
    {
        foreach (char c in txt)
        {
            speechBoxes[0].SetActive(true);
            txt.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }*/
}
