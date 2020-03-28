using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerController;

public class GameController : MonoBehaviour
{
    public GameObject finish;
    public GameObject player;
    public GameObject cactoos;
    public GameObject mainCamera;
    private PlayerController pc;
    public Text inputtext;
    public bool isStarted = false;
    public string playerName;
    public Button b;
    public Camera mc;
    public Selectable ml;
    public Selectable ll;
    public GameObject textGameReady;
    public Image medalImage;
    bool StartPressed;
    public GameObject PlayerName;
    public GameObject RestartImage;
    public GameObject Score2;
    public GameObject Score;
    public GameObject Sun;
    public Rigidbody2D SunFlower;
    //public GameObject PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerController>();
        mc = GameObject.FindObjectOfType<Camera>();
        StartCoroutine(Asd());
    }
    IEnumerable Sec()
    {
        yield return new WaitForSeconds(5f);
    }
    public void StartButtonPressed()
    {
        Vector3 pos = new Vector3(0 ,0, -20);
        mc.gameObject.transform.position = pos;
        b.gameObject.SetActive(false);
        playerName = inputtext.text!=""? inputtext.text:"Player";
        
        
        ll.gameObject.SetActive(true);
        ml.gameObject.SetActive(true);
        PlayerName.SetActive(false);
        Score.SetActive(false);
        RestartImage.SetActive(false);
        Score2.SetActive(false);
        GameObject.Find("InputField").gameObject.SetActive(false);
        isStarted = true;
        StartPressed = true;
    }
    public void RestartButtonPressed()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    // Update is called once per frame
    IEnumerator Asd()
    {
       
        while (true) {
            
            if (StartPressed)
            {
                pc.Strt();
                yield return new WaitForSeconds(2f);
                textGameReady.SetActive(false);
                StartPressed = false;
                
            }
            /*foreach (GameObject go in GameObject.FindGameObjectsWithTag("EnemyBlock"))
            {
                if (player.GetComponent<Collider2D>().IsTouching(go.GetComponent<Collider2D>()))
                {
                    
                }
            }*/
            yield return new WaitForSeconds(0.5f);
        }
    }
}
