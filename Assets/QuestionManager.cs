using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    //Spieler soll erst frage stellen wenn Bot fertig geredet hat ( im dialogmanager wird auf true gesetzt )
    public static bool chooseQuestion = false;

    //sind die Antworten / fragen die vom spieler gestellt werden können ( buttons )
    public GameObject m_selectionmenu;

    //für die unterhaltung canChoose ( ist monolog vorbei und kann spieler was fragen ? ) button ( Index um buttons wieder aufpoppen zu lassen nach antwort)
    public static bool canChoose = false;
    public static int button = 0;

    //empfängt ob spieler sich aus trigger bewegt um Antworten wieder verschwinden zu lassen
    public static bool setActive = true;

    //nachdem er einmal schon gesprochen hat, sollen die buttons trotzdem auftauchen ( beim ersten mal tauchen die auf, weil der text ja geprintet wird, sollte der Spieler danach dahin gehen
    //wird kein Button gezeigt, da der Text schon da ist
    public static bool showQuestionAgain = false;
    void Start()
    {
        m_selectionmenu.SetActive(false);
    }

    private void Update()
    {
        if (chooseQuestion == true)
        {
            
            QuestionOne();           
        }

        if (setActive == false)
        {
            Start();
        }

        if(showQuestionAgain)
        {
            QuestionOne();
        }
    }


    public void QuestionOne()
    {
        showQuestionAgain = false;

        m_selectionmenu.SetActive(true);  // zeigt fragen die er Bot stellen kann

        canChoose = true;

        if(button == 1 && canChoose == true)
        {
            button = 0;
            m_selectionmenu.SetActive(false);  // macht fragemöglichkeiten ( buttons ) aus 
            DialogManager.i = 1;            //dialog 1 im DialogManager wird getriggert 
        }

        if (button == 2 && canChoose == true)
        {
            button = 0;
            m_selectionmenu.SetActive(false);
            DialogManager.i = 2;
           
        }

        if (button == 3 && canChoose == true)
        {
            button = 0;
            m_selectionmenu.SetActive(false);
            DialogManager.i = 3;
            
        }

    }
}
