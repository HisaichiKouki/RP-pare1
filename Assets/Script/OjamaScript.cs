using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OjamaScript : MonoBehaviour
{

    public float kMoveSpeed;

    private Vector2 moveDirection;
    public Vector2 burstPower;
    Rigidbody rb;

    /// <summary>
    /// オジャマの場所と移動方向を設定する。方向は-1で左,1で右
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="dire"></param>
    public void InitPosDire(Vector3 pos, Vector2 dire)
    {
        transform.position = pos;        
        moveDirection = dire.normalized;
        
    }
    public void SetMoveDire(Vector2 direction) { moveDirection = direction; }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection.x = 1;//テスト用。実際にはInitで場所と移動方向を決める。
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection.magnitude == 0)
        {
            Debug.LogError("オジャマの移動方向が定められてません");
        }
        else
        {
            moveDirection *= kMoveSpeed;
            Vector3 velocity = new Vector3(moveDirection.x, 0, moveDirection.y);
            rb.velocity = velocity;
        }
       

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("burst");
        if (other.gameObject.tag == "Clone")
        {


            Vector3 burstVector = new Vector3(moveDirection.x * burstPower.x, burstPower.y, moveDirection.y * burstPower.x);

            other.gameObject.GetComponent<Rigidbody>().velocity = burstVector;
        }
    }
  
}
