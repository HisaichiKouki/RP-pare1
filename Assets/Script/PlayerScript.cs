using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("����")]
    [SerializeField, TextArea] string description1;

    Rigidbody rigidbody_;
    public float speed;
    public float jumpPower;
    [Header("�ړ����@")]
    [SerializeField] private bool moveType;
    [SerializeField,TextArea] string description2;

    [SerializeField, Header("���J�E���g�ړ�������ʂ��[���邩")] private int addCount;
    [SerializeField,Header("�c�e��")] private int nowSpherCount;
    [SerializeField,Header("�ʏ��")] private int sphereLimit;




    [Header("���˂���N���[���֘A")]
    public GameObject cloneObj;
    public float shotSpeed;
    public float kShotCoolTime;//�V���b�g�㎟�Ɍ��Ă�܂ł̎���
    float shotCount;
    public float kStopTime;//�V���b�g��v���C���[�̓������~�߂鎞��
    float stopCount;
    GameObject shotPosition;

    float scale;//speed��distance���X�P�[���ɍ��킹�Ē�������

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

        //�N���[�������ꏊ���q����Q�Ƃ��Ă�B0���琔����
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

        //�N�[���^�C�����c���Ă��烊�^�[��
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
           
           // Debug.Log("�c�i��" + nowSpherCount);
        }
    }

    void Stop()
    {
        //�c�莞�Ԃ�0�ȉ��Ȃ烊�^�[��
        if (stopCount <= 0)
        {
            return;
        }
        //0�ȏ�Ȃ�v���C���[�̓������~�߂�
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

    //���̊֐��ŃX�N���v�g�O����W�����v����
    public void ObjectJump(float setJumpPower) { rigidbody_.velocity = new Vector3(rigidbody_.velocity.x, setJumpPower, rigidbody_.velocity.z); }
    public void SetJumpPower(float jumpPower) { this.jumpPower = jumpPower; }
}
