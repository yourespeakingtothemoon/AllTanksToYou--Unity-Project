using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Profile profile;
    int lives = 3;
    int score = 0;
    int health = 100;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void subtractLife()
    {
        lives--;
        if (lives <= 0)
        {
            // Game Over
        }
    }
}
