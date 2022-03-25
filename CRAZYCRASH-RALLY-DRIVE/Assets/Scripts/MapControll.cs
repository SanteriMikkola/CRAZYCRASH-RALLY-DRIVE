using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapControll : MonoBehaviour
{
    private GameObject Player;

    public GameObject[] Esteet;
    public GameObject[] AavikonEsteet;

    public GameObject[] Reback_Obs;
    public GameObject[] Reback_A_Obs;

    private GameObject[] ToolBoxes;
    private GameObject[] A_ToolBoxes;

    public GameObject[] Reback_ToolBoxes;
    public GameObject[] Reback_A_ToolBoxes;

    private GameObject[] JerryCans;
    private GameObject[] A_JerryCans;

    public GameObject[] Reback_JerryCans;
    public GameObject[] Reback_A_JerryCans;


    public GameObject[] Trees;
    private GameObject[] startTrees;
    //public Este[] estes;

    //public GameObject[] frontColliders;
    private GameObject fCollider;
    private GameObject bCollider;

    private BoxCollider fBoxCollider;
    //private BoxCollider bBoxCollider;
    private GameObject PauseMenu;
    private GameObject PM_bg;
    private Image PM_bg_image;
    private GameObject PM_fg;
    private Image PM_fg_image;
    private GameObject PM_pauseT;
    private Image PM_pauseT_image;
    private GameObject PM_resumeT;
    private Image PM_resumeT_image;
    private Button PM_resumeT_Button;
    private GameObject PM_optionsT;
    private Image PM_optionsT_image;
    private Button PM_optionsT_Button;
    private GameObject PM_giveupT;
    private Image PM_giveupT_image;
    private Button PM_giveupT_Button;
    private GameObject PAUSE;
    private Image[] PAUSE_images;
    private GameObject Resume;
    private Image[] Resume_images;
    private GameObject Options;
    private Image[] Options_images;
    private GameObject GiveUp;
    private Image[] GiveUp_images;

    private bool pauseSetup = true;
    public bool isGamePaused = false;

    private int i = 0, ii = 0, iii = 0;

    private GameObject startButtonB;
    private StartButton startButtonS;

    private CarCollider carCollider;

    //public float[] vectorsF; 

    //public Vector3[] vector3s;

    private Vector3[] Obs_vectors;
    private Vector3[] TB_vectors;
    private Vector3[] Jerry_vectors;

    public Vector3[] A_Obs_vectors;
    public Vector3[] A_TB_vectors;
    public Vector3[] A_Jerry_vectors;

    //public GameObject[] PickedObjects;

    //public GameObject[] Testi;

    public Vector3 AreaVector1 = new Vector3(0f, 3.18f, 23f);
    public Vector3 AreaVector2 = new Vector3(0f, 3.18f, 55f);

    public Vector3 A_AreaVector1 = new Vector3(0f, 3.18f, 23f);
    public Vector3 A_AreaVector2 = new Vector3(0f, 3.18f, 55f);

    private bool isObjectsPicked = false;

    public bool playerCollidedFcollider = false;
    private bool spawnObs = false;

    //[HideInInspector]
    public bool CposChanget = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        bCollider = GameObject.Find("BackCollider");
        fCollider = GameObject.Find("FrontCollider");
        startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();
        carCollider = Player.GetComponent<CarCollider>();

        fBoxCollider = fCollider.GetComponent<BoxCollider>();
        //bBoxCollider = bCollider.GetComponent<BoxCollider

        Reback_Obs = GameObject.FindGameObjectsWithTag("Este");
        Reback_A_Obs = GameObject.FindGameObjectsWithTag("AavikonEste");
        Reback_ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
        Reback_A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
        Reback_JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
        Reback_A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");
        Trees = GameObject.FindGameObjectsWithTag("TreeWithMesh");
        startTrees = GameObject.FindGameObjectsWithTag("StartTrees");

        bCollider.transform.parent = null;
        fCollider.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        Esteet = GameObject.FindGameObjectsWithTag("Este");
        AavikonEsteet = GameObject.FindGameObjectsWithTag("AavikonEste");
        ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
        A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
        JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
        A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");

        if (startButtonS.IsGameStarted == true && pauseSetup == true)
        {
            PauseMenu = GameObject.Find("PauseMenu");
            PM_bg = GameObject.Find("PauseBackground");
            PM_fg = GameObject.Find("PauseForeground");
            PM_pauseT = GameObject.Find("pauseText");
            PM_resumeT = GameObject.Find("resumeText");
            PM_optionsT = GameObject.Find("optionsText");
            PM_giveupT = GameObject.Find("giveupText");
            PAUSE = GameObject.Find("PAUSE");
            Resume = GameObject.Find("Resume");
            Options = GameObject.Find("Options");
            GiveUp = GameObject.Find("GiveUp");

            PM_bg_image = PM_bg.GetComponent<Image>();
            PM_fg_image = PM_fg.GetComponent<Image>();
            PM_pauseT_image = PM_pauseT.GetComponent<Image>();
            PM_resumeT_image = PM_resumeT.GetComponent<Image>();
            PM_resumeT_Button = PM_resumeT.GetComponent<Button>();
            PM_optionsT_image = PM_optionsT.GetComponent<Image>();
            PM_optionsT_Button = PM_optionsT.GetComponent<Button>();
            PM_giveupT_image = PM_giveupT.GetComponent<Image>();
            PM_giveupT_Button = PM_giveupT.GetComponent<Button>();
            PAUSE_images = PAUSE.GetComponentsInChildren<Image>();
            Resume_images = Resume.GetComponentsInChildren<Image>();
            Options_images = Options.GetComponentsInChildren<Image>();
            GiveUp_images = GiveUp.GetComponentsInChildren<Image>();

            pauseSetup = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused == false)
        {
            isGamePaused = true;
            PM_bg_image.enabled = true;
            PM_fg_image.enabled = true;
            PM_pauseT_image.enabled = true;
            PM_resumeT_image.enabled = true;
            PM_optionsT_image.enabled = true;
            PM_giveupT_image.enabled = true;
            for (int i = 0; i < PAUSE_images.Length; i++)
            {
                PAUSE_images[i].enabled = true;
            }
            for (int i = 0; i < Resume_images.Length; i++)
            {
                Resume_images[i].enabled = true;
            }
            for (int i = 0; i < Options_images.Length; i++)
            {
                Options_images[i].enabled = true;
            }
            for (int i = 0; i < GiveUp_images.Length; i++)
            {
                GiveUp_images[i].enabled = true;
            }
        }

        if (carCollider.reback_Obs == false && carCollider.isThatLevel2 == false && CposChanget == false && carCollider.isThatMT == true)
        {
            fBoxCollider.enabled = false;
            bCollider.transform.position = new Vector3(0, 802.6f, -40.06f);
            fCollider.transform.position = new Vector3(0, 802.6f, 23f);
            AreaVector1 = new Vector3(0f, 802.6f, 23f);
            AreaVector2 = new Vector3(0f, 802.6f, 55f);
            startButtonS.GameStartForMapControll = true;
            CposChanget = false;


            //carCollider.reback_Obs = false;
            //return;
        }


        if (carCollider.reback_Obs == true && carCollider.isThatLevel2 == false && CposChanget == true && carCollider.isThatMT == false)
        {
            fBoxCollider.enabled = true;
            bCollider.transform.position = new Vector3(0, 0, -8.069992f);
            fCollider.transform.position = new Vector3(0, 3.18f, 23f);
            AreaVector1 = new Vector3(0f, 3.18f, 23f);
            AreaVector2 = new Vector3(0f, 3.18f, 55f);
            startButtonS.GameStartForMapControll = true;
            CposChanget = false;

            for (int i = 0; i < Reback_Obs.Length; i++)
            {
                Reback_Obs[i].SetActive(true);

                var esteComponent = Reback_Obs[i].gameObject.GetComponent<Este>();

                //esteComponent.activateMesh = true;
                esteComponent.isColliderUnActive = false;
                esteComponent.reActivate = true;
            }
            for (int i = 0; i < Reback_ToolBoxes.Length; i++)
            {
                Reback_ToolBoxes[i].SetActive(true);

                var TBComponent = Reback_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                //esteComponent.activateMesh = true;
                TBComponent.reBackTB = true;
            }
            for (int i = 0; i < Reback_JerryCans.Length; i++)
            {
                Reback_JerryCans[i].SetActive(true);

                var JerryComponent = Reback_JerryCans[i].gameObject.GetComponent<JerryCan>();

                //esteComponent.activateMesh = true;
                JerryComponent.rebackJerry = true;
            }
            for (int i = 0; i < Trees.Length; i++)
            {
                Trees[i].SetActive(true);

                var treeControlComponent = Trees[i].gameObject.GetComponent<TreeControll>();

                //esteComponent.activateMesh = true;
                treeControlComponent.ActiveTrees();
            }
            /*for (int i = 0; i < startTrees.Length; i++)
            {
                startTrees[i].SetActive(true);

                var treeControlComponent = startTrees[i].gameObject.GetComponent<TreeControll>();

                //esteComponent.activateMesh = true;
                treeControlComponent.ActiveSTrees();
            }*/
            Esteet = GameObject.FindGameObjectsWithTag("Este");
            JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
            ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
            //carCollider.reback_Obs = false;
            //return;
        }

        if (carCollider.isThatLevel2 == true && carCollider.reback_Obs == false && CposChanget == false && carCollider.isThatMT == false)
        {
            fBoxCollider.enabled = true;
            bCollider.transform.position = new Vector3(0, 402.06f, -8.069992f);
            fCollider.transform.position = new Vector3(0, 402.81f, 23f);
            AreaVector1 = new Vector3(0f, 402.81f, 23f);
            AreaVector2 = new Vector3(0f, 402.81f, 55f);
            A_AreaVector1 = new Vector3(0f, 3.18f, 23f);
            A_AreaVector2 = new Vector3(0f, 3.18f, 55f);
            startButtonS.GameStartForMapControll = true;
            CposChanget = true;

            for (int i = 0; i < Reback_A_Obs.Length; i++)
            {
                Reback_A_Obs[i].SetActive(true);

                var esteComponent = Reback_A_Obs[i].gameObject.GetComponent<Este>();

                //esteComponent.activateMesh = true;
                esteComponent.isColliderUnActive = false;
                esteComponent.reActivate = true;
            }
            for (int i = 0; i < Reback_A_ToolBoxes.Length; i++)
            {
                Reback_A_ToolBoxes[i].SetActive(true);

                var TBComponent = Reback_A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                //esteComponent.activateMesh = true;
                TBComponent.reBackTB = true;
            }
            for (int i = 0; i < Reback_A_JerryCans.Length; i++)
            {
                Reback_A_JerryCans[i].SetActive(true);

                var JerryComponent = Reback_A_JerryCans[i].gameObject.GetComponent<JerryCan>();

                //esteComponent.activateMesh = true;
                JerryComponent.rebackJerry = true;
            }
            for (int i = 0; i < Trees.Length; i++)
            {
                Trees[i].SetActive(true);

                var treeControlComponent = Trees[i].gameObject.GetComponent<TreeControll>();

                //esteComponent.activateMesh = true;
                treeControlComponent.ActiveTrees();
            }
            AavikonEsteet = GameObject.FindGameObjectsWithTag("AavikonEste");
            A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");
            A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
            //carCollider.reback_Obs = false;
        }

        //StartThings();

        bCollider.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z - 8.07f);
        //Debug.Log(frontColliders.Length);
        if (startButtonS.GameStartForMapControll == true && carCollider.isThatLevel2 == false && carCollider.isThatMT == true || playerCollidedFcollider == true && carCollider.isThatLevel2 == false && carCollider.isThatMT == true)
        {
            isObjectsPicked = false;
            MoottoriTiePositionCheck();
            startButtonS.GameStartForMapControll = false;
        }

        if (startButtonS.GameStartForMapControll == true && carCollider.isThatLevel2 == false && carCollider.isThatMT == false || playerCollidedFcollider == true && carCollider.isThatLevel2 == false && carCollider.isThatMT == false)
        {
            isObjectsPicked = false;
            PositionCheck();
            startButtonS.GameStartForMapControll = false;
        }

        if (startButtonS.GameStartForMapControll == true && carCollider.isThatLevel2 == true && carCollider.isThatMT == false || playerCollidedFcollider == true && carCollider.isThatLevel2 == true && carCollider.isThatMT == false)
        {
            isObjectsPicked = false;
            AavikkoPositionCheck();
            startButtonS.GameStartForMapControll = false;
        }
        //ObsActive();
        //fCollider.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z + 48.5f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Testi");
            playerCollidedFcollider = true;
            //gameObject.SetActive(false)

            fCollider.transform.position = new Vector3(AreaVector1.x, AreaVector1.y, AreaVector1.z);
        }
    }

    /*private void StartThings()
    {
        frontColliders = GameObject.FindGameObjectsWithTag("MapCfront");
        while (i != frontColliders.Length)
        {
            frontColliders[i].transform.parent = null;

            i++;
        }
        return;
    }*/

    private void PositionCheck()
    {
        //vectorsF = new float[frontColliders.Length];
        /*vector3s = new Vector3[frontColliders.Length];

        for (int i = 0; i < frontColliders.Length; i++)
        {
            vector3s[i].Set(frontColliders[i].transform.position.x, frontColliders[i].transform.position.y, frontColliders[i].transform.position.z);
            //vectorsF[i] = frontColliders[i].transform.position.z;
        }*/
        Obs_vectors = new Vector3[Esteet.Length];
        TB_vectors = new Vector3[ToolBoxes.Length];
        Jerry_vectors = new Vector3[JerryCans.Length];

        //Debug.Log("GameStartForMapControll!");

        if (!isObjectsPicked)
        {
            for (int i = 0; i < Esteet.Length; i++)
            {
                Obs_vectors[i].Set(Esteet[i].transform.position.x, Esteet[i].transform.position.y, Esteet[i].transform.position.z);

                if (Obs_vectors[i].z > AreaVector1.z && Obs_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = Esteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = true;
                    //activeToolBox = true;

                    /*var objecti = Esteet[i];

                    //Debug.Log(objecti);
                    Debug.Log(Testi.Length);

                    PickedObjects.SetValue(objecti, iii);*/

                    //objecti = null;
                    /*
                    System.Array.Copy(Esteet, i, PickedObjects, iii, 1);
                    Debug.Log(PickedObjects);
                    //System.Array.ConstrainedCopy(PickedObjects, iii, Esteet, ii, 1);
                    iii++;*/
                    //Esteet.CopyTo(PickedObjects, ii);
                }
            }

            for (int i = 0; i < ToolBoxes.Length; i++)
            {
                TB_vectors[i].Set(ToolBoxes[i].transform.position.x, ToolBoxes[i].transform.position.y, ToolBoxes[i].transform.position.z);

                if (TB_vectors[i].z > AreaVector1.z && TB_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    esteComponent.activeToolBox = true;

                    /*var objecti = Esteet[i];

                    //Debug.Log(objecti);
                    Debug.Log(Testi.Length);

                    PickedObjects.SetValue(objecti, iii);*/

                    //objecti = null;
                    /*
                    System.Array.Copy(Esteet, i, PickedObjects, iii, 1);
                    Debug.Log(PickedObjects);
                    //System.Array.ConstrainedCopy(PickedObjects, iii, Esteet, ii, 1);
                    iii++;*/
                    //Esteet.CopyTo(PickedObjects, ii);
                }
            }

            for (int i = 0; i < JerryCans.Length; i++)
            {
                Jerry_vectors[i].Set(JerryCans[i].transform.position.x, JerryCans[i].transform.position.y, JerryCans[i].transform.position.z);

                if (Jerry_vectors[i].z > AreaVector1.z && Jerry_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = JerryCans[i].gameObject.GetComponent<JerryCan>();

                    esteComponent.activeJerryCan = true;

                    /*var objecti = Esteet[i];

                    //Debug.Log(objecti);
                    Debug.Log(Testi.Length);

                    PickedObjects.SetValue(objecti, iii);*/

                    //objecti = null;
                    /*
                    System.Array.Copy(Esteet, i, PickedObjects, iii, 1);
                    Debug.Log(PickedObjects);
                    //System.Array.ConstrainedCopy(PickedObjects, iii, Esteet, ii, 1);
                    iii++;*/
                    //Esteet.CopyTo(PickedObjects, ii);
                }
            }

            isObjectsPicked = true;
        }
        playerCollidedFcollider = false;
        AreaVector1.z = AreaVector1.z + 29f;
        AreaVector2.z = AreaVector2.z + 29f;
        //PickedObjects = new GameObject[ii];
        //Esteet.CopyTo(PickedObjects, ii);
        /*for (int i = 0; i < Esteet.Length; i++)
        {
            //Obs_vectors[i].Set(Esteet[i].transform.position.x, Esteet[i].transform.position.y, Esteet[i].transform.position.z);

            if (Obs_vectors[i].z > AreaVector1.z && Obs_vectors[i].z < AreaVector2.z)
            {
                if (i < ii)
                {
                    Esteet.CopyTo(PickedObjects, ii);
                }
            }
            
        }*/
        //return;
    }

    private void AavikkoPositionCheck()
    {
        A_Obs_vectors = new Vector3[AavikonEsteet.Length];
        A_TB_vectors = new Vector3[A_ToolBoxes.Length];
        A_Jerry_vectors = new Vector3[A_JerryCans.Length];

        //Debug.Log(A_Obs_vectors.Length);

        if (!isObjectsPicked)
        {
            for (int i = 0; i < AavikonEsteet.Length; i++)
            {
                A_Obs_vectors[i].Set(AavikonEsteet[i].transform.position.x, AavikonEsteet[i].transform.position.y, AavikonEsteet[i].transform.position.z);

                if (A_Obs_vectors[i].z > A_AreaVector1.z && A_Obs_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = AavikonEsteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = true;
                    //activeToolBox = true;

                    /*var objecti = Esteet[i];

                    //Debug.Log(objecti);
                    Debug.Log(Testi.Length);

                    PickedObjects.SetValue(objecti, iii);*/

                    //objecti = null;
                    /*
                    System.Array.Copy(Esteet, i, PickedObjects, iii, 1);
                    Debug.Log(PickedObjects);
                    //System.Array.ConstrainedCopy(PickedObjects, iii, Esteet, ii, 1);
                    iii++;*/
                    //Esteet.CopyTo(PickedObjects, ii);
                }
            }

            for (int i = 0; i < A_ToolBoxes.Length; i++)
            {
                A_TB_vectors[i].Set(A_ToolBoxes[i].transform.position.x, A_ToolBoxes[i].transform.position.y, A_ToolBoxes[i].transform.position.z);

                if (A_TB_vectors[i].z > A_AreaVector1.z && A_TB_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    esteComponent.activeToolBox = true;

                    /*var objecti = Esteet[i];

                    //Debug.Log(objecti);
                    Debug.Log(Testi.Length);

                    PickedObjects.SetValue(objecti, iii);*/

                    //objecti = null;
                    /*
                    System.Array.Copy(Esteet, i, PickedObjects, iii, 1);
                    Debug.Log(PickedObjects);
                    //System.Array.ConstrainedCopy(PickedObjects, iii, Esteet, ii, 1);
                    iii++;*/
                    //Esteet.CopyTo(PickedObjects, ii);
                }
            }

            for (int i = 0; i < A_JerryCans.Length; i++)
            {
                A_Jerry_vectors[i].Set(A_JerryCans[i].transform.position.x, A_JerryCans[i].transform.position.y, A_JerryCans[i].transform.position.z);

                if (A_Jerry_vectors[i].z > A_AreaVector1.z && A_Jerry_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = A_JerryCans[i].gameObject.GetComponent<JerryCan>();

                    esteComponent.activeJerryCan = true;

                    /*var objecti = Esteet[i];

                    //Debug.Log(objecti);
                    Debug.Log(Testi.Length);

                    PickedObjects.SetValue(objecti, iii);*/

                    //objecti = null;
                    /*
                    System.Array.Copy(Esteet, i, PickedObjects, iii, 1);
                    Debug.Log(PickedObjects);
                    //System.Array.ConstrainedCopy(PickedObjects, iii, Esteet, ii, 1);
                    iii++;*/
                    //Esteet.CopyTo(PickedObjects, ii);
                }
            }

            isObjectsPicked = true;
        }
        playerCollidedFcollider = false;
        AreaVector1.z = AreaVector1.z + 29f;
        AreaVector2.z = AreaVector2.z + 29f;
        A_AreaVector1.z = A_AreaVector1.z + 29f;
        A_AreaVector2.z = A_AreaVector2.z + 29f;
    }

    private void MoottoriTiePositionCheck()
    {

        if (!isObjectsPicked)
        {


            isObjectsPicked = true;
        }
        playerCollidedFcollider = false;
        AreaVector1.z = AreaVector1.z + 29f;
        AreaVector2.z = AreaVector2.z + 29f;
    }

    public void PressedResume()
    {
        if (isGamePaused == true)
        {
            isGamePaused = false;
            PM_bg_image.enabled = false;
            PM_fg_image.enabled = false;
            PM_pauseT_image.enabled = false;
            PM_resumeT_image.enabled = false;
            PM_optionsT_image.enabled = false;
            PM_giveupT_image.enabled = false;
            for (int i = 0; i < PAUSE_images.Length; i++)
            {
                PAUSE_images[i].enabled = false;
            }
            for (int i = 0; i < Resume_images.Length; i++)
            {
                Resume_images[i].enabled = false;
            }
            for (int i = 0; i < Options_images.Length; i++)
            {
                Options_images[i].enabled = false;
            }
            for (int i = 0; i < GiveUp_images.Length; i++)
            {
                GiveUp_images[i].enabled = false;
            }
        }
    }
}
