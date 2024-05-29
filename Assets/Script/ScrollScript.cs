using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    public float scrollSpeed;
    string propName = "_MainTex";
    Vector2 offset;
   public Material myMaterial;
    PlayerScript playerScript;

    public float eseTime;

    Vector3 maxSize =new Vector3(1.5f,1.5f,1.5f);
    float easeT;
    Vector3 UIsize;
    // Start is called before the first frame update
    void Start()
    {
        playerScript=FindAnyObjectByType<PlayerScript>();
        easeT = 0;
        UIsize = maxSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.GetnowSphere()<=1)
        {
            easeT += Time.deltaTime / eseTime;
        }
        else
        {
            easeT -= Time.deltaTime / eseTime;

        }

        easeT=Mathf.Clamp(easeT, 0, 1);
        UIsize = Vector3.Lerp(maxSize, Vector3.one, easeT);
        transform.localScale = UIsize;
        offset.y += scrollSpeed*Time.deltaTime;
        myMaterial.SetTextureOffset("_MainTex", offset);
    }
}
