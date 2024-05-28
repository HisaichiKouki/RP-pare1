using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.XR;
using UnityEngine;

public class FieldScoreScript : MonoBehaviour
{
    private int scoreCount;
    private int score;
    private bool isScored;
    public float burstJumpPower;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isScored)
        {

        }
        if (scoreCount != 0)
        {
            {
                score = scoreCount * 10;
                scoreCount = 0;
            }
        }
        Debug.Log(score);
        Debug.Log("FieldIsScored" + isScored);

        //GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");

        //foreach (GameObject clone in clones)
        //{
        //    clone.GetComponent<CloneScript>().SetIsScored(false);
        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        isScored = true;
    //        //other.gameObject.GetComponent<PlayerScript>().ObjectJump(burstJumpPower);
    //        //プレイヤーの子のコライダーから親のリジットボディを取得
    //        //Rigidbody newVelocity = other.transform.parent.GetComponent<Rigidbody>();
    //        // 親のリジットボディのvelocityの値を変えてる
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

    public bool IsScored() { return isScored; }

    public void SetIsScored(bool isScored) { this.isScored = isScored; }
}
