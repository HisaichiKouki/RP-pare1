using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("説明")]
    [SerializeField, TextArea] string description1;

    Rigidbody rigidbody_;
    public float speed;
    public float jumpPower;
    [Header("移動方法")]
    [SerializeField] private bool moveType;
    [SerializeField,TextArea] string description2;

    [SerializeField, Header("何カウント移動したら玉を補充するか")] private int addCount;
    [SerializeField,Header("残弾数")] private int nowSpherCount;
    [SerializeField,Header("玉上限")] private int sphereLimit;




    [Header("発射するクローン関連")]
    public GameObject cloneObj;
    public float shotSpeed;
    public float kShotCoolTime;//ショット後次に撃てるまでの時間
    float shotCount;
    public float kStopTime;//ショット後プレイヤーの動きを止める時間
    float stopCount;
    GameObject shotPosition;

    float scale;//speedやdistanceをスケールに合わせて調整する

    public float GetScale() { return scale; }
    public int GetAddCount() { return addCount; }
    public void AddSphere() { if (nowSpherCount < sphereLimit) { nowSpherCount++; } }
    public int GetnowSphere() { return nowSpherCount; }
    public void SetnowSphere(int value) {  nowSpherCount=value; }
    // Start is called before the first frame update
    void Start()
    {
       
        scale = transform.localScale.x;

        rigidbody_ = GetComponent<Rigidbody>();

        //クローン生成場所を子から参照してる。0から数える
        shotPosition = transform.GetChild(0).gameObject;
        shotCount = 0;
        stopCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();
        Stop();
    }
    void Shot()
    {

        //クールタイムが残ってたらリターン
        if (shotCount >= 0)
        {
            shotCount -= Time.deltaTime;
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if(nowSpherCount>0)
            {
                Debug.Log("Shot");
                GameObject clon = Instantiate(cloneObj);
                clon.transform.position = shotPosition.transform.position;
                Vector3 newVector = rigidbody_.velocity * shotSpeed;
                newVector.y = -jumpPower;
                clon.GetComponent<Rigidbody>().velocity = newVector;
                shotCount = kShotCoolTime;
                stopCount = kStopTime;
                rigidbody_.velocity = new Vector3(0, jumpPower, 0);

                nowSpherCount--;
            }
           
           // Debug.Log("残段数" + nowSpherCount);
        }
    }

    void Stop()
    {
        //残り時間が0以下ならリターン
        if (stopCount <= 0)
        {
            return;
        }
        //0以上ならプレイヤーの動きを止める
        stopCount -= Time.deltaTime;
        rigidbody_.velocity = new Vector3(0, rigidbody_.velocity.y, 0);
    }
    private void Move()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 velocity = movement * speed * Time.deltaTime;
        if (moveType)
        {
            rigidbody_.AddForce(velocity);

        }
        else
        {
            rigidbody_.velocity = new Vector3(velocity.x*5, rigidbody_.velocity.y, velocity.z * 5);
        }

    }

    //この関数でスクリプト外からジャンプする
    public void ObjectJump(float setJumpPower) { rigidbody_.velocity = new Vector3(rigidbody_.velocity.x, setJumpPower, rigidbody_.velocity.z); }
    public void SetJumpPower(float jumpPower) { this.jumpPower = jumpPower; }
}
