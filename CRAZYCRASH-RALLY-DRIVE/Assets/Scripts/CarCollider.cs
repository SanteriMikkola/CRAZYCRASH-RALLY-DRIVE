using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarCollider : MonoBehaviour
{
    private CarController carController;
    private PlayerColor playerColor;
    private GameObject Player;
    private GameObject Kamera;
    private GameObject SpheRe;
    private GameObject playerRotateF;
    //private GameObject[] Wheels;
    public GameObject FuelMeter;
    private Fuel_Controll fuelControll;

    public GameObject ScoreNumText;
    private ScoreControll scoreControll;

    private GameObject fuelHelper;

    private GameObject startMenuMoneyT;
    private TextMeshProUGUI startMenuMoneyT_Text;

    private GameObject fMapCollider;
    private MapControll mapControllS;

    [HideInInspector]
    public BoxCollider playersBoxCollider;
    //public CapsuleCollider[] WheelColliders;
    private SphereCollider SphereCollider;

    public bool playerCollide = false;
    public bool isPlayerDead = false;

    public bool isPlayerMoving = true;
    public bool toolBoxPicked = false;
    public bool jerryCanPicked = false;
    public bool safePicked = false;
    [HideInInspector]
    public bool isThatFullHealthReverse;
    [HideInInspector]
    public bool isThatLevel2 = false;
    [HideInInspector]
    public bool reback_Obs = false;
    [HideInInspector]
    public bool isThatMT = false;

    [HideInInspector]
    public bool isEstePosRandomized = false;

    public int osuma = 0;

    public float fuel = 100f;

    public int maxOsumat = 5;

    public int safesPicked = 0;

    public int money = 0;

    [HideInInspector]
    public int moneyInSafe = 0;

    [HideInInspector]
    public int moneyPerRound = 0;
    [HideInInspector]
    public int moneyPerRound2 = 0;

    public int moneyRandomer;

    [HideInInspector]
    public int index = 0;

    [HideInInspector]
    public bool moneyRandomized = false;

    private Vector3 playerPos_4z;

    public bool deadOrNot = false;

    private bool scoreGet = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        //Wheels = GameObject.FindGameObjectsWithTag("Wheel");
        SpheRe = GameObject.Find("Sphere");
        playerRotateF = GameObject.Find("playerRotationF");
        carController = Player.GetComponent<CarController>();
        playersBoxCollider = Player.GetComponent<BoxCollider>();
        SphereCollider = SpheRe.GetComponent<SphereCollider>();
        fuelControll = FuelMeter.GetComponent<Fuel_Controll>();

        scoreControll = ScoreNumText.GetComponent<ScoreControll>();

        fuelHelper = GameObject.FindGameObjectWithTag("fuelHelper");

        playerColor = Player.GetComponent<PlayerColor>();
        Kamera = GameObject.Find("Main Camera");

        startMenuMoneyT = GameObject.Find("startMenuMoneyT");
        startMenuMoneyT_Text = startMenuMoneyT.GetComponent<TextMeshProUGUI>();

        fMapCollider = GameObject.Find("FrontCollider");
        mapControllS = fMapCollider.GetComponent<MapControll>();

    }

    public void Update()
    {
        startMenuMoneyT_Text.text = money.ToString();
        /*if (playerCollide == true)
        {
            isPlayerMoving = false;
            //playerGotL = true;
            carController.forwardSpeed = carController.forwardSpeed - 1f;
            //rb.AddForce(stuckForce, ForceMode.Impulse);
        }*/

        if (isPlayerDead == true)
        {
            MoneyRandomize();
            ScoreMoney();
        }
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
            if (osuma == maxOsumat)
            {
                isPlayerDead = true;
                /*gameObject.SetActive(false);
                Kamera.SetActive(false);*/
                playerCollide = false;
                moneyRandomized = false;
                scoreGet = false;
            }

            if (osuma != maxOsumat && deadOrNot == false)
            {
                StartCoroutine(PlayerColliderOn());
            }


            /*if (isPlayerDead)
            {
                playerCollide = false;
                playersBoxCollider.enabled = true;

                SphereCollider.enabled = true;
                isPlayerMoving = true;

                var block = new MaterialPropertyBlock();
                block.SetColor("_BaseColor", playerColor.playerNormalColor);
                playerColor.playerRenderer.SetPropertyBlock(block);
                isPlayerDead = false;
            }*/

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
            if (osuma == maxOsumat)
            {
                isPlayerDead = true;
                /*gameObject.SetActive(false);
                Kamera.SetActive(false);*/
                playerCollide = false;
                moneyRandomized = false;
            }

            if (osuma != maxOsumat && deadOrNot == false)
            {
                StartCoroutine(PlayerColliderOn());
            }
            /*if (isPlayerDead)
            {
                playerCollide = false;
                playersBoxCollider.enabled = true;

                SphereCollider.enabled = true;
                isPlayerMoving = true;

                var block = new MaterialPropertyBlock();
                block.SetColor("_BaseColor", playerColor.playerNormalColor);
                playerColor.playerRenderer.SetPropertyBlock(block);
                isPlayerDead = false;
            }*/
        }
        /*if (osuma == maxOsumat)
        {
            isPlayerDead = true;
            gameObject.SetActive(false);
            Kamera.SetActive(false);
            playerCollide = false;
            moneyRandomized = false;
        }*/

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
            isThatLevel2 = false;
            reback_Obs = false;
            isThatMT = true;

            //StartCoroutine(fuelControll.JerryCanReverseFullHealth());

            mapControllS.highwayIdentifier = true;

            carController.targetSpeed += 0.25f;

            /*reback_Obs = false;
            isThatLevel2 = true;*/
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            //startButtonS.StartLevel2();

        }

        if (collider.gameObject.CompareTag("LevelEnd2"))
        {
            //Debug.Log("osuko?");
            isEstePosRandomized = false;
            reback_Obs = true;
            isThatLevel2 = false;
            isThatMT = false;

            mapControllS.highwayIdentifier = false;

            carController.targetSpeed += 0.25f;

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            //startButtonS.StartLevel2();

        }

        if (collider.gameObject.CompareTag("MoottoriTie"))
        {
            isEstePosRandomized = false;
            reback_Obs = false;
            isThatLevel2 = true;
            isThatMT = false;

            mapControllS.highwayIdentifier = false;

            carController.targetSpeed += 0.25f;

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            //startButtonS.StartLevel2();

        }

        if (collider.gameObject.CompareTag("RotateHelper"))
        {
            Vector3 targetPoint = (playerRotateF.transform.position);
            Player.transform.LookAt(targetPoint);
        }
        if (collider.gameObject.CompareTag("fuelHelper"))
        {
            StartCoroutine(fuelControll.JerryCanReverseFullHealth());

            var boxCol = fuelHelper.GetComponent<BoxCollider>();

            boxCol.enabled = false;
        }

        if (collider.gameObject.CompareTag("Safe"))
        {
            safePicked = true;
            safesPicked++;
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
        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", playerColor.playerNormalColor);
        playerColor.playerRenderer.SetPropertyBlock(block);
    }

    private void MoneyRandomize()
    {
        if (!moneyRandomized)
        {
            moneyPerRound = 0;
            while (index != safesPicked)
            {
                moneyRandomer = Random.Range(0, 101);

                if (moneyRandomer >= 0 && moneyRandomer <= 35)
                {
                    moneyInSafe = 500;
                    moneyPerRound += moneyInSafe;
                    Debug.Log("500");
                }
                else if (moneyRandomer >= 36 && moneyRandomer <= 55)
                {
                    moneyInSafe = 750;
                    moneyPerRound += moneyInSafe;
                    Debug.Log("750");
                }
                else if (moneyRandomer >= 56 && moneyRandomer <= 75)
                {
                    moneyInSafe = 1000;
                    moneyPerRound += moneyInSafe;
                    Debug.Log("1000");
                }
                else if (moneyRandomer >= 76 && moneyRandomer <= 90)
                {
                    moneyInSafe = 1250;
                    moneyPerRound += moneyInSafe;
                    Debug.Log("1250");
                }
                else if (moneyRandomer >= 91 && moneyRandomer <= 100)
                {
                    moneyInSafe = 1500;
                    moneyPerRound += moneyInSafe;
                    Debug.Log("1500");
                }

                index++;
            }
            moneyRandomized = true;
        }
        //safesPicked = 0;
        //index = 0;
    }

    private void ScoreMoney()
    {
        if (!scoreGet)
        {
            moneyPerRound2 = 0;

            int scoreMoney = (scoreControll.numBer / 50);

            //Debug.Log(scoreControll.numBer);

            moneyPerRound2 += scoreMoney;

            scoreGet = true;
        }
    }

    public void AfterPlayerDead()
    {
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
        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", playerColor.playerNormalColor);
        playerColor.playerRenderer.SetPropertyBlock(block);
        deadOrNot = true;
        isPlayerDead = false;
        playerCollide = false;
        osuma = 0;
    }
}