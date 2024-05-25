using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShotPointScript : MonoBehaviour
{
    public GameObject player;
    public float distance;
    Vector2 inputVector;
    Vector3 newPosition;
    Vector3 velocity;
    [SerializeField, Header("ƒVƒ‡ƒbƒg‚ÌêŠ‚ª“ü—ÍŠî€(ture)‚©velocityŠî€(false)‚©")] private bool shotType;
    // Start is called before the first frame update
    void Start()
    {
       
        newPosition = player.transform.right* distance;
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
       
        
        
        if (shotType)
        {
            if (inputVector.magnitude > 0)
            {
                newPosition = new Vector3(inputVector.x, 0, inputVector.y).normalized * distance;
            }
        }else
        {
            velocity = player.GetComponent<Rigidbody>().velocity;
            velocity.y = 0;
            if (velocity.magnitude>0.1f)
            {
                newPosition = velocity.normalized * distance;
            }
            
        }

        transform.position = player.transform.position+newPosition;
    }
}
