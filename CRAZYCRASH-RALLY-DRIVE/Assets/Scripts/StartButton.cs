using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody playerRB;
    private PlayerMovement playerMove;
    private GameObject Kamera;
    private GameObject StartMenuKamera;


    [HideInInspector]
    public bool IsGameStarted = false;
    [HideInInspector]
    public bool GameStartForMapControll = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerRB = Player.GetComponent<Rigidbody>();
        //Kamera = GameObject.Find("Main Camera");
        //StartMenuKamera = GameObject.Find("StartMenuCamera");
        playerMove = Player.GetComponent<PlayerMovement>();
    }

    public void StartGame()
    {
        IsGameStarted = true;
        GameStartForMapControll = true;
        playerRB.isKinematic = false;
        //Kamera.SetActive(true);
        //StartMenuKamera.SetActive(false);
    }
}