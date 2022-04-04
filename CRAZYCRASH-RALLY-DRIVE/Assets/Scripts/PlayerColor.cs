using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{

    private GameObject Player;

    [HideInInspector]
    public Material playerNewColorMaterial;
    [HideInInspector]
    public Material playerNormalColorMaterial;
    public MeshRenderer playerRenderer;
    public Color playerNormalColor;
    public Color playerNewColor;
    private PlayerMovement playerMove;

    private GameObject MainPlayer;
    private CarCollider carCollider;

    public GameObject Garage;
    private GarageControll garageControll;

    [SerializeField]
    private float Rn = 1f;
    [SerializeField]
    private float Gn = 1f;
    [SerializeField]
    private float Bn = 1f;
    [SerializeField]
    private float An = 1f;

    public bool IsThatNormalColor = true;
    public bool TrueOrFalse = false;
    public bool IsChangeEnded = false;

    [HideInInspector]
    public bool changeNormalcolor = true;
    [HideInInspector]
    public bool changeNcolor = true;

    //public float waitPlayer1 = 0f;
    //public float waitPlayer2 = 2f;

    [SerializeField]
    private float R = 0.52f;
    [SerializeField]
    private float G = 0.52f;
    [SerializeField]
    private float B = 0.66f;
    [SerializeField]
    private float A = 0.58f;

    float time = 0.5f;
    float timeDelay = 1.5f;


    void Start()
    {


        //playerMove = Player.GetComponent<PlayerMove>();

        MainPlayer = GameObject.Find("Player");
        carCollider = MainPlayer.GetComponent<CarCollider>();
        Player = GameObject.FindGameObjectWithTag("EquippedCar");
        garageControll = Garage.GetComponent<GarageControll>();
    }

    void Update()
    {
        if (garageControll.changeCarColor == false)
        {
            Player = GameObject.FindGameObjectWithTag("EquippedCar");
        }
        playerRenderer = Player.GetComponent<MeshRenderer>();

        if (garageControll.isThatOldCar == true && changeNormalcolor == false)  //oldC
        {
            Rn = 1f;
            Gn = 1f;
            Bn = 1f;
            An = 1f;

            var block = new MaterialPropertyBlock();

            playerNormalColor = new Color(Rn, Gn, Bn, An);
            playerNewColor = new Color(R, G, B, A);

            block.SetColor("_BaseColor", playerNormalColor);
            playerRenderer.SetPropertyBlock(block);

            changeNormalcolor = true;
        }
        if (garageControll.isThatOldCar == false && changeNcolor == false)  //defaultC
        {
            Rn = 1f;
            Gn = 1f;
            Bn = 1f;
            An = 1f;

            var block = new MaterialPropertyBlock();

            playerNormalColor = new Color(Rn, Gn, Bn, An);
            playerNewColor = new Color(R, G, B, A);

            block.SetColor("_BaseColor", playerNormalColor);
            playerRenderer.SetPropertyBlock(block);
            changeNcolor = true;
        }

        playerNormalColor = new Color(Rn, Gn, Bn, An);
        playerNewColor = new Color(R, G, B, A);

        /*if (playerMove.playerCollideWithOsb == true)
        {
            Change();
        }*/
        if (carCollider.playerCollide == true)
        {
            Change();
        }

        /*if (IsThatNormalColor == true)
        {
            playerRenderer.material.color = playerNormalColor;
        }
        if (IsThatNormalColor == false)
        {
            playerRenderer.material.color = playerNewColor;
        }*/


    }

    public void Change()
    {
        /*if (playerMove.playerCollideWithOsb == true)
        {*/
        var block = new MaterialPropertyBlock();
        //block.SetColor("_BaseColor", playerNewColor);

        for (int i = 0; i < 5; i++)
        {
            time += 1f * Time.deltaTime;

            if (time >= timeDelay)
            {
                time = 0.5f;
                IsThatNormalColor = TrueOrFalse;
            }

            if (IsThatNormalColor == false)
            {
                block.SetColor("_BaseColor", playerNewColor);
                playerRenderer.SetPropertyBlock(block);
                //playerRenderer.material.SetColor("_BaseColor", playerNewColor);
                //playerRenderer.material = playerNewColorMaterial;
                TrueOrFalse = true;
            }
            if (IsThatNormalColor == true)
            {
                block.SetColor("_BaseColor", playerNormalColor);
                playerRenderer.SetPropertyBlock(block);
                //playerRenderer.material.SetColor("_BaseColor", playerNormalColor);
                //playerRenderer.material = playerNormalColorMaterial;
                TrueOrFalse = false;
            }
        }

        //waitPlayer1 += 2f;
        return;
        //}
    }

    /*public void Blinking()
    {
            playerRenderer.material.color = playerNewColor;
            StartCoroutine(WaitForChangingColor());
            playerRenderer.material.color = playerNormalColor;
            StartCoroutine(WaitForChangingColor2());
    }
    IEnumerator WaitForChangingColor()
    {
        yield return new WaitForSeconds(5);
        yield return new WaitUntil(() => IsThatNormalColor == false);
    }
    IEnumerator WaitForChangingColor2()
    {
        yield return new WaitForSeconds(5);
        yield return new WaitUntil(() => IsThatNormalColor == true);
    }*/
}