using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textUIHandler : MonoBehaviour
{
    public static gameController gameController;

    public Text rule;
    public Text score;
    public Text level;
    public Text gameOver;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<gameController>();
        gameOver.gameObject.SetActive(false);

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
        gameController = GameObject.FindObjectOfType<gameController>();
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
