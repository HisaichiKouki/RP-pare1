using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Hole2PlayerScript : MonoBehaviour
{
    // private bool isScored = false;
    private bool isMaxScale;
    private float burstJumpPower;

    GameObject parent;
    FieldScoreScript parentScript;
    int a;

    private AudioSource hane;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Field3");
        parentScript=parent.GetComponent<FieldScoreScript>();
        burstJumpPower = parentScript.burstJumpPower;

        hane=gameObject.GetComponent<AudioSource>();
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
            // parent.GetComponent<newField>().SetIsScored(isScored);
        }
        else if (this.tag == "OutSideHole")
        {
            // transform.parent.gameObject.GetComponent<newField>().SetIsScored(isScored);
            // parent.GetComponent<newField>().SetIsScored(isScored);
        }
        // Debug.Log("IsScored" + isScored);
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        other.gameObject.GetComponent<PlayerScript>().ObjectJump(burstJumpPower);
    //        //isScored = true;
    //        other.gameObject.GetComponent<CloneScript>().SetIsScored(true);
    //    }

    //    //if (other.gameObject.tag == "Clone")
    //    //{
    //    //    //other.gameObject.GetComponent<CloneScript>().SetIsScored(isScored);
    //    //    isMaxScale = other.gameObject.GetComponent<CloneScript>().IsMaxScale();
    //    //}
    //    //if (other.gameObject.tag == "Player" && isMaxScale)
    //    //{
    //    //    if (this.tag == "Hole")
    //    //    {
    //    //        transform.parent.GetComponent<newField>().AddScoreCount(1);
    //    //        Debug.Log("ScoreUP");
    //    //    }
    //    //    if (this.tag == "OutSideHole") { transform.parent.GetComponent<newField>().AddScoreCount(2); }
    //    //}
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hane.Play();

            collision.gameObject.GetComponent<PlayerScript>().ObjectJump(burstJumpPower);
            parentScript.SetIsScored(true);
            //isScored = true;
            Debug.Log("hit");
        }

        //if (collision.gameObject.tag == "Clone" && collision.gameObject.tag == "Player")
        //{

        //    // collision.gameObject.GetComponent<CloneScript>().SetIsScored(isScored);
        //    isMaxScale = collision.gameObject.GetComponent<CloneScript>().IsMaxScale();
        //}
        //if (collision.gameObject.tag == "Player" && isMaxScale)
        //{
        //    if (this.tag == "Hole") { transform.parent.GetComponent<newField>().AddScoreCount(1); }
        //    if (this.tag == "OutSideHole") { transform.parent.GetComponent<newField>().AddScoreCount(2); }
        //}

    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        isScored = false;
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    //transform.parent.GetComponent<newField>().AddScoreCount(0);
        //    //transform.parent.GetComponent<newField>().SetScoreZero();
        //    parent.GetComponent<newField>().AddScoreCount(0);
        //    parent.GetComponent<newField>().SetScoreZero();
        //    //isScored = false;
        //}
    }

    // public void SetIsScored(bool isScored) { this.isScored = isScored; }
    //public bool IsScored() { return this.isScored; }

    public bool IsMaxScale() { return this.isMaxScale; }
}

//private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.tag == "Player")
//        {
//            Debug.Log("Touch");
//        }
//    }
//}
