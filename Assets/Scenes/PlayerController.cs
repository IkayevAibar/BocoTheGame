using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameController;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    private float m_JumpForce = 350f;
    private Collider2D m_Collider2D;
    public Animator Animator;
    float move;
    public Text medalToken;
    public Text LifeLeft;
    private int points = 0;
    private int points2 = 0;
    private int lifes = 3;
    public Text inputtext;
    public bool isStarted=false;
    public  string playerName;
    public Button b;
    public Camera mc;
    GameController gc;
    public GameObject gcc;
    public GameObject Medals;
    public float speed = 2f;
    public Text PlayerName;
    public Image rest;
    int commonScore;
    public Text Score;
    public Text Score2;
    public bool GameEnded = false;
    void Start()
    {
        gc = gcc.GetComponent<GameController>();

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Collider2D = GetComponent<Collider2D>();
        GameObject.Find("LifeLeft").gameObject.SetActive(false);
        GameObject.Find("MedalLeft").gameObject.SetActive(false);
        mc = GameObject.FindObjectOfType<Camera>();
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Medal") { 
            Catched();
            collision.gameObject.SetActive(false);
        }
        else if (collision.tag == "Destroyer")
        {
            isStarted = false;
            endGame();
            GameEnded = true;
        }
        else if (collision.tag == "Finish")
        {
            isStarted = false;
            endGame();
            GameEnded = true;
        }


    }
    IEnumerator RestartGame1()
    {
        yield return new WaitForSeconds(3f);
        RestartGame();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBlock")
        {
            Died();
            Animator.SetBool("isDied", true);
            speed = 0f;
            StartCoroutine(RestartGame1());
        }
    }
    public void Catched()
    {
        points++;
        medalToken.text = points.ToString();
    }
    public void Died()
    {
        lifes--;
        LifeLeft.text=lifes.ToString();
    }
    public void endGame()
    {

        PlayerName.text = playerName;
        PlayerName.gameObject.SetActive(true);
        rest.gameObject.SetActive(true);
        commonScore = points + points2;
        Score2.text = commonScore.ToString();
        Score2.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        Vector3 pos = new Vector3(0, 2.38f, -20);
        mc.gameObject.transform.position = pos;
        //GameObject.Find("Sun").gameObject.transform.position = new Vector3(0.1571227f, 3f, -1f);
        GameObject.Find("InputField").gameObject.SetActive(false);
        GameObject.Find("StartButton").gameObject.SetActive(false);
        isStarted = false;
        GameEnded = true;



    }
    public void RestartGame() {
        if (lifes >0)
        {
            m_Rigidbody2D.transform.position = new Vector3(-4.26f, -0.027f, 0);
            Animator.SetBool("isDied", false);
            isStarted = true;
        }
        else {
            isStarted = false;
            endGame();
        }

    }
    public void Strt() {
        isStarted = true;
    }
    void FixedUpdate()
    {
        playerName = gc.playerName;
        
        if (isStarted==true && GameEnded==false) {
            if (!GameEnded) {
                mc.transform.position = new Vector3(m_Rigidbody2D.transform.position.x, m_Rigidbody2D.transform.position.y, -20);
            }
            else {
                Vector3 pos = new Vector3(0, 2.38f, -20);
                mc.gameObject.transform.position = pos;
            }
            speed = 2f;
            move = Input.GetAxisRaw("Horizontal");

            Animator.SetFloat("Speed",move);

            Vector3 targetVelocity = new Vector2(move * speed, m_Rigidbody2D.velocity.y);

            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity,0.05f);

            if ((m_Collider2D.IsTouching(GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>()) || m_Collider2D.IsTouching(GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>())) && Input.GetButtonDown("Jump"))
            {
                Animator.SetBool("IsJumping", true);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
            else if((m_Collider2D.IsTouching(GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>()) || m_Collider2D.IsTouching(GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>()))) { 
                Animator.SetBool("IsJumping", false);
            }
        }



    }

}
