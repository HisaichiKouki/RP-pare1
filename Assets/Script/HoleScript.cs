using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    private bool isScored = false;
    private bool isMaxScale;
    private float burstJumpPower;

    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent= GameObject.Find("Field3");
    }

    // Update is called once per frame
    void Update()
    {
        //if (isScored && isCollision)
        //{
        //    Destroy(gameObject);
        //}
        if (this.tag == "Hole")
        {
            //transform.parent.parent.gameObject.GetComponent<newField>().SetIsScored(isScored);
            parent.GetComponent<newField>().SetIsScored(isScored);
        }
        else if (this.tag == "OutSideHole")
        {
           // transform.parent.gameObject.GetComponent<newField>().SetIsScored(isScored);
            parent.GetComponent<newField>().SetIsScored(isScored);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Clone")
    //    {
    //        isCollision = true;
    //        collision.gameObject.GetComponent<CloneScript>().SetIsScored(isScored);
    //        isMaxScale = collision.gameObject.GetComponent<CloneScript>().IsMaxScale();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clone")
        {
            other.gameObject.GetComponent<CloneScript>().SetIsScored(isScored);
            isMaxScale = other.gameObject.GetComponent<CloneScript>().IsMaxScale();
        }
        if (other.gameObject.tag == "Player" && isMaxScale)
        {
            if (this.tag == "Hole") { transform.parent.GetComponent<newField>().AddScoreCount(1); }
            if (this.tag == "OutSideHole") { transform.parent.GetComponent<newField>().AddScoreCount(2); }
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerScript>().ObjectJump(burstJumpPower);
            isScored = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //transform.parent.GetComponent<newField>().AddScoreCount(0);
            //transform.parent.GetComponent<newField>().SetScoreZero();
            parent.GetComponent<newField>().AddScoreCount(0);
            parent.GetComponent<newField>().SetScoreZero();
            isScored = false;
        }
    }

    public void SetIsScored(bool isScored) { this.isScored = isScored; }
    public bool IsScored() { return this.isScored; }

    public bool IsMaxScale() { return this.isMaxScale; }
}
