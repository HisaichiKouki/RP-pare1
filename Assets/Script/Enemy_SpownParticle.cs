using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SpownParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particlePrefab;

    OjamaScript target;

    bool spownParticle;
    // Start is called before the first frame update
    void Start()
    {
        target=FindAnyObjectByType<OjamaScript>();
        spownParticle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.GetIsDead())
        {
            if (!spownParticle)
            {
                particlePrefab.Play();
                Debug.Log("isDead");
            }
            spownParticle = true;
           
        }
    }
}
