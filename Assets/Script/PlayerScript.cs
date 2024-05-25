using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("説明")]
    [SerializeField, TextArea] string description1;

    Rigidbody rigidbody_;
    public float speed;
    [Header("移動方法")]
    [SerializeField] private bool moveType;
    [SerializeField,TextArea] string description2;

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
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x;

        rigidbody_ = GetComponent<Rigidbody>();

        //クローン生成場所を子から参照してる。0から数える
        shotPosition = transform.GetChild(2).gameObject;
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
            Debug.Log("Shot");
            GameObject clon = Instantiate(cloneObj);
            clon.transform.position = shotPosition.transform.position;
            clon.GetComponent<Rigidbody>().velocity = rigidbody_.velocity * shotSpeed;
            shotCount = kShotCoolTime;
            stopCount = kStopTime;
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
}
