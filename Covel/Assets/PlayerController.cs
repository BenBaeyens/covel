using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float playerMoveSpeed;


    Rigidbody playerRb;
    float horizontal;
    float vertical;

    #region Methods

    private void Start() {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update() {
         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector3(horizontal * playerMoveSpeed, playerRb.velocity.y, vertical * playerMoveSpeed);
         

    }

    #endregion
}
