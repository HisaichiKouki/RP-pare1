using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjamaSpownScript : MonoBehaviour
{
    [SerializeField, Header("スポーンするオブジェクト")] GameObject spownObj;

    bool isSpown;
    OjamaScript ojamaScript;
    public void SetIsSpown(bool setSpown) {  isSpown = setSpown; }

    // Start is called before the first frame update
    void Start()
    {
        ojamaScript= spownObj.GetComponent<OjamaScript>();
        isSpown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isSpown)
        {
            
        }
    }
}
