using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    [SerializeField] int KrespawnTime;
    [SerializeField] int respawnTime;

    GameObject clone;
    GameObject colSphere;

    // Start is called before the first frame update
    void Start()
    {
        colSphere = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if ((colSphere.transform.localScale.x * transform.localScale.x) <= clone.transform.localScale.x)
        {
            gameObject.SetActive(false);
            Destroy(clone.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Clone")
        {
            clone = other.gameObject;
        }
    }
}
