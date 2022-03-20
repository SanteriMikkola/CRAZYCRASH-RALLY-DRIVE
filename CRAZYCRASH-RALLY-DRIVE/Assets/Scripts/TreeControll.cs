using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeControll : MonoBehaviour
{
    private Este esteS;
    private TrunkControll trunks;
    private MeshRenderer meshRenderer;

    void Start()
    {
        esteS = gameObject.GetComponentInChildren<Este>();
        trunks = gameObject.GetComponentInChildren<TrunkControll>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();

        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (esteS.isColliderUnActive == true)
        {
            gameObject.SetActive(false);
            trunks.SetTrunkInActive();
            //Destroy(gameObject);
        }
        if (esteS.activateMesh == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
            trunks.SetTrunkActive();
        }
    }
}
