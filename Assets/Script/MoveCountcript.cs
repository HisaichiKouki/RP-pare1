using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCountcript : MonoBehaviour
{
    public GameObject targetObj;
    PlayerScript playerScript;
    int moveCount;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        moveCount = 0;
        playerScript= targetObj.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        newPos = transform.position;
        newPos.y = targetObj.transform.position.y;
        transform.position = newPos;
        AddSphere();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            moveCount++;
            transform.position = targetObj.transform.position;
            //Debug.Log("MoveCount" + moveCount);
        }
    }
  
    void AddSphere()
    {
        if (moveCount >= playerScript.GetAddCount())
        {
            playerScript.AddSphere();
            moveCount = 0;
           // Debug.Log("écíiêî" + playerScript.GetnowSphere());
        }
    }


}
