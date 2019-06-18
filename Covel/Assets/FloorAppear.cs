using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAppear : MonoBehaviour
{

    public float height;
    public float platformSpeed;
    public float spawnSpeed;
    float newspeed;

    public GameObject player;

    bool canSummon = false;
    bool isSummoning = false;
    bool hasSummoned = false;


    Vector3 finalPos;

    #region methods


    private void Start() {
        player = GameObject.Find("Player");
        finalPos = transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y - height, transform.position.z);

        }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasSummoned)
            canSummon = true;

        if (canSummon)
            StartCoroutine("SummonDelay");
        if(isSummoning)
            SummonMove();
    }

    private void SummonMove()
    {
        transform.position = Vector3.Lerp(transform.position, finalPos, platformSpeed * Time.deltaTime);
        newspeed *= 1.001f;

        if (transform.position.y >= finalPos.y - 0.01f)
        {
            transform.position = finalPos;

            isSummoning = false;
        }
    }

    private IEnumerator SummonDelay(){
        canSummon = false;
        yield return new WaitForSeconds((Vector3.Distance(player.transform.position, finalPos) / spawnSpeed)); 
        Summon();
    }

    private void Summon()
    {
        if (!isSummoning)
        {
            newspeed = platformSpeed;
            isSummoning = true;
        }
        
    }

    #endregion
}
