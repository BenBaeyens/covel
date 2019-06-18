using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAppear : MonoBehaviour
{

    public float height;
    public float speed;

    public GameObject player;

    bool canSummon = false;
    bool isSummoning = false;
    bool hasSummoned = false;


    Vector3 finalPos;

    #region methods


    private void Start() {
        player = GameObject.Find("Player");
            }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasSummoned)
            canSummon = true;

        if(canSummon)
            Summon();
    }

    private IEnumerator SummonDelay(){
        yield return new WaitForSeconds(Vector3.Distance(player.transform.position, transform.position)); 
    }

    private void Summon()
    {
        float newspeed = speed;
        if (!isSummoning)
        {
            finalPos = transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y - height, transform.position.z);
            isSummoning = true;
        }
        transform.position = Vector3.Lerp(transform.position, finalPos, speed * Time.deltaTime);
        newspeed *= 1.001f;

        if (transform.position.y >= finalPos.y - 0.01f)
        {
            transform.position = finalPos;
            canSummon = false;
            isSummoning = false;
        }
        
    }

    #endregion
}
