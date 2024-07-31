using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class PlayerComponent : MonoBehaviour
{
    [SerializeField] private Tank m_Tank;
    [SerializeField] private Canvas m_Canvas;
    [SerializeField] private GameObject ReticlePrefab;
    [SerializeField] private PlayerInput m_PlayerInput;
    // Start is called before the first frame update
    void Start()
    {
        m_Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        GameObject reticle = Instantiate(ReticlePrefab, m_Canvas.transform);
        m_Tank.SetReticle(reticle);
        if (m_PlayerInput == null)
        {
            m_PlayerInput = GetComponent<PlayerInput>();
        }
        m_Tank.m_Faction = m_PlayerInput.user.id == 1 ? BulletFaction.red : BulletFaction.blue;

        m_Tank.m_Reticle.GetComponent<ReticleControl>().SetColor(m_Tank.m_Faction == BulletFaction.red ? Color.red : Color.blue);

        if(m_PlayerInput.devices[0].displayName == "Keyboard" || m_PlayerInput.devices[0].displayName == "Mouse")
        {
            m_Tank.m_Reticle.GetComponent<ReticleControl>().usingMouse = true;
        }
        else
        {
            m_Tank.m_Reticle.GetComponent<ReticleControl>().usingMouse = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player Input Calls
    public void Move(InputAction.CallbackContext context)
    {
        m_Tank.Move(context.ReadValue<Vector2>());
    }

    public void Shoot()
    {
        m_Tank.Shoot();
    }

    public void Reset()
    {
        m_Tank.Reset();
    }

    public void Aim(InputAction.CallbackContext context)
    {
        m_Tank.m_Reticle.GetComponent<ReticleControl>().Move(context.ReadValue<Vector2>());
    }

}
