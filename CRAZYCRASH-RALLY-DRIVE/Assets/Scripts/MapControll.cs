using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControll : MonoBehaviour
{
    private GameObject Player;

    public GameObject[] Esteet;
    public GameObject[] AavikonEsteet;

    public GameObject[] ToolBoxes;
    public GameObject[] A_ToolBoxes;

    public GameObject[] JerryCans;
    public GameObject[] A_JerryCans;

    //public Este[] estes;

    //public GameObject[] frontColliders;
    private GameObject fCollider;
    private GameObject bCollider;

    private BoxCollider fBoxCollider;
    //private BoxCollider bBoxCollider;


    private int i = 0, ii = 0, iii = 0;

    private GameObject startButtonB;
    private StartButton startButtonS;

    private CarCollider carCollider;

    //public float[] vectorsF; 

    //public Vector3[] vector3s;

    public Vector3[] Obs_vectors;
    public Vector3[] TB_vectors;
    public Vector3[] Jerry_vectors;

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

    [HideInInspector]
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
        //bBoxCollider = bCollider.GetComponent<BoxCollider>();

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

        /*for (int i = 0; i < Esteet.Length; i++)
        {
            //estes = Esteet[i].gameObject.GetComponent<Este>();

            
        }*/

        if (carCollider.isThatLevel2 == true && CposChanget == false)
        {
            bCollider.transform.position = new Vector3(0, 402.06f, -8.069992f);
            fCollider.transform.position = new Vector3(0, 402.81f, 23f);
            AreaVector1 = new Vector3(0f, 402.81f, 23f);
            AreaVector2 = new Vector3(0f, 402.81f, 55f);
            startButtonS.GameStartForMapControll = true;
            CposChanget = true;
        }

        //StartThings();

        bCollider.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z - 8.07f);
        //Debug.Log(frontColliders.Length);
        if (startButtonS.GameStartForMapControll == true && carCollider.isThatLevel2 == false || playerCollidedFcollider == true && carCollider.isThatLevel2 == false)
        {
            isObjectsPicked = false;
            PositionCheck();
            startButtonS.GameStartForMapControll = false;
        }

        if (startButtonS.GameStartForMapControll == true && carCollider.isThatLevel2 == true || playerCollidedFcollider == true && carCollider.isThatLevel2 == true)
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
        //vectorsF = new float[frontColliders.Length];
        /*vector3s = new Vector3[frontColliders.Length];

        for (int i = 0; i < frontColliders.Length; i++)
        {
            vector3s[i].Set(frontColliders[i].transform.position.x, frontColliders[i].transform.position.y, frontColliders[i].transform.position.z);
            //vectorsF[i] = frontColliders[i].transform.position.z;
        }*/
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

    /*private void ObsActive()
    {
        
        for (int i = 0; i < PickedObjects.Length; i++)
        {
            PickedObjects[i].SetActive(true);

            var esteComponent = PickedObjects[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = true;
            activeToolBox = true;
        }
        return;
    }*/
}
