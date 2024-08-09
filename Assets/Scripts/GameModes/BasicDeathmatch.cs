using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public struct dmPlayerData : IgamePlayerData 
{
    [SerializeField]public int stock;
    public int kills;
    [SerializeField]public int deaths;


}

public struct dmPlayerDataWrapper : IgamePlayerData
{
    public dmPlayerData data;
    public dmPlayerDataWrapper(dmPlayerData playerData)
    {
        this.data = playerData;
    }
  

}


public class BasicDeathmatch : GameMode
{
    [SerializeField] int stock = 3;
    [SerializeField] GameObject[] TestRespawnPoints;
    int playerCount = 0;

    private List<dmPlayerData> playerData = new List<dmPlayerData>();
    [SerializeField] PlayerInputManager playerInputManager;

    [SerializeField] TextMeshProUGUI[] player1TestingStock;
    [SerializeField] TextMeshProUGUI[] player2TestingStock;
void Start()
    {
        PlayerInput playerInput;
      for(int i = 0; i < MPData.NumberOfPlayers; i++)
        {
        dmPlayerData player = new dmPlayerData();
        player.stock = stock;
        player.deaths = 0;
        playerData.Add(player);
        playerInput = Instantiate(playerPrefab);

        playerInput.gameObject.GetComponent<PlayerComponent>().playerData = player;
        playerInput.gameObject.transform.position = TestRespawnPoints[playerCount].transform.position;
        playerInput.gameObject.GetComponent<PlayerComponent>().assignedRespawnPoint = TestRespawnPoints[playerCount];
        playerInput.gameObject.GetComponent<PlayerComponent>().stockTexts = playerCount == 0 ? player1TestingStock : player2TestingStock;
        playerInput.gameObject.GetComponent<PlayerComponent>().PlayID = i + 1;
        playerInput.gameObject.tag = playerCount == 0 ? "Player1" : "Player2";
        //playerInput.gameObject.GetComponent<PlayerComponent>().playerData 
        playerInput.gameObject.GetComponent<PlayerComponent>().pData = new dmPlayerDataWrapper(player);
        
        playerCount++;
        }
        timeRemaining = TimeLimit;
        //
    }



   void Update()
    {
     timeRemaining -= Time.deltaTime;
     timerText.UpdateTime(timeRemaining);
        if (timeRemaining <= 0)
        {
            EndGame();
        }
       
    }

    public override string GetRemain()
    {
        return "";
    }

    public override string GetTime()
    {
        return "";
    }

    public override void Initalize()
    {
        Player[] players = FindObjectsOfType<Player>();
        foreach (Player player in players)
        {
            this.players.Add(player);
        }
    }

    public override void RemoveEnemy(Enemydummy enemy)
    {
        throw new System.NotImplementedException();
    }


}
