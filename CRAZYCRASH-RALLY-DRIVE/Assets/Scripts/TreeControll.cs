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
    }

    // Update is called once per frame
    void Update()
    {
        if (esteS.isColliderUnActive == true)
        {
            gameObject.SetActive(false);
            trunks.SetTrunkInActive();
        }
        if (esteS.activateMesh == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
            trunks.SetTrunkActive();
        }
    }
}
