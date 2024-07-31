using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    TankToYou m_InputActions;


    float yPedal =0;
    float xPedal=0;
    Quaternion currentRotationForce;
    Vector3 currentMovementForce;
    [SerializeField] private float m_Speed = 12f;
    [SerializeField] private float m_TurnSpeed = 180f;
    [SerializeField] private GameObject m_Barrel;
    [SerializeField] private GameObject m_BulletPrefab;


    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //map controls
        m_InputActions = new TankToYou();
        // Enable the tank controls
        m_InputActions.Tank.Enable();
        m_InputActions.Tank.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        m_InputActions.Tank.Movement.canceled += ctx => Move(Vector2.zero);
        m_InputActions.Tank.Shoot.performed += ctx => Shoot();
        m_InputActions.Tank.Reset.performed += ctx => Reset();

    }
    // Update is called once per frame
    void Update()
    {
        Rotate(xPedal);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * currentRotationForce);
        Onward(yPedal);
        m_Rigidbody.MovePosition(m_Rigidbody.position + currentMovementForce);
        Ray ray = Camera.main.ScreenPointToRay(m_InputActions.Tank.Aim.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 lookAt = new Vector3(hit.point.x, m_Barrel.transform.position.y, hit.point.z);
            m_Barrel.transform.LookAt(lookAt);
        }


    }

    void Move(Vector2 direction)
    {
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

    void Shoot()
    {
        Instantiate(m_BulletPrefab, m_Barrel.transform.position, m_Barrel.transform.rotation);
    }
    void Reset()
    {
        transform.position = transform.position + new Vector3(0, 2, 0);
        transform.rotation = Quaternion.identity;
    }
}