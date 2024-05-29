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
        
    }

   

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

       

    }

   

   

    

    public bool IsMaxScale() { return this.isMaxScale; }
}


