using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResultManagerScript : MonoBehaviour
{
    public string retrySceneName;
    public string nextSceneName;


    float selectInput;
    bool isRetrySelect;

    public GameObject scoreObj;
    TextMeshProUGUI scoreText;

    float finalScore;
    int nowScore;
    float easeT;
    public float MaxEaseTime;

    public float textScaleSize = 2;
    public GameObject retryText;
    public GameObject titleText;
    public GameObject selectText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreObj.gameObject.GetComponent<TextMeshProUGUI>();
        nowScore = 0;
        easeT = 0;
        isRetrySelect = true;
        finalScore = FieldScoreScript.tortalScore;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCountUP();
        scoreText.SetText("Score" + nowScore);
        SceneSelect();
    }

    void ScoreCountUP()
    {
        if (easeT >= 1) { return; }
        easeT += Time.deltaTime / MaxEaseTime;
        if (easeT >= 1) { easeT = 1; }
        nowScore = (int)Mathf.Lerp(0, finalScore, EaseOutQuart(easeT));
    }

    void SceneSelect()
    {
        selectInput = Input.GetAxis("Horizontal");
        //selectInput=(int)input;
        Debug.Log("Input" + selectInput);

        //左にリトライ、右にタイトルを想定
        if (selectInput < 0)
        {
            isRetrySelect = true;
        }
        else if (selectInput > 0)
        {
            isRetrySelect = false;
        }
        if (isRetrySelect)
        {
            retryText.transform.localScale = new Vector3(textScaleSize, textScaleSize, textScaleSize);
            titleText.transform.localScale = Vector3.one;

            selectText.transform.position = new Vector3(
                retryText.transform.position.x, selectText.transform.position.y, selectText.transform.position.z);
        }
        else
        {
            retryText.transform.localScale = Vector3.one;
            titleText.transform.localScale = new Vector3(textScaleSize, textScaleSize, textScaleSize);

            selectText.transform.position = new Vector3(
                titleText.transform.position.x, selectText.transform.position.y, selectText.transform.position.z);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isRetrySelect)
            {
                Debug.Log("retry");
                FadeManager.Instance.LoadScene("HisaScene", 1.0f);
            }
            else
            {
                Debug.Log("title");
                FadeManager.Instance.LoadScene("TitleScene", 1.0f);
            }
        }
    }

    float EaseOutQuart(float x)
    {
        return 1 - Mathf.Pow(1 - x, 4);
    }
}
