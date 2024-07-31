using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Reticle : MonoBehaviour
{

    TankToYou m_inputActions;
    [SerializeField] bool usingController = false;
    // Start is called before the first frame update
    [SerializeField] private float m_Speed = 24f;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveReticle(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        if (usingController)
        {
            MoveReticleWithController(direction);
        }
        else
        {
            MoveReticleToMouse(direction);
        }
    }

    void MoveReticleToMouse(Vector2 direction)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(direction.x, direction.y, 10));
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    void MoveReticleWithController(Vector2 direction)
    {
        Debug.Log("Move Reticle");
        Vector3 movement = new Vector3(direction.x, 0, direction.y) * m_Speed;
        transform.position += movement * Time.deltaTime;
    }
}
