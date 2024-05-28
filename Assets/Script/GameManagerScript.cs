using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxTime;
    float gameTimer;

    [SerializeField, Header("ƒvƒŒƒCƒ„[—‰º‚ÉŒ¸‚ç‚·•b”")] private float damegeCount;
    public TextMeshProUGUI text;

    bool isFinish;
    void Start()
    {
        gameTimer = MaxTime;
        isFinish = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isFinish)
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer <=0)
            {
                isFinish = true;
            }
        }
        text.SetText("Time" +gameTimer.ToString("f1"));

    }

    public void IsDamage() { gameTimer -= damegeCount; }
}
