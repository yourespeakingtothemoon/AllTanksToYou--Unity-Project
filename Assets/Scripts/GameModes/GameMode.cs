using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameGoalType
{
    None,
    Defeat,
    Score,
    Race,
    Survive,
    Objective
}


public interface IgamePlayerData
{
}

public abstract class GameMode : MonoBehaviour
{
    [SerializeField] protected PlayerInput playerPrefab;
   [SerializeField] protected GameGoalType goalType = GameGoalType.None;
   [SerializeField] protected List<Player> players = new List<Player>();
   [SerializeField] protected GameRules gameRules = new GameRules();
    [SerializeField] public float TimeLimit = 300.0f;
    [SerializeField] protected TimerText timerText;
    protected float timeRemaining;

   public void EndGame()
   {
    Debug.Log("Game Over");
       // End Game
   }

   public abstract string  GetRemain();
    public abstract string  GetTime();

    public abstract void Initalize();
    public abstract void RemoveEnemy(Enemydummy enemy);

    public abstract void EndGame(string winCondition);

    public abstract void ProcessGameEnd();
}
