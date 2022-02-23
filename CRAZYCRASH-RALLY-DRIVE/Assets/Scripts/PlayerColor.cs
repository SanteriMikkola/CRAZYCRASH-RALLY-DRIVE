using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{

    private GameObject Player;
    private GameObject Car;
    private Material playerMaterial;
    public Renderer playerRenderer;
    public Color playerNormalColor;
    public Color playerNewColor;
    private PlayerMovement playerMove;

    [SerializeField]
    private float Rn = 0.14f;
    [SerializeField]
    private float Gn = 0.16f;
    [SerializeField]
    private float Bn = 0.56f;
    [SerializeField]
    private float An = 1f;

    public bool IsThatNormalColor = true;
    public bool TrueOrFalse = false;
    //public bool IsChangeEnded = false;

    //public float waitPlayer1 = 0f;
    //public float waitPlayer2 = 2f;

    [SerializeField]
    private float R = 0.52f;
    [SerializeField]
    private float G = 0.525f;
    [SerializeField]
    private float B = 0.66f;
    [SerializeField]
    private float A = 0.58f;

    float time = 0.5f;
    float timeDelay = 1.5f;


    void Start()
    {

        Player = GameObject.Find("Player");
        Car = GameObject.Find("Car");
        playerRenderer = Car.GetComponent<Renderer>();
        //playerMaterial = Player.GetComponent<Material>();
        playerMove = Player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Change();
        /*if (IsThatNormalColor == true)
        {
            playerRenderer.material.color = playerNormalColor;
        }
        if (IsThatNormalColor == false)
        {
            playerRenderer.material.color = playerNewColor;
        }*/

        playerNormalColor = new Color(Rn, Gn, Bn, An);
        playerNewColor = new Color(R, G, B, A);
    }

    public void Change()
    {
        if (playerMove.playerCollideWithOsb == true)
        {
            for (int i = 0; i < 4; i++)
            {
                time += 1f * Time.deltaTime;

                if (time >= timeDelay)
                {
                    time = 0.5f;
                    IsThatNormalColor = TrueOrFalse;
                }

                if (IsThatNormalColor == false)
                {
                    playerRenderer.material.color = playerNewColor;
                    TrueOrFalse = true;
                }
                if (IsThatNormalColor == true)
                {
                    playerRenderer.material.color = playerNormalColor;
                    TrueOrFalse = false;
                }
            }

            //waitPlayer1 += 2f;
            return;
        }
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
