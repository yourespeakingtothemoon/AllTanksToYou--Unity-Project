using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameMode gameMode;
   void EndGameEvent()
   {
       // End Game
        gameMode.EndGame();
   }
}
