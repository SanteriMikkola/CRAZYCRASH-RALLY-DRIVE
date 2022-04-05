using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrassControll : MonoBehaviour
{
    private GameObject fColliders;

    private MapControll mapControll;

    private MeshRenderer meshRenderer;

    public bool activeGrass = false;
    public bool rebackGrass = false;

    // Start is called before the first frame update
    void Start()
    {
        fColliders = GameObject.FindGameObjectWithTag("MapCfront");
        mapControll = fColliders.GetComponent<MapControll>();

        meshRenderer = gameObject.GetComponent<MeshRenderer>();

        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rebackGrass == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = false;
            rebackGrass = false;
        }

        if (activeGrass == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapCback"))
        {
            meshRenderer.enabled = false;
            gameObject.SetActive(false);

            activeGrass = false;
            //isColliderUnActive = true;
        }
    }
}
