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

    private GameObject MoneyAddedText;
    private Text MoneyAddedText_Text;

    private GameObject DownPanel;

    private bool setUp = true;

    public float time = 0f;
    public float timeDelay = 3f;

    private bool activateMoneyT = false;

    private bool moneyScreenActivated = false;

    [HideInInspector]
    public bool CloseScreen = false;

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
            MoneyAddedText = GameObject.Find("MoneyAddedText");
            DownPanel = GameObject.Find("DownPanel");

            DownPanel.SetActive(false);

            MoneyBackground_Image = MoneyBackground.GetComponent<Image>();
            MoneyText_Image_Text = MoneyText_Image.GetComponent<TextMeshProUGUI>();
            MoneyText_Image_Image_Image = MoneyText_Image_Image.GetComponent<Image>();
            MoneyAddedText_Text = MoneyAddedText.GetComponent<Text>();

            setUp = false;
        }

        MoneyText_Image_Text.text = carCollider.money.ToString();

        if (carCollider.isPlayerDead && moneyScreenActivated == false)
        {
            activateMoneyT = false;
            moneyScreen.SetActive(true);
            MoneyBackground.SetActive(true);
            MoneyText_Image.SetActive(true);
            MoneyText_Image_Image.SetActive(true);
            MoneyAddedText.SetActive(true);
            DownPanel.SetActive(true);

            MoneyBackground_Image.enabled = true;
            MoneyText_Image_Text.enabled = true;
            MoneyText_Image_Image_Image.enabled = true;

            Safe_money.SetActive(true);
            time = time + 1f * Time.deltaTime;

            MoneyAddedText_Text.text = carCollider.moneyPerRound.ToString();

            if (time >= timeDelay && activateMoneyT == false)
            {
                MoneyAddedText_Text.enabled = true;
                Debug.Log("KEKE");

                carCollider.money += carCollider.moneyPerRound;

                moneyScreenActivated = true;
                carCollider.index = 0;
                carCollider.safesPicked = 0;

                activateMoneyT = true;
                time = 0;
            }

            //time = time + 1f * Time.deltaTime;
            /*if (time >= timeDelay && activateMoneyT == true)
            {
                MoneyAddedText_Text.enabled = false;
                Debug.Log("KAKA");
                activateMoneyT = false;
                time = 0;
            }*/
            /*for (int i = 0; i < carCollider.safesPicked; i++)
            {
                time = 0;
                //time = time + 1f * Time.deltaTime;
                if (time >= timeDelay)      //!
                {
                    MoneyAddedText_Text.enabled = true;
                    Debug.Log("KEKE");
                }

                time = 0;
                //time = time + 1f * Time.deltaTime;
                if (time >= timeDelay)
                {
                    MoneyAddedText_Text.enabled = false;
                    Debug.Log("KAKA");
                }
            }*/
            //StartCoroutine(SafeOpen());
        }

    }


    public void M_ScreenOpen()
    {
        moneyScreen.SetActive(true);
        MoneyBackground.SetActive(true);
        MoneyText_Image.SetActive(true);
        MoneyText_Image_Image.SetActive(true);
        MoneyAddedText.SetActive(true);

        MoneyBackground_Image.enabled = true;
        MoneyText_Image_Text.enabled = true;
        MoneyText_Image_Image_Image.enabled = true;

        Safe_money.SetActive(true);
        for (int i = 0; i < carCollider.safesPicked; i++)
        {
            time = time + 1f * Time.deltaTime;
            if (time >= timeDelay)      //!
            {
                MoneyAddedText_Text.enabled = true;
                Debug.Log("KEKE");
            }

            time = 0;
            time = time + 1f * Time.deltaTime;
            if (time >= timeDelay)
            {
                MoneyAddedText_Text.enabled = false;
                Debug.Log("KAKA");
            }
        }
        //StartCoroutine(SafeOpen());
        carCollider.index = 0;
        carCollider.safesPicked = 0;
    }

    IEnumerator SafeOpen()
    {
        for (int i = 0; i < carCollider.safesPicked; i++)
        {
            //Safe_money.SetActive(true);
            time = time + 1f * Time.deltaTime;
            yield return new WaitForSeconds(2);
            if (time >= timeDelay)
            {
                MoneyAddedText_Text.enabled = true;
            }
        }
    }

    public void M_ScreenClose()
    {
        MoneyBackground_Image.enabled = false;
        MoneyText_Image_Text.enabled = false;
        MoneyText_Image_Image_Image.enabled = false;
        MoneyAddedText_Text.enabled = false;
        Safe_money.SetActive(false);
        DownPanel.SetActive(false);

        CloseScreen = true;
        moneyScreenActivated = false;

        /*moneyScreen.SetActive(false);
        MoneyBackground.SetActive(false);
        MoneyText_Image.SetActive(false);
        MoneyText_Image_Image.SetActive(false);*/
    }
}
