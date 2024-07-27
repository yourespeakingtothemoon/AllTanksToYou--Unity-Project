using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetsUI : UIManager
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI remainText;
    [SerializeField] TextMeshProUGUI winText;

    void Update()
    {
        timerText.text = mode.GetTime();
        remainText.text = mode.GetRemain();
        if (mode.TimeLimit <= 0)
        {
            winText.text = "Time's up!";
            winText.gameObject.SetActive(true);
            mode.EndGame();
        }

        if (mode.GetRemain() == "0")
        {
            winText.text = "You win!";
            winText.gameObject.SetActive(true);
            mode.EndGame();
        }
    }
}
