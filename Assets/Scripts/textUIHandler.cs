using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textUIHandler : MonoBehaviour
{
    private gameController gameController;

    public Text rule;
    public Text score;
    public Text level;
    public Text gameOver;

    void Start()
    {
        gameOver.gameObject.SetActive(false);

        gameController = GameObject.FindObjectOfType<gameController>();

        updateRuleText();
        updateScoreText();
        updateLevelText();
        enableGameOverText(false);
    }

    void Update()
    {
        
        
        level.text = "Level: " + gameController.level.ToString();
    }

    public void updateRuleText()
    {
        rule.text = "Rule: " + gameController.currentRule;
    }

    public void updateScoreText()
    {
        score.text = "Score: " + gameController.score.ToString();
    }

    public void updateLevelText()
    {
        level.text = "Level: " + gameController.level.ToString();
    }

    public void enableGameOverText(bool isActive)
    {
        if(gameOver.gameObject.activeSelf == false)
        {
            gameOver.gameObject.SetActive(isActive);
        }
    }
}
