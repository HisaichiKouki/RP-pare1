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
                if (field[j, i] == null)
                {
                    if (respawnTime[j, i] == 0)
                    {
                        boxField[j, i] = Instantiate(Box, new Vector3(j * 2 - kFieldCols, 0, i * 2 - kFieldRows), Quaternion.identity);
                        boxField[j, i].transform.SetParent(transform, false);
                    }
                    respawnTime[j, i] += Time.deltaTime;
                    if (respawnTime[j, i] >= kRespawnTIme)
                    {
                        field[j, i] = Instantiate(Hole1, new Vector3(j * 2 - kFieldCols, 0, i * 2 - kFieldRows), Quaternion.identity);
                        field[j, i].transform.SetParent(transform, false);
                        respawnTime[j, i] = 0;
                    }
                }
                else
                {
                    Destroy(boxField[j, i]);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isScored = true;
            other.GetComponent<PlayerScript>().SetJumpPower(20);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isScored = false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        isScored = true;
    //        collision.rigidbody.GetComponent<PlayerScript>().SetJumpPower(20);
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        isScored = false;
    //    }
    //}
}
