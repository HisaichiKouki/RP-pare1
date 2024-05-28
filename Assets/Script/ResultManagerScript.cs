using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultManagerScript : MonoBehaviour
{
    public string retrySceneName;
    public string nextSceneName;


    float selectInput;
    bool isRetrySelect;

    float textScaleSize=2;
    public GameObject retryText;
    public GameObject titleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selectInput = Input.GetAxis("Horizontal");
        Debug.Log("Input" + selectInput);

        //左にリトライ、右にタイトルを想定
        if (selectInput <= 0)
        {
            isRetrySelect = true;
        }else
        {
            isRetrySelect = false;
        }
        if (isRetrySelect)
        {
            retryText.transform.localScale = new Vector3(textScaleSize, textScaleSize, textScaleSize);
            titleText.transform.localScale = Vector3.one;
        }
        else
        {
            retryText.transform.localScale = Vector3.one;
            titleText.transform.localScale = new Vector3(textScaleSize, textScaleSize, textScaleSize);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isRetrySelect) 
            {
                Debug.Log("retry");
            }else
            {
                Debug.Log("title");
            }
        }
        
    }
}
