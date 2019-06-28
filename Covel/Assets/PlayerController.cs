using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float playerMoveSpeed;
    [SerializeField] bool isCube;


    Rigidbody playerRb;
    float horizontal;
    float vertical;
    float upDown;

    #region Methods

    private void Start() {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update() {

        if(isCube)
            upDown = 1f;

         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector3(horizontal * playerMoveSpeed, playerRb.velocity.y - upDown, vertical * playerMoveSpeed);
         

    }

    #endregion
}
