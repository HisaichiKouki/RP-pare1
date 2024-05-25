using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    private bool isCollision;
    private GameObject colSphere;
    private bool isScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCollision)
        {
            transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
            if (colSphere.transform.localScale.x <= transform.localScale.x)
            {
                isScore = true;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag== "CollisionSphere")
        {
            isCollision = true;
            colSphere = other.gameObject;
        }
        else
        {
            isCollision = false;
        }
    }
}
