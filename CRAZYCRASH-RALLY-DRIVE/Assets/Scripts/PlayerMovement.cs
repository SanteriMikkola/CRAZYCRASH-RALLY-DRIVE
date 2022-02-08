using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float leftRightSpeed = 2f;

    private GameObject Player;
    private GameObject playerRotateL;
    private GameObject playerRotateR;
    private GameObject playerRotateF;

    public bool playerCollideWithOsb = false;

    public bool playerMoveLeft = false;
    public bool playerMoveRight = false;

    private int osumat = 0;

    private float PlayerRotationY;

    void Start()
    {
        Player = GameObject.Find("Player");
        playerRotateL = GameObject.Find("playerRotationL");
        playerRotateR = GameObject.Find("playerRotationR");
        playerRotateF = GameObject.Find("playerRotationF");
    }

    void Update()
    {
        if (playerCollideWithOsb == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
        if (playerCollideWithOsb == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 0f, Space.World);
        }
        Move();
    }

    private void Move()
    {
        //moveSpeed = 2.5f;
        Vector3 targetPoint3 = (playerRotateF.transform.position);
        Player.transform.LookAt(targetPoint3);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        //Player.transform.Rotate(0f, 0f, 0f);
        playerMoveLeft = false;
        playerMoveRight = false;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 targetPoint = (playerRotateL.transform.position);
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            Player.transform.LookAt(targetPoint);
            //moveSpeed -= 0.2f;
            playerMoveLeft = true;
            //Rotate();
            //Player.transform.Rotate(0f, -20f, 0f);
            /*for (int i = 0; i < 20; i++)
            {
                Player.transform.Rotate(0f, -1f, 0f);
            }*/
            /*Player.transform.rotation.y = PlayerRotationY;
            if(PlayerRotationY => -20f){
                Player.transform.rotation.y = -20f;
            }*/
            
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 targetPoint2 = (playerRotateR.transform.position);
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            Player.transform.LookAt(targetPoint2);
            //moveSpeed -= 0.2f;
            playerMoveRight = true;
            /*for (int i = 0; i < 20; i++)
            {
                Player.transform.Rotate(0f, 1f, 0f);
            }*/
            //Player.transform.Rotate(0f, 20f, 0f);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            Player.transform.LookAt(targetPoint3);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            transform.Translate(Vector3.left * Time.deltaTime * 0f);
            transform.Translate(Vector3.right * Time.deltaTime * 0f);
            playerMoveLeft = false;
            playerMoveRight = false;
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
            playerCollideWithOsb = true;
            osumat++;
            Debug.Log("Osuma");
            transform.Translate(Vector3.forward * Time.deltaTime * 0f, Space.World);
        }
        if (osumat == 3)
        {
            Destroy(gameObject);
            playerCollideWithOsb = false;
        }

    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Este"))
        {
            playerCollideWithOsb = false;
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
    }

    /*private void Rotate()
    {
        Player.transform.rotation = -20f;
    }*/
}