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
                     
            holeSize = colSphere.transform.localScale.x;
            holeSize -= 0.02f;//�g��T�C�Y���������������ăK�N�K�N���Ȃ��悤�ɂ���
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
                    //�T�C�Y���}�b�N�X�ɂȂ�����F��ς���
                    SetMatColor(transform.GetComponent<MeshRenderer>(), Color.yellow);
                }
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollisionSphere"|| other.gameObject.tag == "CollisionSphere_OutSide" )
        {
            isCollision = true;
            colSphere = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CollisionSphere" || other.gameObject.tag == "CollisionSphere_OutSide")
        {
            isCollision = false;
            SetMatColor(transform.GetComponent<MeshRenderer>(), Color.white);
            transform.localScale = new Vector3(holeSize - 0.5f, holeSize - 0.5f, holeSize - 0.5f);
        }
    }

    //public void SetIsScored(bool isScored) { this.isScored = isScored; }

    public bool GetIsMaxScale() { return isMaxScale; }

    void SetMatColor(MeshRenderer mesh, Color col)
    {
        mesh.material.color = col; //mesh��material�̐F��ς���
    }
}
