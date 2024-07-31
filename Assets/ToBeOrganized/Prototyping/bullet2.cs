using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    [SerializeField] private float m_timer = 12f;
 
    // Start is called before the first frame update
    void Start()
    {
     
    }

    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            Destroy(gameObject);
        }
    }

}
