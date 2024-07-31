using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleControl : MonoBehaviour
{

    [SerializeField] public bool usingMouse;
    [SerializeField] Color color;
    [SerializeField] float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if(usingMouse)
        {
            transform.position = Input.mousePosition;
        }
        
    }

    public void SetColor(Color newColor)
    {
        gameObject.GetComponent<Image>().color = newColor;
        color = newColor;
    }

    public void Move(Vector2 direction)
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * moveSpeed;
    }
}
