using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Game2 : MonoBehaviour
{
    public GameObject finish;
    public GameObject player;
    public GameObject mainCamera;
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerController>();
    }
    
    // Update is called once per frame
    
}
