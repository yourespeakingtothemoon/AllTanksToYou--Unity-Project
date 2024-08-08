using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramophoneAnim : MonoBehaviour
{
    [SerializeField] GameObject arm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate arm at 78 rpm

        arm.transform.Rotate(Vector3.back * Time.deltaTime * 78);


    }
}
