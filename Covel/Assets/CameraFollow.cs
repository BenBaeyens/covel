using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;
    [SerializeField] float followSpeed;

    #region Methods

   private void LateUpdate() {
       gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position - offset, followSpeed * Time.deltaTime); 
   }

    #endregion
}
