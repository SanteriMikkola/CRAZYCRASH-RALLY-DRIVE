using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControll : MonoBehaviour
{
    private GameObject Player;

    public GameObject[] Esteet;

    public GameObject[] frontColliders;
    private GameObject bCollider;

    /*private BoxCollider fBoxCollider;
    private BoxCollider bBoxCollider;
    */

    private int i = 0, ii = 0, iii = 0;

    //public float[] vectorsF; 

    public Vector3[] vector3s;

    public Vector3[]  Obs_vectors;

    public GameObject[] PickedObjects;

    private Vector3 AreaVector1 = new Vector3(0f, 3.18f, 23f);
    private Vector3 AreaVector2 = new Vector3(0f, 3.18f, 46f);

    private bool isObjectsPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        
        bCollider = GameObject.Find("BackCollider");

        //fBoxCollider = fCollider.GetComponent<BoxCollider>();
        //bBoxCollider = bCollider.GetComponent<BoxCollider>();

        bCollider.transform.parent = null;

    }

    // Update is called once per frame
    void Update()
    {
        Esteet = GameObject.FindGameObjectsWithTag("Este");
        StartThings();

        bCollider.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z - 8.07f);
        //Debug.Log(frontColliders.Length);
        PositionCheck();
        ObsCheck();
        //fCollider.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z + 48.5f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    private void StartThings()
    {
        frontColliders = GameObject.FindGameObjectsWithTag("MapCfront");
        while (i != frontColliders.Length)
        {
            frontColliders[i].transform.parent = null;

            i++;
        }
        return;
    }

    private void PositionCheck()
    {
        //vectorsF = new float[frontColliders.Length];
        vector3s = new Vector3[frontColliders.Length];

        for (int i = 0; i < frontColliders.Length; i++)
        {
            vector3s[i].Set(frontColliders[i].transform.position.x, frontColliders[i].transform.position.y, frontColliders[i].transform.position.z);
            //vectorsF[i] = frontColliders[i].transform.position.z;
        }
        Obs_vectors = new Vector3[Esteet.Length];
        if (!isObjectsPicked)
        {
            for (int i = 0; i < Esteet.Length; i++)
            {
                Obs_vectors[i].Set(Esteet[i].transform.position.x, Esteet[i].transform.position.y, Esteet[i].transform.position.z);

                if (Obs_vectors[i].z > AreaVector1.z && Obs_vectors[i].z < AreaVector2.z)
                {
                    ii++;
                }
            }
        }
        isObjectsPicked = true;
        PickedObjects = new GameObject[ii];
        for (int i = 0; i < Esteet.Length; i++)
        {
            //Obs_vectors[i].Set(Esteet[i].transform.position.x, Esteet[i].transform.position.y, Esteet[i].transform.position.z);

            if (Obs_vectors[i].z > AreaVector1.z && Obs_vectors[i].z < AreaVector2.z)
            {
                if (i < ii)
                {
                    PickedObjects[i] = Esteet[i]; //!
                }
            }
            
        }
        return;
    }

    private void ObsCheck()
    {
        /*Obs_vectors = new Vector3[Esteet.Length];
        for (int i = 0; i < Esteet.Length; i++)
        {
            Obs_vectors[i].Set(Esteet[i].transform.position.x, Esteet[i].transform.position.y, Esteet[i].transform.position.z);

            if (Obs_vectors[i].z > AreaVector1.z && Obs_vectors[i].z < AreaVector2.z)
            {
                PickedObjects[i] = Esteet[i];
            }

        }
        return;*/
    }
}
