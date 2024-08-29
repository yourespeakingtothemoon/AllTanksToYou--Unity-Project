using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterswing : MonoBehaviour
{
[SerializeField] float swingSpeed = 0.5f;
bool swingDirection = true;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
      //Update zaxis rotation

      //go a little one direction and then start turning the other

        if(swingDirection){
            transform.Rotate(0,swingSpeed,swingSpeed);
        }else{
            transform.Rotate(0,-swingSpeed,-swingSpeed);
        }

        if(transform.rotation.z > 0.05){
            swingDirection = false;
        }else if(transform.rotation.z < -0.05){
            swingDirection = true;
        }

    }
}
