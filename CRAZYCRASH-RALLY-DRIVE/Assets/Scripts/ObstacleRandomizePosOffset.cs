using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizePosOffset : MonoBehaviour
{
    private GameObject Player;
    private CarCollider carCollider;

    public float offsetRange;

    
    void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();

        RandomizePos();
    }

    private void Update()
    {
        if (carCollider.reback_Obs == true)
        {
            RandomizePos();
        }
    }


    public void RandomizePos()
    {
        if (transform.parent != null)
        {
            Debug.Log("Testi");
            transform.position = new Vector3(transform.parent.position.x + Random.Range(-offsetRange, offsetRange), transform.position.y, transform.parent.position.z + Random.Range(-offsetRange, offsetRange));
        }
    }
}
