using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class newField : MonoBehaviour
{
    private int scoreCount;
    private int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (isScored)
        //{
        //    foreach (Transform child in transform)
        //    {
        //        if (child.GetComponent<HoleScript>().IsMaxScale())
        //        {
        //            Debug.Log(child.tag);
        //            if (child.gameObject.tag == "Hole")
        //            {
        //                scoreCount++;
        //            }
        //            if (child.gameObject.tag == "OutSideHole")
        //            {
        //                scoreCount += 2;
        //            }
        //        }
        //    }
        //    Debug.Log(scoreCount);
        //}

        if (scoreCount != 0)
        {
            score = scoreCount * 10;
            scoreCount = 0;
        }
        Debug.Log(score);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        isScored = true;
    //        //other.gameObject.GetComponent<PlayerScript>().ObjectJump(burstJumpPower);
    //        //�v���C���[�̎q�̃R���C�_�[����e�̃��W�b�g�{�f�B���擾
    //        //Rigidbody newVelocity = other.transform.parent.GetComponent<Rigidbody>();
    //        // �e�̃��W�b�g�{�f�B��velocity�̒l��ς��Ă�
    //        // newVelocity.velocity = new Vector3(newVelocity.velocity.x, 20, newVelocity.velocity.z);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        isScored = false;
    //    }
    //}

    public void AddScoreCount(int score) { scoreCount += score; }

    public void SetScoreZero() { scoreCount = 0; }

    public int GetScore() { return score; }
}
