using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyScreen : MonoBehaviour
{
    private GameObject Kamera;

    public GameObject startButtonB;
    private StartButton startButtonS;

    private GameObject Player;
    private CarCollider carCollider;

    private GameObject moneyScreen;
    private GameObject MoneyBackground;
    private Image MoneyBackground_Image;
    private GameObject MoneyText_Image;
    private TextMeshProUGUI MoneyText_Image_Text;
    private GameObject MoneyText_Image_Image;
    private Image MoneyText_Image_Image_Image;

    private GameObject Safe_money;


    private bool setUp = true;

    [HideInInspector]
    public bool screenOpened = false;

    void Start()
    {
        Kamera = GameObject.Find("Main Camera");
        Safe_money = GameObject.Find("Safe_money");

        //startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();

        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();

        Safe_money.SetActive(false);
    }

    void Update()
    {
        Safe_money.transform.position = new Vector3(Kamera.transform.position.x, Kamera.transform.position.y - 1.5f, Kamera.transform.position.z + 1f);

        if (startButtonS.IsGameStarted == true && setUp == true)
        {
            moneyScreen = GameObject.Find("MoneyScreen");
            MoneyBackground = GameObject.Find("MoneyBackground");
            MoneyText_Image = GameObject.Find("MoneyText_Image");
            MoneyText_Image_Image = GameObject.Find("MoneyText_Image_Image");

            MoneyBackground_Image = MoneyBackground.GetComponent<Image>();
            MoneyText_Image_Text = MoneyText_Image.GetComponent<TextMeshProUGUI>();
            MoneyText_Image_Image_Image = MoneyText_Image_Image.GetComponent<Image>();

            setUp = false;
        }
    }


    public void M_ScreenOpen()
    {
        moneyScreen.SetActive(true);
        MoneyBackground.SetActive(true);
        MoneyText_Image.SetActive(true);
        MoneyText_Image_Image.SetActive(true);

        MoneyBackground_Image.enabled = true;
        MoneyText_Image_Text.enabled = true;
        MoneyText_Image_Image_Image.enabled = true;

        Safe_money.SetActive(true);
        /*for (int i = 0; i < carCollider.safesPicked; i++)
        {
            Safe_money.SetActive(true);
        }*/
        //screenOpened = true;
    }

    public void M_ScreenClose()
    {
        MoneyBackground_Image.enabled = false;
        MoneyText_Image_Text.enabled = false;
        MoneyText_Image_Image_Image.enabled = false;

        moneyScreen.SetActive(false);
        MoneyBackground.SetActive(false);
        MoneyText_Image.SetActive(false);
        MoneyText_Image_Image.SetActive(false);
    }
}
