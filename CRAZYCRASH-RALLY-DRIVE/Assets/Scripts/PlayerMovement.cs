using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private float leftRightSpeed = 2f;

    private GameObject Player;

    private int osumat = 0;

    private float PlayerRotationY;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        //Player.transform.Rotate(0f, 0f, 0f);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            //Rotate();
            //Player.transform.Rotate(0f, -20f, 0f);
            //for (int i = 0; i> 0)
            /*Player.transform.rotation.y = PlayerRotationY;
            if(PlayerRotationY => -20f){
                Player.transform.rotation.y = -20f;
            }*/
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            //Player.transform.Rotate(0f, 20f, 0f);
        }
    }
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Este"))
        {
            Debug.Log("Moro!");
        }
    }*/
    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Este"))
        {

            osumat++;
            Debug.Log("Osuma");
        }
        if (osumat == 3)
        {
            Destroy(gameObject);
        }
    }
    
    /*private void Rotate()
    {
        Player.transform.rotation = -20f;
    }*/
}
