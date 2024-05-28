using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEditor.XR;
using UnityEngine;

public class FieldScoreScript : MonoBehaviour
{
    private int scoreCount;
    private int score;
    private bool isScored;
    public float burstJumpPower;
    bool calculation;
    static public int tortalScore;
    GameManagerScript gameManagerScript;

    public TextMeshProUGUI scoreText;  
    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText("Score:" + tortalScore);
        gameManagerScript=FindAnyObjectByType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //先に計算をしたかのフラグを立てて、計算をしてたらisScoredをfalseにする
        if (calculation)
        {
            isScored = false;
            calculation = false;
        }
        if (!gameManagerScript.IsFinish())
        {
            if (isScored)
            {
                calculation = true;
                if (scoreCount != 0)
                {
                    {
                        score = scoreCount * 10;
                        scoreCount = 0;
                        tortalScore += score;
                    }
                }
                Debug.Log("nowScore=" + tortalScore);
                scoreText.SetText("Score:" + tortalScore);
            }
        }
       
       
       
       

       
    }

    

    public void AddScoreCount(int value) { scoreCount += value; }

    public void SetScoreZero() { scoreCount = 0; }

    public int GetScore() { return score; }

    public bool IsScored() { return isScored; }

    public void SetIsScored(bool isScored) { this.isScored = isScored; }
}
