using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTestScript : MonoBehaviour
{
    [SerializeField] private GameObject particle;

    void Update()
    {
        particle.transform.position = transform.position;
        //スペースキーを押すとparticleを再生
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(particle);
        };
        //if (Input.GetKeyDown(KeyCode.Space)) particle.Play();

        //左シフトキーをクリックするとparticleを停止
       // if (Input.GetKeyDown(KeyCode.LeftShift)) particle.Stop();
    }
}
