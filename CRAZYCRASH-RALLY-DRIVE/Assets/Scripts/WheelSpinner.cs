using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpinner : MonoBehaviour
{
    private GameObject thisWheel;

    private GameObject startButtonB;
    private StartButton startButtonS;

    private GameObject Player;
    private CarCollider carCollider;

    private GameObject frontCcollider;
    private MapControll mapControll;

    private float rotSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        thisWheel = gameObject;

        startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();

        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();

        frontCcollider = GameObject.Find("FrontCollider");
        mapControll = frontCcollider.GetComponent<MapControll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startButtonS.IsGameStarted && !carCollider.isPlayerDead && !mapControll.isGamePaused)
        {
            SpinWheel();
        }
    }


    private void SpinWheel()
    {
        /*if (thisWheel.CompareTag("RightBackWheel") || thisWheel.CompareTag("LeftBackWheel"))
        {
            thisWheel.transform.RotateAround(new Vector3(thisWheel.transform.position.x, thisWheel.transform.position.y, thisWheel.transform.position.z), new Vector3(1f, 0f, 0f), rotSpeed * Time.deltaTime);
        }

        if (thisWheel.CompareTag("RightFrontWheel") || thisWheel.CompareTag("LeftFrontWheel"))
        {
            thisWheel.transform.RotateAround(new Vector3(thisWheel.transform.position.x, thisWheel.transform.position.y, thisWheel.transform.position.z), new Vector3(1f, 0f, 0f), rotSpeed * Time.deltaTime);
        }*/

    }
}
