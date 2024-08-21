using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float m_Speed = 12f;
    [SerializeField] private float lifetime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * m_Speed;
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit");   
        if (other.gameObject.tag != gameObject.tag)
        {
            if(other.gameObject.GetComponent<PlayerComponent>() != null)
            {
                other.gameObject.GetComponent<PlayerComponent>().LoseStock();
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != gameObject.tag)
        {
             if(collision.gameObject.GetComponent<PlayerComponent>() != null)
            {
                collision.gameObject.GetComponent<PlayerComponent>().LoseStock();
            }
           

        }

         if(collision.gameObject.tag == "Ricochet")
            {
                Vector3 normal = collision.contacts[0].normal;
                Vector3 reflect = Vector3.Reflect(transform.forward, normal);
                transform.forward = reflect;
            }

    }

}
