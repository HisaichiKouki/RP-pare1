using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpowner : MonoBehaviour
{
    [SerializeField] private GameObject spownObj;

    List<GameObject> enemys = new List<GameObject>();
    GameObject targetObj;
    private FieldScoreScript fieldScript;
    GameObject timerObj;

    // Start is called before the first frame update
    void Start()
    {
        timerObj= GameObject.Find("GameManager");
        targetObj = GameObject.Find("Field3");
        fieldScript = targetObj.GetComponent<FieldScoreScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (fieldScript.IsScored())
        {

            
            for (int i = enemys.Count - 1; i >= 0; i--)
            {
                if (enemys[i].transform.GetChild(0).gameObject.activeSelf)
                {
                    Destroy(enemys[i].gameObject);
                    enemys.RemoveAt(i);
                }

            }

        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Clone")
        {

            Vector3 newPosition = collision.transform.position;
            newPosition.y = 10;
            Vector2 newDire = new Vector2(targetObj.transform.position.x - collision.transform.position.x,
                targetObj.transform.position.y - collision.transform.position.z);
            //Debug.Log("newDire" + newDire);
            GameObject spown = Instantiate(spownObj);
            spown.GetComponent<OjamaScript>().InitPosDire(newPosition, newDire);
            enemys.Add(spown);
            Destroy(collision.gameObject);
            return;
        }else if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector3(0, 10, 0);
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            timerObj.GetComponent<GameManagerScript>().IsDamage();
        }
    }
}
