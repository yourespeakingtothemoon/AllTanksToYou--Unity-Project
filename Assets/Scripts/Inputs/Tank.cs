using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
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
    [SerializeField] public GameObject m_Reticle;
    [SerializeField] private Transform m_FirePoint;
    [SerializeField] public BulletFaction m_Faction;


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
       //look at reticle
        Ray ray = Camera.main.ScreenPointToRay(m_Reticle.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 lookAt = new Vector3(hit.point.x, m_Barrel.transform.position.y, hit.point.z);
            m_Barrel.transform.LookAt(lookAt);
        }


    }

    public void Move(Vector2 direction)
    {
       float x = direction.x;
        float y = direction.y;
        yPedal = y;
        xPedal = x;

    }


    public void Onward(float accel)
    {
        currentMovementForce = accel * m_Speed * Time.deltaTime * transform.forward;

    }

    public void Rotate(float turn)
    {
       // float turnSpeed = turn * m_Speed * Time.deltaTime;
        float turnSpeed = turn * m_TurnSpeed * Time.deltaTime;
        currentRotationForce = Quaternion.Euler(0f, turnSpeed, 0f);
    }

    public void Shoot()
    {
       
        GameObject bullet = Instantiate(m_BulletPrefab, m_FirePoint.transform.position, m_Barrel.transform.rotation);
        bullet.tag = gameObject.tag;
    }
    public void Reset()
    {
        transform.position = transform.position + new Vector3(0, 2, 0);
        transform.rotation = Quaternion.identity;
    }

    public void SetReticle(GameObject reticle)
    {
        m_Reticle = reticle;
    }
}