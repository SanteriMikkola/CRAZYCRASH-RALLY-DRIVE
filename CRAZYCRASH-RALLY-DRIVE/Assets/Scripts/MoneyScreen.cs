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

    private GameObject ScoreNumText;
    public GameObject ScoreNumText2;
    private Text ScoreNumText_Text;
    private Text ScoreNumText2_Text;

    private GameObject MoneyAddedScoreText;
    private Text MoneyAddedScoreText_Text;

    private Vector3 targetPos;
    private Vector3 originalPos;

    private float ScoreNumTextSpeed = 155f;

    private bool ScoreNumTextOnTargetPos = false;


    private bool setUp = true;

    public float time = 0f;
    public float timeDelay = 3f;
    public float timeDelay2 = 2f;
    public float timeDelay3 = 2f;

    public bool activateMoneyT = false;
    public bool activateMoneyST = false;
    public bool disableMoneyST = false;
    private bool pickScoreNum = true;

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

        //1007.9f - x 766f - y
        targetPos = new Vector3(1007.9f, 766f, 0f);
        originalPos = new Vector3(140f, 1035f, 0f);
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
            //MoneyAddedScoreText = GameObject.Find("MoneyAddedScoreText");
            DownPanel = GameObject.Find("DownPanel");

            ScoreNumText = GameObject.Find("ScoreNumText");

            DownPanel.SetActive(false);

            MoneyBackground_Image = MoneyBackground.GetComponent<Image>();
            MoneyText_Image_Text = MoneyText_Image.GetComponent<TextMeshProUGUI>();
            MoneyText_Image_Image_Image = MoneyText_Image_Image.GetComponent<Image>();
            MoneyAddedText_Text = MoneyAddedText.GetComponent<Text>();
            //MoneyAddedScoreText_Text = MoneyAddedScoreText.GetComponent<Text>();

            ScoreNumText_Text = ScoreNumText.GetComponent<Text>();
            ScoreNumText2_Text = ScoreNumText2.GetComponent<Text>();

            ScoreNumText2_Text.text = ScoreNumText_Text.text;

            setUp = false;
        }

        MoneyText_Image_Text.text = carCollider.money.ToString();

        if (carCollider.isPlayerDead && moneyScreenActivated == false)
        {
            if (pickScoreNum == true)
            {
                ScoreNumText2_Text.alignment = TextAnchor.MiddleLeft;
                ScoreNumText2_Text.text = ScoreNumText_Text.text;
                ScoreNumText2_Text.enabled = true;
                activateMoneyT = false;
                activateMoneyST = false;
                disableMoneyST = false;
                ScoreNumTextOnTargetPos = false;
                pickScoreNum = false;
            }
            
            moneyScreen.SetActive(true);
            MoneyBackground.SetActive(true);
            MoneyText_Image.SetActive(true);
            MoneyText_Image_Image.SetActive(true);
            MoneyAddedText.SetActive(true);
            //MoneyAddedScoreText.SetActive(true);
            DownPanel.SetActive(true);
            ScoreNumText2.SetActive(true);
            
            MoneyBackground_Image.enabled = true;


            if (!ScoreNumTextOnTargetPos)
            {
                ScoreNumText2.transform.position = Vector3.MoveTowards(ScoreNumText2.transform.position, targetPos, ScoreNumTextSpeed * Time.deltaTime);
                if (ScoreNumText2.transform.position == targetPos)
                {
                    time = time + 1f * Time.deltaTime;

                    //MoneyAddedScoreText_Text.text = carCollider.moneyPerRound2.ToString();


                    if (time >= timeDelay3 && activateMoneyST == false)
                    {

                        MoneyText_Image_Text.enabled = true;
                        MoneyText_Image_Image_Image.enabled = true;

                        ScoreNumText2_Text.alignment = TextAnchor.MiddleCenter;

                        ScoreNumText2_Text.text = carCollider.moneyPerRound2.ToString();

                        //MoneyAddedScoreText_Text.enabled = true;

                        carCollider.money += carCollider.moneyPerRound2;

                        activateMoneyST = true;
                        time = 0;
                    }

                    if (time >= timeDelay2 && disableMoneyST == false)
                    {

                        ScoreNumText2_Text.enabled = false;

                        disableMoneyST = true;
                        time = 0;
                        ScoreNumTextOnTargetPos = true;
                    }
                }
            }




            if (ScoreNumTextOnTargetPos)
            {
                Safe_money.SetActive(true);
                time = time + 1f * Time.deltaTime;

                MoneyAddedText_Text.text = carCollider.moneyPerRound.ToString();

                if (time >= timeDelay && activateMoneyT == false)
                {
                    MoneyAddedText_Text.enabled = true;
                    //Debug.Log("KEKE");

                    carCollider.money += carCollider.moneyPerRound;

                    moneyScreenActivated = true;
                    pickScoreNum = true;
                    carCollider.index = 0;
                    carCollider.safesPicked = 0;
                    ScoreNumText2.transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);

                    activateMoneyT = true;
                    time = 0;
                }
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
            //ScoreNumTextOnTargetPos = false;
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
                //Debug.Log("KEKE");
            }

            time = 0;
            time = time + 1f * Time.deltaTime;
            if (time >= timeDelay)
            {
                MoneyAddedText_Text.enabled = false;
                //Debug.Log("KAKA");
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
