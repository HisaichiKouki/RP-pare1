using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxTime;
    float gameTimer;

    [SerializeField, Header("ÉvÉåÉCÉÑÅ[óéâ∫éûÇ…å∏ÇÁÇ∑ïbêî")] private float damegeCount;
    public TextMeshProUGUI text;

    public GameObject finishText;

    bool isFinish;
    void Start()
    {
        gameTimer = MaxTime;
        isFinish = false;
    }

    // Update is called once per frame
    void Update()
    {

        CountDown();

    }
    void CountDown()
    {
        if (isFinish)
        {
            return;
        }
        else
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer <= 0)
            {
                isFinish = true;
                finishText.SetActive(true);
            }
        }
        text.SetText("Time" + gameTimer.ToString("f1"));
    }

    public void IsDamage() { gameTimer -= damegeCount; }
}
