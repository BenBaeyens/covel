using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAppear : MonoBehaviour
{

    [SerializeField] float additionalFloorHeight;

    GameManager gameManager;

    
    float newspeed;

    GameObject player;

    bool isSummoning = false;
 
    Vector3 finalPos;

    #region methods


    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        finalPos = transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y - gameManager.floorHeight, transform.position.z);

        }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("Summon");
            

       
        if(isSummoning)
            FloorMoveUp();
    }

    private void FloorMoveUp()
    {
        transform.position = Vector3.Lerp(transform.position, finalPos, gameManager.floorSpeed * Time.deltaTime);
        newspeed *= 1.001f;

        if (transform.position.y >= finalPos.y - 0.01f)
        {
            transform.position = finalPos;
            isSummoning = false;
            Destroy(Instantiate(gameManager.floorFinishParticles, transform.position, transform.rotation, transform), 5f);
        }
    }

    private IEnumerator Summon(){
        yield return new WaitForSeconds(Vector3.Distance(player.transform.position, finalPos) / gameManager.floorSpawnSpeed); 
        newspeed = gameManager.floorSpeed;
        isSummoning = true;
        
    }
    #endregion
}
