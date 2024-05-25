using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShotPointScript : MonoBehaviour
{
    public GameObject player;
    public float distance;
    Vector2 inputVector;
    Vector3 targetPos;
    Vector3 velocity;
    [SerializeField, Header("ƒVƒ‡ƒbƒg‚ÌêŠ‚ª“ü—ÍŠî€(ture)‚©velocityŠî€(false)‚©")] private bool shotType;
    float scale;
    bool isTouch;
    Vector3 newPos;
    public float easeT;
    
    // Start is called before the first frame update
    void Start()
    {
        scale = player.transform.localScale.x;
        targetPos = player.transform.right * distance * scale;
        isTouch = false;
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        scale = player.transform.localScale.x;
        float newDistance = distance * scale;
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");



        if (shotType)
        {
            if (inputVector.magnitude > 0)
            {
                targetPos = new Vector3(inputVector.x, 0, inputVector.y).normalized * newDistance;
            }
        }
        else
        {
            velocity = player.GetComponent<Rigidbody>().velocity;
            velocity.y = 0;
            if (velocity.magnitude > 0.1f)
            {
                targetPos = velocity.normalized * newDistance;
            }

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            isTouch = false;
        }
        Debug.Log("targetPos" + targetPos);

        newPos = transform.position;
        Vector3 newTargetPos = player.transform.position + targetPos;
        newPos.x = (1.0f - easeT) * transform.position.x + (newTargetPos.x) * easeT;
        newPos.z = (1.0f - easeT) * transform.position.z + (newTargetPos.z) * easeT;
        newPos.y = player.transform.position.y;
        transform.position = newPos;
        Debug.Log("newPos" + newPos);

    }

    private void OnCollisionEnter(Collision collision)
    {
        //isTouch = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isTouch = false;
    }
}
