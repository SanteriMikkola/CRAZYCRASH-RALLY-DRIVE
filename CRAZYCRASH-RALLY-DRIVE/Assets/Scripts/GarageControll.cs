using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageControll : MonoBehaviour
{
    public GameObject[] Cars;
    public Color[] Colors;
    public GameObject[] Hats;

    private GameObject PlayersChild;
    private GameObject Wheels;
    private GameObject playerRotateF;
    private GameObject garageCar2;

    private GameObject Player;
    private GameObject Level1;
    public MeshRenderer playerRenderer;
    private CarController carController;
    private PlayerColor playerColor;

    public Material defaultCarMat;
    public Material oldCarMat;
    private Material matChanger;

    public MeshFilter playerMF;
    public Mesh defaultMF;
    public Mesh oldMF;

    public int index = 0;
    public int a = 0;

    public bool pressedRight, pressedLeft,
                pressedCarB, pressedPaintB,
                pressedHatB;

    private bool indexBLock = false;

    private bool matSetUp = true;

    private bool carsFinded = false;

    [HideInInspector]
    public bool isThatOldCar = false;

    [HideInInspector]
    public bool changeCarColor = false;

    void Start()
    {
        Player = GameObject.Find("Player");
        Level1 = GameObject.Find("Level1");
        garageCar2 = GameObject.Find("GarageCar2");

        carController = Player.GetComponent<CarController>();
        playerColor = Player.GetComponent<PlayerColor>();
        Cars = GameObject.FindGameObjectsWithTag("Car");

        Wheels = GameObject.FindGameObjectWithTag("Wheel");
        PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");

        playerRotateF = GameObject.Find("playerRotationF");

        pressedRight = false;
        pressedLeft = false;
        pressedCarB = true;
        pressedPaintB = false;
        pressedHatB = false;

        garageCar2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Cars.Length >= 2)
        {
            carsFinded = true;
        }

        if (matSetUp == true && carsFinded == true)
        {
            defaultMF = Cars[a].GetComponent<MeshFilter>().mesh;
            a++;
            oldMF = Cars[a].GetComponent<MeshFilter>().mesh;
            a = 0;

            defaultCarMat = Cars[a].GetComponent<MeshRenderer>().material;
            a++;
            oldCarMat = Cars[a].GetComponent<MeshRenderer>().material;
            //Debug.Log("A");
            matSetUp = false;
        }

        if (pressedRight == true && pressedLeft == false && indexBLock == false)
        {
            if (index == 0)
            {
                index++;
                //Cars[index].SetActive(true);
                ChangeChoose();
            }

            indexBLock = true;
        }
        if (pressedRight == false && pressedLeft == true && indexBLock == true)
        {
            if (index >= 1)
            {
                index--;
                //Cars[index].SetActive(true);
                ChangeChoose();
            }

            indexBLock = false;
        }
    }

    private void ChangeChoose()
    {
        if (pressedCarB == true && pressedPaintB == false && pressedHatB == false)
        {
            switch (index)
            {
                case 0: //defaltcar
                    {
                        isThatOldCar = false;
                        playerColor.changeNcolor = false;
                        changeCarColor = true;

                        /*playerMF.mesh = defaultMF;
                        playerRenderer.material = defaultCarMat;

                        PlayersChild.transform.position = new Vector3(0f, 0.93f, -1.4f);

                        Debug.Log("defaltcar");

                        PlayersChild.transform.Rotate(0f, 0f, 180f);*/

                        /*PlayersChild.SetActive(false);
                        Player.transform.DetachChildren();
                        Player.transform.SetParent(gameObject.transform);
                        Player.transform.position = new Vector3(5.036f, 0.796f, -1.247f);*/
                        //playerRenderer.material = 
                        /*Cars[index].transform.tag = "EquippedCar";
                        Cars[index].transform.SetParent(Player.transform);
                        Player.transform.SetParent(Level1.transform);
                        Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
                        Cars[index].transform.position = new Vector3(0f, 0.9f, -1.2f);  // 0.271f   -0.365f
                        Vector3 targetPoint = (playerRotateF.transform.position);
                        Cars[index].transform.LookAt(targetPoint);
                        Cars[index].transform.Rotate(-90f, 0f, 0f);*/
                        changeCarColor = false;
                        carController.wheelsReady = false;
                    }
                    break;
                case 1: //oldcar
                    {
                        isThatOldCar = true;
                        playerColor.changeNormalcolor = false;
                        changeCarColor = true;

                        /*playerMF.mesh = oldMF;
                        playerRenderer.material = oldCarMat;

                        PlayersChild.transform.position = new Vector3(0f, 1f, -0.32f);

                        Debug.Log("oldcar");

                        PlayersChild.transform.Rotate(0f, 0f, -180f);*/

                        /*PlayersChild.SetActive(false);
                        Player.transform.DetachChildren();
                        Player.transform.SetParent(gameObject.transform);
                        Player.transform.position = new Vector3(5.036f, 0.796f, -1.247f);
                        Cars[index].transform.tag = "EquippedCar";
                        Cars[index].transform.SetParent(Player.transform);
                        Player.transform.SetParent(Level1.transform);
                        Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
                        Cars[index].transform.position = new Vector3(0f, 1f, -0.5f);  // 0.271f   -0.365f
                        Vector3 targetPoint = (playerRotateF.transform.position);
                        Cars[index].transform.LookAt(targetPoint);
                        Cars[index].transform.Rotate(-90f, 0f, -180f);*/
                        changeCarColor = false;
                        carController.wheelsReady = false;
                    }
                    break;
            }


        }
        if (pressedCarB == false && pressedPaintB == true && pressedHatB == false)
        {

        }
        if (pressedCarB == false && pressedPaintB == false && pressedHatB == true)
        {

        }
    }

    public void PressedGBackButton()
    {
        /*for (int i = 0; i < Cars.Length; i++)
        {
            Cars[i].SetActive(false);
        }*/
    }

    public void PressedCarB()
    {
        pressedCarB = true;
        pressedPaintB = false;
        pressedHatB = false;
    }

    public void PressedPaintB()
    {
        pressedPaintB = true;
        pressedCarB = false;
        pressedHatB = false;
    }

    public void PressedHatB()
    {
        pressedHatB = true;
        pressedCarB = false;
        pressedPaintB = false;
    }

    public void PressedRightA()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;
    }

    public void PressedLeftA()
    {
        //Cars[index].SetActive(false);
        pressedLeft = true;
        pressedRight = false;
        indexBLock = true;
    }
}
