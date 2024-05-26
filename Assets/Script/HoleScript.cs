using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    private bool isScored = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isScored)
        {
            Destroy(gameObject);
        }
    }

    public void SetIsScored(bool isScored) { this.isScored = isScored; }
    public bool IsScored() { return this.isScored; }
}
