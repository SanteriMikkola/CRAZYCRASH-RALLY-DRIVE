using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private GameObject Sphere;
    private Rigidbody rB;

    private GameObject Player;
    private GameObject Kamera;
    private CarCollider carCollider;
    private GameObject startButtonB;
    private StartButton startButtonS;
    public GameObject ScoreNumText;
    private ScoreControll scoreControll;

    private GameObject playerRotateF;
    private GameObject playerRotateF_A;
    private GameObject frontCcollider;
    private MapControll mapControll;

    public GameObject MoneyScreen;
    private MoneyScreen moneyScreenS;

    public GameObject FuelMeter;
    private Fuel_Controll fuelControll;

    private GameObject fuelHelper;

    public GameObject HealthBar;
    private HP_Controll hpControll;

    private GameObject startTreeDestroyer;
    private StartTrees startTreesS;

    private GameObject MenuController;
    private MenuController menuController;
    private GameObject Cars;

    public GameObject Garage;
    private GarageControll garageControll;

    public float forwardSpeed = 2f;
    public float targetSpeed = 2f;
    //public float maxSpeed = 50f;
    public float turnStrenght = 90f;
    public float turnInput;

    private GameObject leftFrontWheelGameOb, rightFrontWheelGameOb;
    private Transform leftFrontWheel, rightFrontWheel;
    public float wheelTurn = 30f;

    public bool maxTurn = false;
    public bool IsThatFirstStart = true;
    //[HideInInspector]
    public bool IsTutorialEnded = false;
    //[HideInInspector]
    public bool PposChanget = true;
    public bool turnLock = false;
    public bool resetPposChanget = false;


    [HideInInspector]
    public bool wheelsReady = false;

    private float maxinumRotationL;
    private float maxinumRotationR;

    private float moveSpeed;

    private Vector3 aloitusTienLoppu;
    private Vector3 aavikonLoppu;

    //private float 

    // Start is called before the first frame update
    void Start()
    {

        playerRotateF = GameObject.Find("playerRotationF");
        playerRotateF_A = GameObject.Find("playerRotationF_A");
        Kamera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");
        Sphere = GameObject.Find("Sphere");
        fuelHelper = GameObject.FindGameObjectWithTag("fuelHelper");
        /*leftFrontWheelGameOb = GameObject.Find("LeftFrontWheel");
        rightFrontWheelGameOb = GameObject.Find("RightFrontWheel");
        leftFrontWheel = leftFrontWheelGameOb.GetComponent<Transform>();
        rightFrontWheel = rightFrontWheelGameOb.GetComponent<Transform>();*/
        rB = Sphere.GetComponent<Rigidbody>();
        startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();
        carCollider = Player.GetComponent<CarCollider>();
        scoreControll = ScoreNumText.GetComponent<ScoreControll>();
        fuelControll = FuelMeter.GetComponent<Fuel_Controll>();
        hpControll = HealthBar.GetComponent<HP_Controll>();
        //MoneyScreen = GameObject.Find("MoneyScreen");
        moneyScreenS = MoneyScreen.GetComponent<MoneyScreen>();

        frontCcollider = GameObject.Find("FrontCollider");
        mapControll = frontCcollider.GetComponent<MapControll>();
        startTreeDestroyer = GameObject.Find("StarTreeDestroyer");
        startTreesS = startTreeDestroyer.GetComponent<StartTrees>();
        MenuController = GameObject.Find("MenuController");
        menuController = MenuController.GetComponent<MenuController>();
        garageControll = Garage.GetComponent<GarageControll>();

        rB.transform.parent = null;

        aloitusTienLoppu = new Vector3(0f, 0f, 17.5f);
        aavikonLoppu = new Vector3(0f, 400f, 125.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (garageControll.changeCarColor == false && wheelsReady == false)
        {

            leftFrontWheelGameOb = GameObject.Find("LeftFrontWheel");
            rightFrontWheelGameOb = GameObject.Find("RightFrontWheel");
            leftFrontWheel = leftFrontWheelGameOb.GetComponent<Transform>();
            rightFrontWheel = rightFrontWheelGameOb.GetComponent<Transform>();
            wheelsReady = true;
        }

        forwardSpeed = targetSpeed;
        Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);
        //Kamera.transform.Translate(Vector3.forward * Time.deltaTime * 3.6f, Space.World);
        maxinumRotationL = 322f;
        maxinumRotationR = 38f;
        //transform.position = rB.transform.position;

        /*if (menuController.isThatGarage == true)
        {
            Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
        }*/

        if (carCollider.isPlayerDead)
        {
            carCollider.playersBoxCollider.enabled = false;
            targetSpeed = 2f;
            turnInput = 0f;
            forwardSpeed = 0f;
            //moneyScreenS.M_ScreenOpen();

            if (moneyScreenS.CloseScreen == true)
            {
                mapControll.PressedGiveUp();
                //turnInput = 0f;
                carCollider.isEstePosRandomized = false;
                carCollider.reback_Obs = true;
                carCollider.isThatLevel2 = false;
                carCollider.isThatMT = false;
                //Debug.Log("toimiiko?");
                PposChanget = false;
                var boxCol = fuelHelper.GetComponent<BoxCollider>();
                boxCol.enabled = true;
                Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
                carCollider.playersBoxCollider.enabled = true;
                IsTutorialEnded = false;
                /*Vector3 targetPoint = (playerRotateF.transform.position);
                Player.transform.LookAt(targetPoint);*/
                rB.transform.position = new Vector3(0f, 0.6059999f, 0.4799957f);
                Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);

                if (transform.localRotation.eulerAngles.y != 0f)
                {
                    /*if (convertedTinput == false)
                    {
                        turnInput = turnInput * -1f;
                        convertedTinput = true;
                    }*/

                    Player.transform.Rotate(0, (transform.localRotation.eulerAngles.y * -1), 0f);
                    //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, (transform.localRotation.eulerAngles.y * -1) * Time.deltaTime, 0f));
                }
                Vector3 targetPoint = (playerRotateF.transform.position);
                Player.transform.LookAt(targetPoint);

                //startButtonS.GameStartForMapControll = true;
                resetPposChanget = true;
                startTreesS.ActiveS_Rocks();
                startTreesS.ActiveS_Trees();
                scoreControll.numBer = 0;
                StartCoroutine(fuelControll.JerryCanReverseFullHealth());
                hpControll.HealthPointsScrollBar.value = 0f;
                //carCollider.osuma = 0;
                startButtonS.GiveUp();
                mapControll.isGiveUp = false;
                //carCollider.isPlayerDead = false;
                carCollider.AfterPlayerDead();
                moneyScreenS.CloseScreen = false;
            }

        }

        if (mapControll.isGamePaused == true)
        {
            carCollider.playersBoxCollider.enabled = false;
            forwardSpeed = 0f;
            turnInput = 0f;
        }

        if (mapControll.isGiveUp == true)
        {
            turnInput = 0f;
            carCollider.isEstePosRandomized = false;
            carCollider.reback_Obs = true;
            carCollider.isThatLevel2 = false;
            carCollider.isThatMT = false;
            mapControll.CposChanget = true;
            //mapControll.GiveUpMapController();
            //Debug.Log("toimiiko?");
            PposChanget = false;
            var boxCol = fuelHelper.GetComponent<BoxCollider>();
            boxCol.enabled = true;
            Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
            carCollider.playersBoxCollider.enabled = true;
            IsTutorialEnded = false;
            /*Vector3 targetPoint = (playerRotateF.transform.position);
            Player.transform.LookAt(targetPoint);*/
            rB.transform.position = new Vector3(0f, 0.6059999f, 0.4799957f);
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);

            if (transform.localRotation.eulerAngles.y != 0f)
            {
                /*if (convertedTinput == false)
                {
                    turnInput = turnInput * -1f;
                    convertedTinput = true;
                }*/

                Player.transform.Rotate(0, (transform.localRotation.eulerAngles.y * -1), 0f);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, (transform.localRotation.eulerAngles.y * -1) * Time.deltaTime, 0f));
            }
            Vector3 targetPoint = (playerRotateF.transform.position);
            Player.transform.LookAt(targetPoint);

            //startButtonS.GameStartForMapControll = true;
            resetPposChanget = true;
            startTreesS.ActiveS_Rocks();
            startTreesS.ActiveS_Trees();
            scoreControll.numBer = 0;
            StartCoroutine(fuelControll.JerryCanReverseFullHealth());
            hpControll.HealthPointsScrollBar.value = 0f;
            carCollider.osuma = 0;
            carCollider.safesPicked = 0;
            startButtonS.GiveUp();
            mapControll.isGiveUp = false;
        }

        if (carCollider.isThatMT == true && PposChanget == true && carCollider.isThatLevel2 == false && carCollider.reback_Obs == false)
        {
            Player.transform.position = new Vector3(0f, 800.986f, -212.5f);
            rB.transform.position = new Vector3(0f, 800.948f, -31f);
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);
            //startButtonS.GameStartForMapControll = true;
            PposChanget = false;
            resetPposChanget = false;
            startTreesS.reseted = false;
        }

        if (carCollider.isThatLevel2 == true && PposChanget == false && carCollider.isThatMT == false && carCollider.reback_Obs == false)
        {
            Player.transform.position = new Vector3(0f, 400.633f, -1.024994f);
            rB.transform.position = new Vector3(0f, 400.595f, 0.4799957f);
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);
            //startButtonS.GameStartForMapControll = true;
            PposChanget = true;
        }
        if (carCollider.isThatLevel2 == false && PposChanget == true && carCollider.isThatMT == false && carCollider.reback_Obs == true && resetPposChanget == false)
        {
            //Debug.Log("toimiiko?");
            PposChanget = false;
            Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
            IsTutorialEnded = false;
            /*Vector3 targetPoint = (playerRotateF.transform.position);
            Player.transform.LookAt(targetPoint);*/
            rB.transform.position = new Vector3(0f, 0.6059999f, 0.4799957f);
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);

            if (transform.localRotation.eulerAngles.y != 0f)
            {
                /*if (convertedTinput == false)
                {
                    turnInput = turnInput * -1f;
                    convertedTinput = true;
                }*/

                Player.transform.Rotate(0, (transform.localRotation.eulerAngles.y * -1), 0f);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, (transform.localRotation.eulerAngles.y * -1) * Time.deltaTime, 0f));
            }

            //startButtonS.GameStartForMapControll = true;
            resetPposChanget = true;
        }
        if (resetPposChanget == true)
        {
            PposChanget = true;
        }

        if (carCollider.playerCollide == true && carCollider.isPlayerDead == false)
        {
            carCollider.isPlayerMoving = false;
            //playerGotL = true;
            forwardSpeed = forwardSpeed / 2f;
            //rb.AddForce(stuckForce, ForceMode.Impulse);
        }

        if (/*turnLock == true &&*/ IsTutorialEnded == false)
        {
            turnInput = 0;
            /*if (transform.localRotation.eulerAngles.y != 0f)
            {
                if (convertedTinput == false)
                {
                    turnInput = turnInput * -1f;
                    convertedTinput = true;
                }

                Player.transform.Rotate(0, (transform.localRotation.eulerAngles.y * -1), 0f);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, (transform.localRotation.eulerAngles.y * -1) * Time.deltaTime, 0f));
            }*/
        }

        if (IsTutorialEnded == true && turnLock == false && mapControll.isGamePaused == false)
        {
            turnInput = Input.GetAxis("Horizontal");
        }


        if (maxTurn == false)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime, 0f));
            if (transform.localRotation.eulerAngles.y > maxinumRotationR && transform.localRotation.eulerAngles.y < maxinumRotationL)
            {
                maxTurn = true;
            }
        }
        if (maxTurn == true)
        {
            if (transform.localRotation.eulerAngles.y < 180f && transform.localRotation.eulerAngles.y > 38f)
            {
                /*if (transform.localRotation.eulerAngles.y < 180f && transform.localRotation.eulerAngles.y > 35f)
                {
                    /*if (transform.localRotation.eulerAngles.y < 180f && transform.localRotation.eulerAngles.y > 35f)
                    {*/
                /*if (transform.localRotation.eulerAngles.y < 180f && transform.localRotation.eulerAngles.y > 40f)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, -130f * Time.deltaTime, 0f));
                }*/
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, -120f * Time.deltaTime, 0f));
                //}
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, -3000f * Time.deltaTime, 0f));
                //}
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, -90f * Time.deltaTime, 0f));
                maxTurn = false;
            }
            if (transform.localRotation.eulerAngles.y > 180f && transform.localRotation.eulerAngles.y < 322f)
            {
                /*if (transform.localRotation.eulerAngles.y > 180f && transform.localRotation.eulerAngles.y < 325f)
                {
                    /*if (transform.localRotation.eulerAngles.y > 180f && transform.localRotation.eulerAngles.y < 335f)
                    {*/
                /*if (transform.localRotation.eulerAngles.y > 180f && transform.localRotation.eulerAngles.y < 320f)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 130f * Time.deltaTime, 0f));
                }*/
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 120f * Time.deltaTime, 0f));
                //}
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 3000f * Time.deltaTime, 0f));
                //}
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 90f * Time.deltaTime, 0f));
                maxTurn = false;
            }
            /*if (transform.localRotation.eulerAngles.y < maxinumRotationR && transform.localRotation.eulerAngles.y > maxinumRotationL)
            {
                maxTurn = false;
            }*/
        }

        if (garageControll.isThatOldCar == false && garageControll.isThatCar3 == false)
        {
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), rightFrontWheel.localRotation.eulerAngles.z);

            var defaultSize = new Vector3(0.9104571f, 0.6673748f, 2.708558f);
            carCollider.playersBoxCollider.size = new Vector3(defaultSize.x, defaultSize.y, defaultSize.z);

            var defaultCenter = new Vector3(0.0009245872f, 0.5299164f, 0.26f);
            carCollider.playersBoxCollider.center = new Vector3(defaultCenter.x, defaultCenter.y, defaultCenter.z);
        }
        if (garageControll.isThatOldCar == true && garageControll.isThatCar3 == false)
        {
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, ((turnInput * wheelTurn) + 90f), leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, ((turnInput * wheelTurn) + 90f), rightFrontWheel.localRotation.eulerAngles.z);

            var car2Size = new Vector3(0.9104571f, 0.6829547f, 2.432917f);
            carCollider.playersBoxCollider.size = new Vector3(car2Size.x, car2Size.y, car2Size.z);

            var car2Center = new Vector3(0.0009245872f, 0.5221265f, 0.3230453f);
            carCollider.playersBoxCollider.center = new Vector3(car2Center.x, car2Center.y, car2Center.z);
        }
        if (garageControll.isThatOldCar == false && garageControll.isThatCar3 == true)
        {
            leftFrontWheel.localRotation = Quaternion.Euler((turnInput * (wheelTurn * -1f)), leftFrontWheel.localRotation.eulerAngles.y, leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler((turnInput * wheelTurn), rightFrontWheel.localRotation.eulerAngles.y, rightFrontWheel.localRotation.eulerAngles.z);

            var car3Size = new Vector3(0.7489346f, 0.5150772f, 1.597193f);
            carCollider.playersBoxCollider.size = new Vector3(car3Size.x, car3Size.y, car3Size.z);

            var car3Center = new Vector3(-0.003241241f, 0.3841397f, 0.625173f);
            carCollider.playersBoxCollider.center = new Vector3(car3Center.x, car3Center.y, car3Center.z);
        }


    }

    private void FixedUpdate()
    {
        if (startButtonS.IsGameStarted == true)
        {
            rB.AddForce(transform.forward * forwardSpeed * 1000f);
            transform.position = rB.transform.position;
            if (Player.transform.position.z >= aloitusTienLoppu.z && Player.transform.position.y < aavikonLoppu.y)
            {
                IsTutorialEnded = true;
                turnLock = false;
            }
            if (Player.transform.position.z >= aavikonLoppu.z && Player.transform.position.y >= aavikonLoppu.y)
            {
                //turnLock = true;
                //Vector3 targetPoint = (playerRotateF_A.transform.position);
                //Player.transform.LookAt(targetPoint);
            }
        }
    }

    private void PlayerPosCheck()
    {

    }
}
