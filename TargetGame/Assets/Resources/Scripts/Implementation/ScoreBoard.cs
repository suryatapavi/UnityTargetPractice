using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this is a script to be attached to a scoreboard 
// this allows different events and gameobjects to update scores on the scoreboard

public class ScoreBoard : MonoBehaviour, IScoreboard
{
    public static ScoreBoard scoreBoard;

    public Text ControlActions;
    public Text Scoreboard;
    private string ScoreBoardText;
    private string ControlText;

    void Awake()
    {
        scoreBoard = this;
        if (GameObject.Find("Controller").GetComponent<IController>() != null)
        {
            ControlText = GameObject.Find("Controller").GetComponent<IController>().ControlActions().ToString();
        }
        ScoreBoardText = Scoreboard.text;
    }

    public void UpdateText(string updateText, float[] Rewards)
    {
        for (int i = 0; i < Rewards.Length; i++)
        {
            ScoreBoardText=ScoreBoardText.Replace("???", Rewards[i].ToString());
        }
        Scoreboard.text = ScoreBoardText;
        ControlActions.text = ControlText + updateText;

    }


}
