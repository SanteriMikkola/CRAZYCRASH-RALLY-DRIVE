using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private GameObject fColliders;

    private BoxCollider col;

    private MapControll mapControll;

    public bool activeSafe = false;

    public bool reBackSafe = false;

    public bool disableSafe = false;

    private bool enable_ColMesh = true;

    private float time = 0;
    private float timeDelay = 2f;

    private void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();

        fColliders = GameObject.FindGameObjectWithTag("MapCfront");
        mapControll = fColliders.GetComponent<MapControll>();

        col = this.gameObject.GetComponent<BoxCollider>();

        meshRenderer.enabled = false;
    }


    private void Update()
    {
        if (enable_ColMesh == false)
        {
            time = time + 1f * Time.deltaTime;

            if (time >= timeDelay)
            {
                col.enabled = true;
                meshRenderer.enabled = true;
                enable_ColMesh = true;
                time = 0;
            }
        }

        if (reBackSafe == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = false;
            reBackSafe = false;
        }

        if (activeSafe == true && disableSafe == false)
        {
            gameObject.SetActive(true);

            if (enable_ColMesh)
            {
                meshRenderer.enabled = true;
            }
            
        }
        if (activeSafe == false && disableSafe == true)
        {
            gameObject.SetActive(false);
            meshRenderer.enabled = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            meshRenderer.enabled = false;
            col.enabled = false;
            enable_ColMesh = false;
            this.gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("MapCback"))
        {
            meshRenderer.enabled = false;
            gameObject.SetActive(false);

            activeSafe = false;
            //isColliderUnActive = true;
        }
        /*if (collision.gameObject.CompareTag("MapCfront"))
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
        }*/
    }
}
