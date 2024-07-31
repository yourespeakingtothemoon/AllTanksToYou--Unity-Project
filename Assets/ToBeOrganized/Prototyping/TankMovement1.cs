using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovementNew : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    TankToYou m_InputActions;


    float yPedal =0;
    float xPedal=0;
    Quaternion currentRotationForce =Quaternion.identity;
    Vector3 currentMovementForce = Vector3.zero;
    [SerializeField] private float m_Speed = 12f;
    [SerializeField] private float m_TurnSpeed = 180f;
    [SerializeField] private GameObject m_Barrel;
    [SerializeField] private GameObject m_BulletPrefab;
    [SerializeField] private Reticle m_Reticle;


    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        
       


    }
    // Update is called once per frame
    void Update()
    {
        Rotate(xPedal);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * currentRotationForce);
        Onward(yPedal);
        m_Rigidbody.MovePosition(m_Rigidbody.position + currentMovementForce);
       
      
  Vector3 lookAt = new Vector3(m_Reticle.gameObject.transform.position.z, m_Barrel.transform.position.y, m_Reticle.gameObject.transform.position.z);
   m_Barrel.transform.LookAt(lookAt);
        


    }

   public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Move");
        Vector2 direction = context.ReadValue<Vector2>();
       float x = direction.x;
        float y = direction.y;
        yPedal = y;
        xPedal = x;

    }


    void Onward(float accel)
    {
        currentMovementForce = accel * m_Speed * Time.deltaTime * transform.forward;

    }

    void Rotate(float turn)
    {
       // float turnSpeed = turn * m_Speed * Time.deltaTime;
        float turnSpeed = turn * m_TurnSpeed * Time.deltaTime;
        currentRotationForce = Quaternion.Euler(0f, turnSpeed, 0f);
    }

   public void Shoot()
    {
        Instantiate(m_BulletPrefab, m_Barrel.transform.position, m_Barrel.transform.rotation);
    }
}
