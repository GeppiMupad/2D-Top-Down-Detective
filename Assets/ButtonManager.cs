using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void One()
    {     
            QuestionManager.button = 1;  //Wenn die erste Frage ausgewählt wurde dann QuestionManager.button = 1 und somit wird Antwort 1 getriggert      
    }
       
    public void Two()
    {
            QuestionManager.button = 2;
    }

    public void Three()
    {
            QuestionManager.button = 3;
    }

    public void Repead()
    {
        DialogManager.shouldRepead = true;
    }

    public void Quit()
    {
        Movement.canMove = true;
        Conversation.showE = true;       

       // Conversation.canTalk = false; // also ja behebt mein bugg dass ich nicht immer rauslaufen muss aus dem Trigger aber dafür neuer ( text geht nicht weg )
       //muss noch gefixxt werden 
        Conversation.stopMove = false;
        QuestionManager.setActive = false;
        Conversation.showConvo = false;
    }

}
