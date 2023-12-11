using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
     
    public GameObject m_text;   //Text vom Bot

    public GameObject m_gameobjectE;   // E über Bot

    public static bool canTalk = false;  // Ist spieler in Range um zu reden ?
    public static bool showConvo = true;  // Zeig den Hintergrund wo der Bottext erscheint 

    public static bool showE = false;  //Zeig E an oder nicht

    public static bool stopMove = false; // Freezed die Position des Spielers in Movement wenn true ( nachdem er E gedürckt hat ) 
  
    void Start()
    {
        m_gameobjectE.SetActive(false);
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTalk == true)
        {
            Movement.canMove = false;
            stopMove = true;
            showE = false;
            showConvo = true;
            m_gameobjectE.SetActive(false);
            m_text.SetActive(true);
            QuestionManager.setActive = true;
        }

        if(!showConvo)
        {
            m_text.SetActive(false);
        }

        if (canTalk == false)
        {
            m_text.SetActive(false);
        }

        if (showE == true)
        {
            m_gameobjectE.SetActive(true); // Zeigt E nach Quit wieder an
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_gameobjectE.SetActive(true);
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_gameobjectE.SetActive(false);
            showE = false;
            canTalk = false;
        }
    }
}
