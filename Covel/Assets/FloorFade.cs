using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFade : MonoBehaviour
{
    [SerializeField] float fadePerSecond;
    Material material;
    Color color;

    #region Methods
    

    void start(){
        color.a = 0f;
    }
 
     private void Update() {
        color = GetComponent<Renderer>().material.color;
         GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, color.a + fadePerSecond * Time.deltaTime);
         if(Input.GetKeyDown(KeyCode.Space)){
             GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0f);
         }
     }
 

    #endregion
}
