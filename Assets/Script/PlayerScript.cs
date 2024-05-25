using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("����")]
    [SerializeField, TextArea] string description1;

    Rigidbody rigidbody_;
    public float speed;
    [Header("�ړ����@")]
    [SerializeField] private bool moveType;
    [SerializeField,TextArea] string description2;

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
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x;

        rigidbody_ = GetComponent<Rigidbody>();

        //�N���[�������ꏊ���q����Q�Ƃ��Ă�B0���琔����
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
        //�N�[���^�C�����c���Ă��烊�^�[��
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
}
