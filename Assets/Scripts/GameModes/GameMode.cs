using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameGoalType
{
    None,
    Defeat,
    Score,
    Race,
    Survive,
    Objective
}

public abstract class GameMode : MonoBehaviour
{
   [SerializeField] protected GameGoalType goalType = GameGoalType.None;
   [SerializeField] protected List<Player> players = new List<Player>();
   [SerializeField] protected GameRules gameRules = new GameRules();
    [SerializeField] public float TimeLimit = 300.0f;

   public void EndGame()
   {
    Debug.Log("Game Over");
       // End Game
   }

   public abstract string  GetRemain();
    public abstract string  GetTime();

    public abstract void Initalize();
    public abstract void RemoveEnemy(Enemydummy enemy);

}
