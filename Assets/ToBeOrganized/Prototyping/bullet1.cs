using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multishot : MonoBehaviour
{
    [SerializeField] private float m_Speed = 12f;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
       //create three bullet prefabs one going forward, one going left, one going right
         //forward
        GameObject go = Instantiate(prefab);
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        //left
        GameObject go1 = Instantiate(prefab);
        go1.transform.position = transform.position;
        go1.transform.rotation = transform.rotation * Quaternion.Euler(0, 45, 0);
        //right
        GameObject go2 = Instantiate(prefab);
        go2.transform.position = transform.position;
        go2.transform.rotation = transform.rotation * Quaternion.Euler(0, -45, 0);
    }

}
