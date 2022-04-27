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
    private GameObject garageCar1;
    private GameObject garageCar2;
    private GameObject garageCar3;

    private GameObject p_Car1;
    private GameObject p_Car2;
    private GameObject p_Car3;

    private GameObject Player;
    private GameObject Level1;
    public MeshRenderer playerRenderer;
    private CarController carController;
    private PlayerColor playerColor;
    private CarCollider carCollider;

    public Material defaultCarMat;
    public Material oldCarMat;
    private Material matChanger;

    public MeshFilter playerMF;
    public Mesh defaultMF;
    public Mesh oldMF;

    public int index = 0;
    public int colorIndex = 0;
    public int a = 0;

    public bool pressedRight, pressedLeft,
                pressedCarB, pressedPaintB,
                pressedHatB;

    public GameObject[] PaintArrow;
    public GameObject[] CarArrow;
    public GameObject[] ColorButtons;

    public MeshRenderer garageCarMeshRenderer;

    public Color colorOfCar1;
    public Color colorOfCar2;
    public Color colorOfCar3;

    public bool indexBLock = false;

    private bool matSetUp = true;

    private bool carsFinded = false;

    [HideInInspector]
    public bool isThatOldCar = false;

    [HideInInspector]
    public bool isThatCar3 = false;

    [HideInInspector]
    public bool changeCarColor = false;

    private bool loadData = true;

    void Start()
    {
        Player = GameObject.Find("Player");
        Level1 = GameObject.Find("Level1");
        garageCar1 = GameObject.Find("G_Car1");
        garageCar2 = GameObject.Find("G_Car2");
        garageCar3 = GameObject.Find("G_Car3");

        p_Car1 = GameObject.Find("Car");
        p_Car2 = GameObject.Find("Car2");
        p_Car3 = GameObject.Find("Car3");

        p_Car2.SetActive(false);
        p_Car3.SetActive(false);

        carController = Player.GetComponent<CarController>();
        playerColor = Player.GetComponent<PlayerColor>();
        carCollider = Player.GetComponent<CarCollider>();
        Cars = GameObject.FindGameObjectsWithTag("Car");

        Wheels = GameObject.FindGameObjectWithTag("Wheel");
        PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");

        playerRenderer = PlayersChild.GetComponent<MeshRenderer>();

        playerRotateF = GameObject.Find("playerRotationF");

        pressedRight = false;
        pressedLeft = false;
        pressedCarB = true;
        pressedPaintB = false;
        pressedHatB = false;

        garageCar2.SetActive(false);
        garageCar3.SetActive(false);


        colorOfCar1 = new Color(1, 0, 0, 1);
        //colorOfCar2 = new Color(1, 0, 0, 1);
        //colorOfCar3 = new Color(1, 0, 0, 1);
        colorOfCar2 = new Color(0.03137255f, 0.4117647f, 0.1490196f, 1);
        colorOfCar3 = new Color(0.04313726f, 0.3490196f, 0.4745098f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadData == true)
        {
            carCollider.LoadData();

            if (carCollider.PickedCar == 0)
            {
                p_Car1.SetActive(true);
                p_Car2.SetActive(false);
                p_Car3.SetActive(false);

                garageCar1.SetActive(true);
                garageCar2.SetActive(false);
                garageCar3.SetActive(false);

                CarArrow[0].SetActive(true);
                CarArrow[1].SetActive(true);
                CarArrow[2].SetActive(false);
                CarArrow[3].SetActive(false);
                CarArrow[4].SetActive(false);
                CarArrow[5].SetActive(false);

                ColorButtons[0].SetActive(true);
                ColorButtons[1].SetActive(false);
                ColorButtons[2].SetActive(false);

                PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                playerRenderer = PlayersChild.GetComponent<MeshRenderer>();
                changeCarColor = false;
                carController.wheelsReady = false;

                garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

                var block = new MaterialPropertyBlock();

                block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndexOfCar1]);
                playerRenderer.SetPropertyBlock(block);
                garageCarMeshRenderer.SetPropertyBlock(block);

                colorOfCar1 = Colors[carCollider.colorIndexOfCar1];
                colorOfCar2 = Colors[carCollider.colorIndexOfCar2];
                colorOfCar3 = Colors[carCollider.colorIndexOfCar3];
                playerColor.playerNormalColor = colorOfCar1;
            }
            else if (carCollider.PickedCar == 1)
            {
                p_Car1.SetActive(false);
                p_Car2.SetActive(true);
                p_Car3.SetActive(false);

                garageCar1.SetActive(false);
                garageCar2.SetActive(true);
                garageCar3.SetActive(false);

                CarArrow[0].SetActive(false);
                CarArrow[1].SetActive(false);
                CarArrow[2].SetActive(true);
                CarArrow[3].SetActive(true);
                CarArrow[4].SetActive(false);
                CarArrow[5].SetActive(false);

                ColorButtons[0].SetActive(false);
                ColorButtons[1].SetActive(true);
                ColorButtons[2].SetActive(false);

                PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                playerRenderer = PlayersChild.GetComponent<MeshRenderer>();
                changeCarColor = false;
                carController.wheelsReady = false;

                garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

                var block = new MaterialPropertyBlock();

                block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndexOfCar2]);
                playerRenderer.SetPropertyBlock(block);
                garageCarMeshRenderer.SetPropertyBlock(block);

                colorOfCar1 = Colors[carCollider.colorIndexOfCar1];
                colorOfCar2 = Colors[carCollider.colorIndexOfCar2];
                colorOfCar3 = Colors[carCollider.colorIndexOfCar3];
                playerColor.playerNormalColor = colorOfCar2;
            }
            else if (carCollider.PickedCar == 2)
            {
                p_Car1.SetActive(false);
                p_Car2.SetActive(false);
                p_Car3.SetActive(true);

                garageCar1.SetActive(false);
                garageCar2.SetActive(false);
                garageCar3.SetActive(true);

                CarArrow[0].SetActive(false);
                CarArrow[1].SetActive(false);
                CarArrow[2].SetActive(false);
                CarArrow[3].SetActive(false);
                CarArrow[4].SetActive(true);
                CarArrow[5].SetActive(true);

                ColorButtons[0].SetActive(false);
                ColorButtons[1].SetActive(false);
                ColorButtons[2].SetActive(true);

                PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                playerRenderer = PlayersChild.GetComponent<MeshRenderer>();
                changeCarColor = false;
                carController.wheelsReady = false;

                garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

                var block = new MaterialPropertyBlock();

                block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndexOfCar3]);
                playerRenderer.SetPropertyBlock(block);
                garageCarMeshRenderer.SetPropertyBlock(block);

                colorOfCar1 = Colors[carCollider.colorIndexOfCar1];
                colorOfCar2 = Colors[carCollider.colorIndexOfCar2];
                colorOfCar3 = Colors[carCollider.colorIndexOfCar3];
                playerColor.playerNormalColor = colorOfCar3;
            }

            loadData = false;
        }

        /*if (Cars.Length >= 3)
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
        }*/

        // Change cars
        if (pressedRight == true && pressedLeft == false && indexBLock == false && pressedCarB == true && pressedPaintB == false && pressedHatB == false)
        {
            if (index >= 0)
            {
                index++;
                //Cars[index].SetActive(true);
                ChangeChoose();
            }

            indexBLock = true;
        }
        if (pressedRight == false && pressedLeft == true && indexBLock == true && pressedCarB == true && pressedPaintB == false && pressedHatB == false)
        {
            if (index >= 1)
            {
                index--;
                //Cars[index].SetActive(true);
                ChangeChoose();
            }

            indexBLock = false;
        }

        // Change colors
        if (pressedRight == true && pressedLeft == false && indexBLock == false && pressedCarB == false && pressedPaintB == true && pressedHatB == false)
        {
            if (colorIndex >= 0 && colorIndex < 11)
            {
                colorIndex++;
                //Cars[index].SetActive(true);

                ChangeChoose();
            }

            indexBLock = true;
        }
        if (pressedRight == false && pressedLeft == true && indexBLock == true && pressedCarB == false && pressedPaintB == true && pressedHatB == false)
        {
            if (colorIndex >= 1)
            {
                colorIndex--;
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
                        playerColor.playerNormalColor = colorOfCar1;

                        isThatOldCar = false;
                        isThatCar3 = false;
                        playerColor.changeNcolor = false;
                        changeCarColor = true;

                        carCollider.PickedCar = 0;
                        carCollider.c_isThatOldCar = false;
                        carCollider.c_isThatCar3 = false;

                        carCollider.SaveData();
                        carCollider.LoadData();

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
                        PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                        playerRenderer = PlayersChild.GetComponent<MeshRenderer>();

                        loadData = true;

                        changeCarColor = false;
                        carController.wheelsReady = false;
                    }
                    break;
                case 1: //car2
                    {
                        playerColor.playerNormalColor = colorOfCar2;

                        isThatOldCar = true;
                        isThatCar3 = false;
                        playerColor.changeNormalcolor = false;
                        changeCarColor = true;

                        carCollider.PickedCar = 1;
                        carCollider.c_isThatOldCar = true;
                        carCollider.c_isThatCar3 = false;

                        carCollider.SaveData();
                        carCollider.LoadData();

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
                        PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                        playerRenderer = PlayersChild.GetComponent<MeshRenderer>();

                        loadData = true;

                        changeCarColor = false;
                        carController.wheelsReady = false;
                    }
                    break;
                case 2: //car3
                    {
                        playerColor.playerNormalColor = colorOfCar3;


                        isThatOldCar = false;
                        isThatCar3 = true;
                        playerColor.changeNormalcolor = false;
                        changeCarColor = true;

                        carCollider.PickedCar = 2;
                        carCollider.c_isThatOldCar = false;
                        carCollider.c_isThatCar3 = true;

                        carCollider.SaveData();
                        carCollider.LoadData();

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
                        PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                        playerRenderer = PlayersChild.GetComponent<MeshRenderer>();

                        loadData = true;

                        changeCarColor = false;
                        carController.wheelsReady = false;
                    }
                    break;
            }


        }
        if (pressedCarB == false && pressedPaintB == true && pressedHatB == false)
        {

            /*if (index == 0)
            {
                garageCarMeshRenderer = Cars[index].GetComponent<MeshRenderer>();

                PaintArrow[0].SetActive(true);
                PaintArrow[1].SetActive(true);

                PaintArrow[2].SetActive(false);
                PaintArrow[3].SetActive(false);
                PaintArrow[4].SetActive(false);
                PaintArrow[5].SetActive(false);

                if (colorIndex == 0)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);
                    garageCarMeshRenderer.SetPropertyBlock(block);

                    /*Debug.Log("index: " + index);
                    Debug.Log("colorIndex: " + colorIndex);
                    Debug.Log("Punane");

                }
                else if (colorIndex == 1)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);
                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 2)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);
                    garageCarMeshRenderer.SetPropertyBlock(block);


                }
                else if (colorIndex == 3)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);
                    garageCarMeshRenderer.SetPropertyBlock(block);


                }
                else if (colorIndex == 4)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);
                    garageCarMeshRenderer.SetPropertyBlock(block);


                }
                else if (colorIndex == 5)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);
                    garageCarMeshRenderer.SetPropertyBlock(block);


                }
                else if (colorIndex == 6)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);
                    garageCarMeshRenderer.SetPropertyBlock(block);


                }
                else if (colorIndex == 7)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 8)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 9)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 10)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 11)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }

                colorOfCar1 = Colors[colorIndex];
                playerColor.playerNormalColor = colorOfCar1;
            }

            else if (index == 1)
            {
                garageCarMeshRenderer = Cars[index].GetComponent<MeshRenderer>();

                PaintArrow[2].SetActive(true);
                PaintArrow[3].SetActive(true);

                PaintArrow[0].SetActive(false);
                PaintArrow[1].SetActive(false);
                PaintArrow[4].SetActive(false);
                PaintArrow[5].SetActive(false);

                if (colorIndex == 0)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 1)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 2)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 3)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 4)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 5)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 6)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 7)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 8)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 9)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 10)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 11)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }

                colorOfCar2 = Colors[colorIndex];
                playerColor.playerNormalColor = colorOfCar2;
            }

            else if (index == 2)
            {
                garageCarMeshRenderer = Cars[index].GetComponent<MeshRenderer>();

                PaintArrow[4].SetActive(true);
                PaintArrow[5].SetActive(true);

                PaintArrow[0].SetActive(false);
                PaintArrow[1].SetActive(false);
                PaintArrow[2].SetActive(false);
                PaintArrow[3].SetActive(false);

                if (colorIndex == 0)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 1)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 2)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 3)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 4)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 5)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 6)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 7)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 8)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 9)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 10)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }
                else if (colorIndex == 11)
                {
                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                    playerRenderer.SetPropertyBlock(block);

                    garageCarMeshRenderer.SetPropertyBlock(block);

                }

                colorOfCar3 = Colors[colorIndex];
                playerColor.playerNormalColor = colorOfCar3;
            }*/


            /*switch (index)
            {
                case 0: //defaltcar
                    {
                        garageCarMeshRenderer = Cars[index].GetComponent<MeshRenderer>();

                        PaintArrow[0].SetActive(true);
                        PaintArrow[1].SetActive(true);

                        PaintArrow[2].SetActive(false);
                        PaintArrow[3].SetActive(false);
                        PaintArrow[4].SetActive(false);
                        PaintArrow[5].SetActive(false);

                        if (colorIndex == 0)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);
                            garageCarMeshRenderer.SetPropertyBlock(block);


                        }
                        else if (colorIndex == 1)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);
                            garageCarMeshRenderer.SetPropertyBlock(block);

                            
                        }
                        else if (colorIndex == 2)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);
                            garageCarMeshRenderer.SetPropertyBlock(block);

                            
                        }
                        else if (colorIndex == 3)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);
                            garageCarMeshRenderer.SetPropertyBlock(block);

                            
                        }
                        else if (colorIndex == 4)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);
                            garageCarMeshRenderer.SetPropertyBlock(block);

                            
                        }
                        else if (colorIndex == 5)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);
                            garageCarMeshRenderer.SetPropertyBlock(block);

                            
                        }
                        else if (colorIndex == 6)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);
                            garageCarMeshRenderer.SetPropertyBlock(block);

                            
                        }
                        else if (colorIndex == 7)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 8)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 9)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 10)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 11)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }

                        colorOfCar1 = Colors[colorIndex];
                        playerColor.playerNormalColor = colorOfCar1;
                    }
                    break;
                case 1: //car2
                    {
                        garageCarMeshRenderer = Cars[index].GetComponent<MeshRenderer>();

                        PaintArrow[2].SetActive(true);
                        PaintArrow[3].SetActive(true);

                        PaintArrow[0].SetActive(false);
                        PaintArrow[1].SetActive(false);
                        PaintArrow[4].SetActive(false);
                        PaintArrow[5].SetActive(false);

                        if (colorIndex == 0)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 1)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 2)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 3)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 4)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 5)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 6)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 7)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 8)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 9)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 10)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 11)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }

                        colorOfCar2 = Colors[colorIndex];
                        playerColor.playerNormalColor = colorOfCar2;
                    }
                    break;
                case 2: //car3
                    {
                        garageCarMeshRenderer = Cars[index].GetComponent<MeshRenderer>();

                        PaintArrow[4].SetActive(true);
                        PaintArrow[5].SetActive(true);

                        PaintArrow[0].SetActive(false);
                        PaintArrow[1].SetActive(false);
                        PaintArrow[2].SetActive(false);
                        PaintArrow[3].SetActive(false);

                        if (colorIndex == 0)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 1)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 2)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 3)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 4)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 5)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 6)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 7)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 8)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 9)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 10)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }
                        else if (colorIndex == 11)
                        {
                            var block = new MaterialPropertyBlock();

                            block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
                            playerRenderer.SetPropertyBlock(block);

                            garageCarMeshRenderer.SetPropertyBlock(block);
                            
                        }

                        colorOfCar3 = Colors[colorIndex];
                        playerColor.playerNormalColor = colorOfCar3;
                    }
                    break;
            }*/
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

        PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
        playerRenderer = PlayersChild.GetComponent<MeshRenderer>();

        switch (index)
        {
            case 0: //defaltcar
                {

                    CarArrow[0].SetActive(true);
                    CarArrow[1].SetActive(true);

                    CarArrow[2].SetActive(false);
                    CarArrow[3].SetActive(false);
                    CarArrow[4].SetActive(false);
                    CarArrow[5].SetActive(false);
                }
                break;
            case 1: //car2
                {

                    CarArrow[2].SetActive(true);
                    CarArrow[3].SetActive(true);

                    CarArrow[0].SetActive(false);
                    CarArrow[1].SetActive(false);
                    CarArrow[4].SetActive(false);
                    CarArrow[5].SetActive(false);
                }
                break;
            case 2: //car3
                {

                    CarArrow[4].SetActive(true);
                    CarArrow[5].SetActive(true);

                    CarArrow[0].SetActive(false);
                    CarArrow[1].SetActive(false);
                    CarArrow[2].SetActive(false);
                    CarArrow[3].SetActive(false);
                }
                break;
        }
    }

    public void PressedPaintB()
    {
        pressedPaintB = true;
        pressedCarB = false;
        pressedHatB = false;

        /*switch (index)
        {
            case 0: //defaltcar
                {
                    garageCarMeshRenderer = Cars[index].GetComponent<MeshRenderer>();


                    PaintArrow[0].SetActive(true);
                    PaintArrow[1].SetActive(true);

                    PaintArrow[2].SetActive(false);
                    PaintArrow[3].SetActive(false);
                    PaintArrow[4].SetActive(false);
                    PaintArrow[5].SetActive(false);
                }
                break;
            case 1: //car2
                {
                    garageCarMeshRenderer = Cars[index].GetComponent<MeshRenderer>();

                    PaintArrow[2].SetActive(true);
                    PaintArrow[3].SetActive(true);

                    PaintArrow[0].SetActive(false);
                    PaintArrow[1].SetActive(false);
                    PaintArrow[4].SetActive(false);
                    PaintArrow[5].SetActive(false);
                }
                break;
            case 2: //car3
                {
                    garageCarMeshRenderer = Cars[index].GetComponent<MeshRenderer>();

                    PaintArrow[4].SetActive(true);
                    PaintArrow[5].SetActive(true);

                    PaintArrow[0].SetActive(false);
                    PaintArrow[1].SetActive(false);
                    PaintArrow[2].SetActive(false);
                    PaintArrow[3].SetActive(false);
                }
                break;
        }*/
    }

    public void PressedHatB()
    {
        pressedHatB = true;
        pressedCarB = false;
        pressedPaintB = false;
    }

    public void PressedRightACar1()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;
    }

    public void PressedLeftACar2()
    {
        //Cars[index].SetActive(false);
        pressedLeft = true;
        pressedRight = false;
        indexBLock = true;
    }

    public void PressedRightACar2()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;
    }

    public void PressedLeftACar3()
    {
        //Cars[index].SetActive(false);
        pressedLeft = true;
        pressedRight = false;
        indexBLock = true;
    }

    // ColorArrows
    public void Pressed_R_A_C1_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 1;
        carCollider.colorIndex = 1;

        garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C1_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 0;
        carCollider.colorIndex = 0;

        garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C1_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 2;
        carCollider.colorIndex = 2;

        garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C1_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 0;
        carCollider.colorIndex = 0;

        garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C1_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 3;
        carCollider.colorIndex = 3;

        garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C1_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 1;
        carCollider.colorIndex = 1;

        garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C1_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 4;
        carCollider.colorIndex = 4;

        garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C1_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 2;
        carCollider.colorIndex = 2;

        garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }






    public void Pressed_R_A_C2_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 5;
        carCollider.colorIndex = 5;

        garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C2_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 4;
        carCollider.colorIndex = 4;

        garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C2_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 6;
        carCollider.colorIndex = 6;

        garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C2_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 4;
        carCollider.colorIndex = 4;

        garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C2_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 7;
        carCollider.colorIndex = 7;

        garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C2_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 5;
        carCollider.colorIndex = 5;

        garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    /*public void Pressed_R_A_C2_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 8;

        garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;
    }*/
    public void Pressed_L_A_C2_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 6;
        carCollider.colorIndex = 6;

        garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();

    }





    public void Pressed_R_A_C3_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 9;
        carCollider.colorIndex = 9;

        garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C3_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 8;
        carCollider.colorIndex = 8;

        garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C3_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 10;
        carCollider.colorIndex = 10;

        garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C3_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 8;
        carCollider.colorIndex = 8;

        garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C3_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 11;
        carCollider.colorIndex = 11;

        garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C3_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 9;
        carCollider.colorIndex = 9;

        garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C3_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 11;
        carCollider.colorIndex = 11;

        garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C3_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 10;
        carCollider.colorIndex = 10;

        garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
}
