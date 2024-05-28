using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendereScript : MonoBehaviour
{
    [SerializeField, Header("�n�_")] private GameObject originObj;
    [SerializeField, Header("�I�_")] private GameObject endObj;
    LineRenderer linerend;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private AnimationCurve _animationCurve;
    Vector3[] positions = new Vector3[2];
    // Start is called before the first frame update
    void Start()
    {
        positions[0]=originObj.transform.position;
        positions[1]= endObj.transform.position;

        linerend = gameObject.AddComponent<LineRenderer>();
        linerend.positionCount=positions.Length;
        linerend.material = new Material(Shader.Find("Sprites/Default"));
        //�F���w�肷��
        linerend.colorGradient = _gradient;
        linerend.widthCurve = _animationCurve;
        linerend.SetPositions(positions);

    }

    // Update is called once per frame
    void Update()
    {
        positions[0] = originObj.transform.position;
        positions[1] = endObj.transform.position;
        linerend.SetPositions(positions);

    }
}
