using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    public float scrollSpeed;
    string propName = "_MainTex";
    Vector2 offset;
   public Material myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += scrollSpeed*Time.deltaTime;
        myMaterial.SetTextureOffset("_MainTex", offset);
    }
}
