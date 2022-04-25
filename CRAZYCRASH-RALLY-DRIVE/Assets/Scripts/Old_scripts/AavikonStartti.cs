using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AavikonStartti : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody playerRB;
    private CarCollider carCollider;
    private PlayerMovement playerMove;
    private GameObject Kamera;
    private GameObject StartMenuKamera;
    private GameObject startCamera;


    //[HideInInspector]
    public bool IsGameStarted = false;
    //[HideInInspector]
    public bool GameStartForMapControll = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        startCamera = GameObject.Find("StartCamera");
        playerRB = Player.GetComponent<Rigidbody>();
        carCollider = Player.GetComponent<CarCollider>();
        Kamera = GameObject.Find("Main Camera");
        //StartMenuKamera = GameObject.Find("StartMenuCamera");
        playerMove = Player.GetComponent<PlayerMovement>();

        StartLevel2();
    }

    private void Update()
    {
        /*if (carCollider.isThatLevel2 == true)
        {
            IsGameStarted = true;
            GameStartForMapControll = true;
            playerRB.isKinematic = false;
            gameObject.SetActive(false);
            startCamera.SetActive(false);
            Kamera.SetActive(true);
        }*/
    }

    public void StartGame()
    {
        IsGameStarted = true;
        GameStartForMapControll = true;
        playerRB.isKinematic = false;
        //Kamera.SetActive(true);
        //StartMenuKamera.SetActive(false);
    }

    public void StartLevel2()
    {
        IsGameStarted = true;
        GameStartForMapControll = true;
        playerRB.isKinematic = false;
        gameObject.SetActive(false);
        startCamera.SetActive(false);
        Kamera.SetActive(true);
    }
}