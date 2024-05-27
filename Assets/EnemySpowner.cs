using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpowner : MonoBehaviour
{
    [SerializeField]private GameObject spownObj;
    public GameObject centerObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Clone")
        {
            
            Vector3 newPosition = collision.transform.position;
            newPosition.y = 10;
            Vector2 newDire = new Vector2(centerObj.transform.position.x- collision.transform.position.x,
                centerObj.transform.position.y - collision.transform.position.z);
            Debug.Log("newDire" + newDire);
            GameObject spown = Instantiate(spownObj);
            spown.GetComponent<OjamaScript>().InitPosDire(newPosition, newDire);

            Destroy(collision.gameObject);
            return;
        }
    }
}
