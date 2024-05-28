using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    static int kFieldRows = 5;
    static int kFieldCols = 5;
    [SerializeField] int kRespawnTIme = 2;
    GameObject[,] field = new GameObject[kFieldCols, kFieldRows];
    GameObject[,] boxField = new GameObject[kFieldCols, kFieldRows];
    float[,] respawnTime = new float[kFieldCols, kFieldRows];
    [SerializeField] GameObject Hole1;
    [SerializeField] GameObject Box;
    private bool isScored;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < kFieldRows; i++)
        {
            for (int j = 0; j < kFieldCols; j++)
            {
                field[j, i] = Instantiate(Hole1, new Vector3(j * 2 - kFieldCols, 0, i * 2 - kFieldRows), Quaternion.identity);
                field[j, i].transform.SetParent(transform, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < kFieldRows; i++)
        {
            for (int j = 0; j < kFieldCols; j++)
            {
                //field[j, i].GetComponent<HoleScript>().SetIsScored(isScored);
                //if (field[j, i] == null)
                //{
                //    if (respawnTime[j, i] == 0)
                //    {
                //        boxField[j, i] = Instantiate(Box, new Vector3(j * 2 - kFieldCols, 0, i * 2 - kFieldRows), Quaternion.identity);
                //        boxField[j, i].transform.SetParent(transform, false);
                //        isScored = false;
                //    }
                //    respawnTime[j, i] += Time.deltaTime;
                //    if (respawnTime[j, i] >= kRespawnTIme)
                //    {
                //        field[j, i] = Instantiate(Hole1, new Vector3(j * 2 - kFieldCols, 0, i * 2 - kFieldRows), Quaternion.identity);
                //        field[j, i].transform.SetParent(transform, false);
                //        respawnTime[j, i] = 0;
                //    }
                //}
                //else
                //{
                //    Destroy(boxField[j, i]);
                //}

                field[j, i].GetComponent<HoleScript>().SetIsScored(isScored);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isScored = true;
            other.gameObject.GetComponent<PlayerScript>().ObjectJump(20);
            //プレイヤーの子のコライダーから親のリジットボディを取得
            //Rigidbody newVelocity = other.transform.parent.GetComponent<Rigidbody>();
            // 親のリジットボディのvelocityの値を変えてる
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

    public bool IsScored (){ return isScored; }
}
