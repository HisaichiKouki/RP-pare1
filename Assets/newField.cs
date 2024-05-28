using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    [SerializeField] GameObject Hole1;
    private bool isScored;

    public float burstJumpPower;

    private int scoreCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isScored = true;
            other.gameObject.GetComponent<PlayerScript>().ObjectJump(burstJumpPower);
            //�v���C���[�̎q�̃R���C�_�[����e�̃��W�b�g�{�f�B���擾
            //Rigidbody newVelocity = other.transform.parent.GetComponent<Rigidbody>();
            // �e�̃��W�b�g�{�f�B��velocity�̒l��ς��Ă�
            // newVelocity.velocity = new Vector3(newVelocity.velocity.x, 20, newVelocity.velocity.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isScored = false;
        }
    }

    public bool IsScored() { return isScored; }
}
