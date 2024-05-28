using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    private bool isCollision;
    private GameObject colSphere;

    GameObject targetObj;
    private FieldScript fieldScript;
    private bool isScored;
    float holeSize;
    [SerializeField] bool isChange = true;

    // public static HoleScript instance;

    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("Field");
        fieldScript = targetObj.GetComponent<FieldScript>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollision)
        {
            //if (isChange == false)
            //{
            //    transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);

            //    if ((colSphere.transform.localScale.x * colSphere.transform.parent.localScale.x) <= transform.localScale.x)
            //    {
            //        colSphere.transform.parent.GetComponent<HoleScript>().SetIsScored(true);
            //        Destroy(this.gameObject);
            //    }
            //}

            isScored = fieldScript.IsScored();
            holeSize = colSphere.transform.localScale.x;
            holeSize -= 0.02f;//ägëÂÉTÉCÉYÇè≠Çµè¨Ç≥Ç≠ÇµÇƒÉKÉNÉKÉNÇµÇ»Ç¢ÇÊÇ§Ç…Ç∑ÇÈ
            if (transform.localScale.x< holeSize)
            {
                transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
                Debug.Log("expansion ");
                //colSphere.transform.parent.GetComponent<HoleScript>().SetIsScored(true);
                //Destroy(this.gameObject);
                //
            }
            else
            {
                if (transform.localScale.x > holeSize)
                {
                    transform.localScale = new Vector3(holeSize, holeSize, holeSize);
                }
                
                if (isScored)
                {
                    Destroy(this.gameObject);
                }
            }

           
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "CollisionSphere")
        {
            isCollision = true;
            colSphere = other.gameObject;
        }
        //if (other.gameObject.tag == "Field")
        //{
        //    field = other.gameObject;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        // Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "CollisionSphere")
        {
            isCollision = false;
        }
    }

    public void SetIsScored(bool isScored) { 
        this.isScored = isScored;
    }
}
