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
        color = GetComponent<Renderer>().material.color;
        color.a = 0f;
        GetComponent<Renderer>().material.SetInt("_ZWrite", 1);
    }
 
     private void Update() {
       
        
 
        if(color.a < 255){
            color.a += fadePerSecond * Time.deltaTime;
          GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, color.a);
        }
      
       if(Input.GetKeyDown(KeyCode.Space))
            GetComponent<Renderer>().material.color = new Color(50, 50, 255, 0f);
         
     }
 





    #endregion
}
