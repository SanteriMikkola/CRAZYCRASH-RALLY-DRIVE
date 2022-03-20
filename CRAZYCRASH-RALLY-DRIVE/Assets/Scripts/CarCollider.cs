using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    private CarController carController;
    private PlayerColor playerColor;
    private GameObject Player;
    private GameObject Kamera;
    private GameObject SpheRe;
    //private GameObject[] Wheels;

    private BoxCollider playersBoxCollider;
    //public CapsuleCollider[] WheelColliders;
    private SphereCollider SphereCollider;

    public bool playerCollide = false;
    public bool isPlayerDead = false;

    public bool isPlayerMoving = true;
    public bool toolBoxPicked = false;
    public bool jerryCanPicked = false;
    public bool isThatFullHealthReverse;
    public bool isThatLevel2 = false;

    public int osuma = 0;

    public float fuel = 100f;

    public int maxOsumat = 5;

    private Vector3 playerPos_4z;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        //Wheels = GameObject.FindGameObjectsWithTag("Wheel");
        SpheRe = GameObject.Find("Sphere");
        carController = Player.GetComponent<CarController>();
        playersBoxCollider = Player.GetComponent<BoxCollider>();
        SphereCollider = SpheRe.GetComponent<SphereCollider>();

        playerColor = Player.GetComponent<PlayerColor>();
        Kamera = GameObject.Find("Main Camera");
    }

    public void Update()
    {

        /*if (playerCollide == true)
        {
            isPlayerMoving = false;
            //playerGotL = true;
            carController.forwardSpeed = carController.forwardSpeed - 1f;
            //rb.AddForce(stuckForce, ForceMode.Impulse);
        }*/
    }

    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Este") && playerCollide == false)
        {
            playerCollide = true;
            playersBoxCollider.enabled = false;
            /*WheelColliders[0].enabled = false;
            WheelColliders[1].enabled = false;
            WheelColliders[2].enabled = false;
            WheelColliders[3].enabled = false;*/
            SphereCollider.enabled = false;
            osuma++;
            Debug.Log("Osuma");
            //StartCoroutine(PlayerColorBlink());
            //StartCoroutine(CollidersOff());
            //transform.Translate(lowSpeed * Time.deltaTime * Vector3.forward, Space.World);
            //StartCoroutine(CollidersOn());
            StartCoroutine(PlayerColliderOn());
        }
        if (collider.gameObject.CompareTag("AavikonEste") && playerCollide == false)
        {
            playerCollide = true;
            playersBoxCollider.enabled = false;
            /*WheelColliders[0].enabled = false;
            WheelColliders[1].enabled = false;
            WheelColliders[2].enabled = false;
            WheelColliders[3].enabled = false;*/
            SphereCollider.enabled = false;
            osuma++;
            Debug.Log("Osuma");
            //StartCoroutine(PlayerColorBlink());
            //StartCoroutine(CollidersOff());
            //transform.Translate(lowSpeed * Time.deltaTime * Vector3.forward, Space.World);
            //StartCoroutine(CollidersOn());
            StartCoroutine(PlayerColliderOn());
        }
        if (osuma == maxOsumat)
        {
            isPlayerDead = true;
            gameObject.SetActive(false);
            Kamera.SetActive(false);
            playerCollide = false;
        }

        if (collider.gameObject.CompareTag("ToolBox") && toolBoxPicked == false)
        {
            toolBoxPicked = true;
            if (isThatFullHealthReverse == true)
            {
                osuma = 0;
            }
            else if (isThatFullHealthReverse == false)
            {
                if (osuma >= 2)
                {
                    osuma -= 2;
                }
                else if (osuma < 2)
                {
                    osuma = 0;
                }
            }
        }
        if (collider.gameObject.CompareTag("A_ToolBox") && toolBoxPicked == false)
        {
            toolBoxPicked = true;
            if (isThatFullHealthReverse == true)
            {
                osuma = 0;
            }
            else if (isThatFullHealthReverse == false)
            {
                if (osuma >= 2)
                {
                    osuma -= 2;
                }
                else if (osuma < 2)
                {
                    osuma = 0;
                }
            }
        }

        if (collider.gameObject.CompareTag("JerryCan") && jerryCanPicked == false)
        {
            jerryCanPicked = true;

            //fuel = 100f;
        }
        if (collider.gameObject.CompareTag("A_JerryCan") && jerryCanPicked == false)
        {
            jerryCanPicked = true;

            //fuel = 100f;
        }

        if (collider.gameObject.CompareTag("LevelEnd"))
        {
            isThatLevel2 = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            //startButtonS.StartLevel2();

        }
    }

    IEnumerator PlayerColliderOn()
    {
        playerPos_4z.z = Player.transform.position.z + 4.2f;
        //playerBoxCollider.enabled = true;
        //Debug.Log("Toimiiko?");
        yield return new WaitUntil(() => Player.transform.position.z >= playerPos_4z.z);
        playerCollide = false;
        playersBoxCollider.enabled = true;
        /*WheelColliders[0].enabled = true;
        WheelColliders[1].enabled = true;
        WheelColliders[2].enabled = true;
        WheelColliders[3].enabled = true;*/
        SphereCollider.enabled = true;
        isPlayerMoving = true;
        //playerColor.playerRenderer.material.color = playerColor.playerNormalColor;
        //playerColor.playerRenderer.material = playerColor.playerNormalColorMaterial;
        //playerColor.playerRenderer.material.SetColor("_BaseColor", playerColor.playerNormalColor);
        var block = new MaterialPropertyBlock();
        block.SetColor("_BaseColor", playerColor.playerNormalColor);
        playerColor.playerRenderer.SetPropertyBlock(block);
    }
}