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
    private GameObject ScoreNumText;
    private ScoreControll scoreControll;

    private GameObject playerRotateF;

    public float forwardSpeed = 2f;
    //public float maxSpeed = 50f;
    public float turnStrenght = 90f;
    public float turnInput;

    private GameObject leftFrontWheelGameOb, rightFrontWheelGameOb;
    private Transform leftFrontWheel, rightFrontWheel;
    public float wheelTurn = 25f;

    public bool maxTurn = false;
    public bool IsThatFirstStart = true;
    //[HideInInspector]
    public bool IsTutorialEnded = false;
    [HideInInspector]
    public bool PposChanget = false;

    private float maxinumRotationL;
    private float maxinumRotationR;

    private float moveSpeed;

    private Vector3 aloitusTienLoppu;

    // Start is called before the first frame update
    void Start()
    {

        playerRotateF = GameObject.Find("playerRotationF");
        Kamera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");
        Sphere = GameObject.Find("Sphere");
        leftFrontWheelGameOb = GameObject.Find("LeftFrontWheel");
        rightFrontWheelGameOb = GameObject.Find("RightFrontWheel");
        leftFrontWheel = leftFrontWheelGameOb.GetComponent<Transform>();
        rightFrontWheel = rightFrontWheelGameOb.GetComponent<Transform>();
        rB = Sphere.GetComponent<Rigidbody>();
        startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();
        carCollider = Player.GetComponent<CarCollider>();
        rB.transform.parent = null;

        aloitusTienLoppu = new Vector3(0f, 0f, 17.5f);
    }

    // Update is called once per frame
    void Update()
    {
        forwardSpeed = 2f;
        Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);
        //Kamera.transform.Translate(Vector3.forward * Time.deltaTime * 3.6f, Space.World);
        maxinumRotationL = 322f;
        maxinumRotationR = 38f;
        //transform.position = rB.transform.position;

        if (carCollider.isThatLevel2 == true && PposChanget == false)
        {
            Player.transform.position = new Vector3(0f, 400.633f, -1.024994f);
            rB.transform.position = new Vector3(0f, 400.595f, 0.4799957f);
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);
            //startButtonS.GameStartForMapControll = true;
            PposChanget = true;
        }
        if (carCollider.isThatLevel2 == false && PposChanget == true)
        {
            Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
            rB.transform.position = new Vector3(0f, 0.6059999f, 0.4799957f);
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);
            //startButtonS.GameStartForMapControll = true;
            PposChanget = false;
        }

        if (carCollider.playerCollide == true)
        {
            carCollider.isPlayerMoving = false;
            //playerGotL = true;
            forwardSpeed = forwardSpeed - 1f;
            //rb.AddForce(stuckForce, ForceMode.Impulse);
        }

        if (IsTutorialEnded == true)
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

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), rightFrontWheel.localRotation.eulerAngles.z);


    }

    private void FixedUpdate()
    {
        if (startButtonS.IsGameStarted == true)
        {
            rB.AddForce(transform.forward * forwardSpeed * 1000f);
            transform.position = rB.transform.position;
            if (Player.transform.position.z >= aloitusTienLoppu.z)
            {
                IsTutorialEnded = true;
            }
        }
    }
}
