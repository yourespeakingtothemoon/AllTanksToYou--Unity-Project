using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapPlane : MonoBehaviour
{
    [SerializeField] WrapPlane partner_wrapPlane;
    [SerializeField] bool isXWrap;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (partner_wrapPlane != null)
        {
           //tele in front of other wrap plane
            Quaternion planeDir = partner_wrapPlane.transform.rotation;
            Vector3 planePos = partner_wrapPlane.transform.position;
            Vector3 pla = planePos;
            Vector3 colPos = collision.transform.position;
            if (isXWrap)
            {
              if (planeDir.y > 0)
                {
                    colPos.x = pla.x + 2;
                }
                else
                {
                    colPos.x = pla.x - 2;
                }
            }
            else
            {
                //determine if plane is facing north or south
                if (planeDir.y > 0)
                {
                    colPos.z = pla.z - 2;
                }
                else
                {
                    colPos.z = pla.z + 2;
                }
             
            }
          
            collision.transform.position = colPos;
        }
    }
}
