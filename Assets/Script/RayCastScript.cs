using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{

    public float rayLength;
    public float rayDistance;//�ڕW�n�_�����O�ɐݒu���Ė��܂�Ȃ��悤��
    public GameObject reticleObj;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit[] hit=new RaycastHit[10];
        RaycastHit[] hit = Physics.RaycastAll(transform.position, Vector3.down, 100f);

       
        reticleObj.SetActive(false);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.CompareTag("HoleCollision1")|| hit[i].collider.CompareTag("HoleCollision_OutSide"))
            {

                //print("Found an object - distance: " + hit[i].distance);
                Debug.DrawRay(transform.position, Vector3.down * hit[i].distance, Color.red, 0.0f);
                Vector3 newPosition = transform.position;
                newPosition.y -= hit[i].distance- rayDistance;
                reticleObj.transform.position = newPosition;
                reticleObj.SetActive(true);
                return;

            }
        }


    }
}
