using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoints : MonoBehaviour
{
    private GameObject playerRotateL;
    private GameObject playerRotateR;
    private GameObject playerRotateF;
    private GameObject Player;

    private PlayerMovement playerMove;

    private float moveSpeed;
    private float leftRightSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRotateL = GameObject.Find("playerRotationL");
        playerRotateR = GameObject.Find("playerRotationR");
        playerRotateF = GameObject.Find("playerRotationF");
        Player = GameObject.Find("Player");

        playerMove = Player.GetComponent<PlayerMovement>();

        moveSpeed = playerMove.moveSpeed;
        leftRightSpeed = playerMove.leftRightSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = playerMove.moveSpeed * 2f;
        leftRightSpeed = playerMove.leftRightSpeed;

        if (playerMove.playerCollideWithOsb == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
        if (playerMove.playerMoveLeft == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }
        if (playerMove.playerMoveRight == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
        }
        /*if (playerMove.playerCollideWithOsb == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 0f, Space.World);
        }*/
    }
}
