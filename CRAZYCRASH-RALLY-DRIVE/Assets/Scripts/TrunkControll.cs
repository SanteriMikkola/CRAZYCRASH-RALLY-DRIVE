using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkControll : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public void SetTrunkInActive()
    {
        gameObject.SetActive(false);
    }

    public void SetTrunkActive()
    {
        gameObject.SetActive(true);
        meshRenderer.enabled = true;
    }
}
