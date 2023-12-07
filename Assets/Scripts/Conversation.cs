using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{

    public GameObject m_text;

    public GameObject m_gameobjectE;

    public static bool canTalk = false;

    public static bool showE = false;

    public static bool stopMove = false;
    // Start is called before the first frame update
    void Start()
    {
        m_gameobjectE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTalk == true)
        {
            Movement.canMove = false;
            stopMove = true;
            m_gameobjectE.SetActive(false);
            m_text.SetActive(true);
            QuestionManager.setActive = true;
        }
        if (canTalk == false)
        {
            m_text.SetActive(false);           
        }

        if(canTalk == false && showE == true)
        {
            m_gameobjectE.SetActive(true);
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
