using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTestScript : MonoBehaviour
{
    [SerializeField] private GameObject particle;

    void Update()
    {
        particle.transform.position = transform.position;
        //�X�y�[�X�L�[��������particle���Đ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(particle);
        };
        //if (Input.GetKeyDown(KeyCode.Space)) particle.Play();

        //���V�t�g�L�[���N���b�N�����particle���~
       // if (Input.GetKeyDown(KeyCode.LeftShift)) particle.Stop();
    }
}
