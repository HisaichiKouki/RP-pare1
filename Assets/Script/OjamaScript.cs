using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OjamaScript : MonoBehaviour
{

    [SerializeField] private ParticleSystem particleprefab;
    public float kMoveSpeed;
    private Vector2 moveDirection;
    [Header("����")]
    [SerializeField, TextArea] string description1;
    public Vector2 burstPower;
    Rigidbody rb;
    private bool isDead;
    bool spownParticle;
    float deadTimer;

    FieldScoreScript fieldScoreScript;
    public GameObject child;
    
    public void SetMoveDire(Vector2 direction) { moveDirection = direction; }
    // Start is called before the first frame update
    void Start()
    {
        fieldScoreScript=FindAnyObjectByType<FieldScoreScript>();
        deadTimer = 0;
        isDead = false;
        rb = GetComponent<Rigidbody>();
        moveDirection.x = 1;//�e�X�g�p�B���ۂɂ�Init�ŏꏊ�ƈړ����������߂�B
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection.magnitude == 0)
        {
            Debug.LogError("�I�W���}�̈ړ���������߂��Ă܂���");
        }
        else
        {
          
            Vector3 velocity = new Vector3(moveDirection.x, 0, moveDirection.y);
            rb.velocity = velocity;
        }
       
        if (fieldScoreScript.IsScored())
        {
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                isDead = true;
              
                particleprefab.transform.position= transform.GetChild(0).gameObject.transform.position;
                particleprefab.Play();
                transform.GetChild(1).transform.localScale = Vector3.zero;
            }
           
           
        }

        if (isDead)
        {
            rb.velocity = Vector3.zero;
            deadTimer += Time.deltaTime;
            if (deadTimer > 1)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clone")
        {
            Debug.Log("burst");


            Vector3 burstVector = new Vector3(moveDirection.x * burstPower.x, burstPower.y, moveDirection.y * burstPower.x);

            other.gameObject.GetComponent<Rigidbody>().velocity = burstVector;
        }
    }

    /// <summary>
    /// �I�W���}�̏ꏊ�ƈړ�������ݒ肷��B������-1�ō�,1�ŉE
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="dire"></param>
    public void InitPosDire(Vector3 pos, Vector2 dire)
    {
        transform.position = pos;
        moveDirection = dire;
        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            moveDirection.y = 0;
        }
        else if (Mathf.Abs(moveDirection.x) < Mathf.Abs(moveDirection.y))
        {
            moveDirection.x = 0;
        }
        else
        {
            moveDirection = Vector2.one;
        }
        moveDirection = moveDirection.normalized * kMoveSpeed;

    }
    public void IsDeadtrue() { isDead = true; }
    public bool GetIsDead() { return isDead; }
}
