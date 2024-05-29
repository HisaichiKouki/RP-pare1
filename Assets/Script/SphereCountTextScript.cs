using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SphereCountTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerScript playerScript;
    TextMeshProUGUI text;
    void Start()
    {
        playerScript = FindAnyObjectByType<PlayerScript>();
        text=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText("BULLET\n"+playerScript.GetnowSphere());
    }
}
