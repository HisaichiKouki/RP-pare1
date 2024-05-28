using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpowner : MonoBehaviour
{
    [SerializeField] private GameObject spownObj;

    List<GameObject> enemys = new List<GameObject>();
    GameObject targetObj;
    private FieldScript fieldScript;

    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("Field");
        fieldScript = targetObj.GetComponent<FieldScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (fieldScript.IsScored())
        {

            Debug.Log("Touch");
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
        }
    }
}
