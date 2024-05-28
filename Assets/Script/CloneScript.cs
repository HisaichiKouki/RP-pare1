using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    private bool isCollision;
    private GameObject colSphere;

    GameObject targetObj;
    private FieldScoreScript fieldScript;
    private bool isMaxScale;
    float holeSize;
    [SerializeField] bool isChange = true;

    // public static HoleScript instance;

    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("Field3");
        fieldScript = targetObj.GetComponent<FieldScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollision)
        {
          

           
           // Debug.Log("IsScored" + fieldScript.IsScored());
            holeSize = colSphere.transform.localScale.x;
            holeSize -= 0.02f;//ägëÂÉTÉCÉYÇè≠Çµè¨Ç≥Ç≠ÇµÇƒÉKÉNÉKÉNÇµÇ»Ç¢ÇÊÇ§Ç…Ç∑ÇÈ
            if (transform.localScale.x < holeSize)
            {
                transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
                
            }
            else
            {
                isMaxScale = true;
                if (transform.localScale.x > holeSize)
                {
                    transform.localScale = new Vector3(holeSize, holeSize, holeSize);
                }

                //if (fieldScript.IsScored())
                //{
                //    if (this.gameObject != null)
                //    {
                //        Destroy(this.gameObject);
                //    }
                //}
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "CollisionSphere"|| other.gameObject.tag == "CollisionSphere_OutSide" )
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
        if (other.gameObject.tag == "CollisionSphere" || other.gameObject.tag == "CollisionSphere_OutSide")
        {
            isCollision = false;
        }
        //if(other.gameObject.tag == "Hole"|| other.gameObject.tag == "OutSideHole")
        //{
        //    other.GetComponent<Hole2PlayerScript>().SetIsScored(false);
        //}
    }

    //public void SetIsScored(bool isScored) { this.isScored = isScored; }

    public bool GetIsMaxScale() { return isMaxScale; }

}
