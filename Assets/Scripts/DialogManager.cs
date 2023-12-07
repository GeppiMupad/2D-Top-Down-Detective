using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogManager : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TextMeshProUGUI m_text;
    [SerializeField] string text;
    [SerializeField] string text1;
    [SerializeField] string text2;
    [SerializeField] string text3;
  

    public static int i = 0;
    void Start()
    {
        StartCoroutine(Dialog(text));
    }

    private void Update()
    {
        if (i == 1)
        {            
            QuestionManager.chooseQuestion = false;
            StartCoroutine(Dialog(text1));
           
            i--;
        }

        if (i == 2)
        {
            QuestionManager.chooseQuestion = false;
            StartCoroutine(Dialog(text2));
            
            i = 0;
        }

        if (i == 3)
        {
            QuestionManager.chooseQuestion = false;
            StartCoroutine(Dialog(text3));
           
            i = 0;
        }


    }

    public IEnumerator Dialog(string dialog)
    {

        m_text.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            m_text.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }

        QuestionManager.chooseQuestion = true;
    }

}