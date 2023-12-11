using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TextMeshProUGUI m_text;
    [SerializeField] string text;
    [SerializeField] string text1;
    [SerializeField] string text2;
    [SerializeField] string text3;




    public static int i = 0;
    public static bool shouldRepead = false;
    void Start()
    {
        StartCoroutine(Dialog(text));
    }

    private void Repead()
    {
        StartCoroutine(Dialog(text));

        shouldRepead = false;
    }
    private void Update()
    {
        if (shouldRepead)
        {
            Repead();
        }

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
    [SerializeField] private ScriptableDialogue CurrentDialogText;
    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] private Transform ButtonParent;
    [ContextMenu("Generate Button")]
    void GenerateNewButtons() //ScriptableDialogue _nextDialogue;  //Überprüfen, dass alte Buttons weg sind
    {
        for (int i = 0; i < CurrentDialogText.Choices.Length; i++)
        {
            GameObject buttonObject = Instantiate(ButtonPrefab);
            buttonObject.transform.SetParent(ButtonParent);
            Button buttonComp = buttonObject.GetComponent<Button>();
            buttonComp.GetComponentInChildren<TextMeshProUGUI>().text = CurrentDialogText.Choices[i];
            int choiceNumber = i;
            buttonComp.onClick.AddListener(() => { Debug.Log(choiceNumber); });//ShowDialogue(DialogText.NextDialogues[choiceNumber];
                                             //SetNextDialogue;
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