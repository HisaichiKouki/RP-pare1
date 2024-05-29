using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SpherCollider2Clone : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleprefab;
    //ParticleSystem particle;
    GameObject parent;
    FieldScoreScript parentScript;
    GameObject hitObj;

   // public GameObject particleObject;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Field3");
        parentScript = parent.GetComponent<FieldScoreScript>();
        //burstJumpPower = parentScript.burstJumpPower;
    }

    // Update is called once per frame
    void Update()
    {
        if (parentScript.IsScored())
        {
            if (hitObj != null)
            {
                if (hitObj.GetComponent<CloneScript>().GetIsMaxScale())
                {
                    if (this.tag == "CollisionSphere")
                    {
                        parentScript.AddScoreCount(1);
                        Debug.Log("addScore 1");
                        particleprefab.Play();
                        Destroy(hitObj);
                    }
                    else if (this.tag == "CollisionSphere_OutSide")
                    {
                        parentScript.AddScoreCount(10);
                        Debug.Log("addScore 2");
                        particleprefab.Play();
                        Destroy(hitObj);
                    }
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
}
