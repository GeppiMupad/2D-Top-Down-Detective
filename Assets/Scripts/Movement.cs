using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed = 4f;

    [SerializeField] private Sprite m_spriteleft;
    [SerializeField] private Sprite m_spriteright;
    [SerializeField] private Sprite m_spritefront;
    [SerializeField] private Sprite m_spriteback;

    private float horizontal;
    private float vertical;

    private float limit = 0.7f;

    private Rigidbody2D m_rigidbody;

    private SpriteRenderer m_spriterenderer;

    public static bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();

        m_spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        //freeze bzw. unfreeze den Player nachdem er E gedrückt hat ( warn bugg dass wenn der spieler E drückt zum reden während er gelaufen ist, hatte er sich weiter bewegt) 
        if(Conversation.stopMove == true)
        {
            m_rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        if(Conversation.stopMove == false)
        {
            m_rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.None;
        }


        if (horizontal < 0)
        {
            //muss methode bzw dann animation abspielen, dass der richtige Sprite gezeigt wird
            m_spriterenderer.sprite = m_spriteleft;
        }

        if (horizontal > 0)
        {
            m_spriterenderer.sprite = m_spriteright;
        }

        if (vertical < 0)
        {
            m_spriterenderer.sprite = m_spritefront;
        }
        if (vertical > 0)
        {
            m_spriterenderer.sprite = m_spriteback;
        }

        if ((horizontal > 0 && vertical > 0))
        {
            m_spriterenderer.sprite = m_spriteright;
        }

        if (horizontal > 0 && vertical < 0)
        {
            m_spriterenderer.sprite = m_spriteright;
        }

        if (horizontal < 0 && vertical < 0)
        {
            m_spriterenderer.sprite = m_spriteleft;
        }

        if (horizontal < 0 && vertical > 0)
        {
            m_spriterenderer.sprite = m_spriteleft;
        }

    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= limit;
            vertical *= limit;
        }

        m_rigidbody.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
