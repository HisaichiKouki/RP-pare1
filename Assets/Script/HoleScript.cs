using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    private bool isScored = false;
    private bool isMaxScale;
    private float burstJumpPower;

    GameObject parent;
    FieldScoreScript parentScript;
    GameObject hitObj;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Field3");
        parentScript=parent.GetComponent<FieldScoreScript>();
        burstJumpPower = parentScript.burstJumpPower;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isScored && isCollision)
        //{
        //    Destroy(gameObject);
        //}
        if (parentScript.IsScored())
        {
            if (hitObj != null)
            {
                if (this.tag == "Hole")
                {
                    Debug.Log("addScore 1");
                    Destroy(hitObj);
                }
                else if (this.tag == "OutSideHole")
                {
                    Debug.Log("addScore 2");
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clone")
        {
            hitObj = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == hitObj)
        {
            
            hitObj = null;
        }
    }
  

    public void SetIsScored(bool isScored) { this.isScored = isScored; }
    public bool IsScored() { return this.isScored; }

    public bool IsMaxScale() { return this.isMaxScale; }
}
