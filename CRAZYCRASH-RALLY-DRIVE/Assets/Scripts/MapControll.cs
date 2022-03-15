using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControll : MonoBehaviour
{
    private GameObject Player;

    public GameObject[] Esteet;

    public GameObject[] ToolBoxes;

    //public Este[] estes;

    //public GameObject[] frontColliders;
    private GameObject fCollider;
    private GameObject bCollider;

    private BoxCollider fBoxCollider;
    //private BoxCollider bBoxCollider;


    private int i = 0, ii = 0, iii = 0;

    private GameObject startButtonB;
    private StartButton startButtonS;

    //public float[] vectorsF; 

    //public Vector3[] vector3s;

    public Vector3[] Obs_vectors;
    public Vector3[] TB_vectors;

    //public GameObject[] PickedObjects;

    //public GameObject[] Testi;

    public Vector3 AreaVector1 = new Vector3(0f, 3.18f, 23f);
    public Vector3 AreaVector2 = new Vector3(0f, 3.18f, 55f);

    private bool isObjectsPicked = false;

    public bool playerCollidedFcollider = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        bCollider = GameObject.Find("BackCollider");
        fCollider = GameObject.Find("FrontCollider");
        startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();

        fBoxCollider = fCollider.GetComponent<BoxCollider>();
        //bBoxCollider = bCollider.GetComponent<BoxCollider>();

        bCollider.transform.parent = null;
        fCollider.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Esteet = GameObject.FindGameObjectsWithTag("Este");
        ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");

        /*for (int i = 0; i < Esteet.Length; i++)
        {
            //estes = Esteet[i].gameObject.GetComponent<Este>();

            
        }*/

        //StartThings();

        bCollider.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z - 8.07f);
        //Debug.Log(frontColliders.Length);
        if (startButtonS.GameStartForMapControll == true || playerCollidedFcollider == true)
        {
            isObjectsPicked = false;
            PositionCheck();
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
