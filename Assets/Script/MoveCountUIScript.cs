using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCountUIScript : MonoBehaviour
{
    
    [SerializeField]private GameObject[] m_gameObject;
    MoveCountcript m_script;
    // Start is called before the first frame update
    void Start()
    {
        m_script=FindAnyObjectByType<MoveCountcript>();
    }

    // Update is called once per frame
    void Update()
    {

        m_gameObject[m_script.GetmoveCount()].SetActive(true);
        for (int i = 0; i < m_gameObject.Length; i++)
        {
            if (m_script.GetmoveCount()==0)
            {
                m_gameObject[i].SetActive(false);
            }
        }
       

    }
}
