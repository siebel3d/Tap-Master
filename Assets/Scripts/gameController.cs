using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{

    public int level = 1;
    public int ruleCount = 0;
    public int randomRule;
    public int ruleCountLevel;
    public int minRuleCount = 2;
    public int maxRuleCount = 6;
    public int score;
    public float speed;
    public float spawnTime;
    public float leftScreenLimit;
    public float rightScreenLimit;
    public string[] rule;
    public string currentRule;
    public string oldRule = "null";

    public GameObject spawner;
    public GameObject leftLimiter;
    public GameObject rightLimiter;

    private textUIHandler textUIHandler;

    void Start()
    {
        textUIHandler = GameObject.FindObjectOfType<textUIHandler>();

        score = 0;
        level = 1;
        speed = 1;
        rule = new string[] { "Blue Circle", "Blue Cube", "Blue Triangle", "Pink Circle", "Pink Cube", "Pink Triangle", "Yellow Circle", "Yellow Cube", "Yellow Triangle"};
        RandomRule();

        leftLimiter.transform.position = new Vector2(leftScreenLimit, 0);
        rightLimiter.transform.position = new Vector2(rightScreenLimit, 0);
    }

    void Update()
    {
        textUIHandler.updateRuleText();

        Debug.Log("Rule: " + currentRule + " |Count: " + ruleCount + " |Count Max: " + ruleCountLevel + " |Level: " + level);

        if (ruleCount < 0 && level > 1)
        {
            textUIHandler.updateLevelText();
            textUIHandler.updateRuleText();
            level--;
            ruleCount = 0;
            RandomRule();
        }

        if (ruleCount < 0) ruleCount = 0;

        if (ruleCount == ruleCountLevel)
        {
            textUIHandler.updateLevelText();
            textUIHandler.updateRuleText();
            level++;
            ruleCount = 0;
            RandomRule();
        }


    }

    void RandomRule()
    {
        ruleCountLevel = Random.Range(minRuleCount, maxRuleCount);

        randomRule = Random.Range(0, 9);

        currentRule = rule[randomRule];
        ruleCount = 0;
        /*if (randomRule == 0)
        {
            currentRule = rule[0];
            ruleCount = 0;
        }
        else if (randomRule == 1)
        {
            currentRule = rule[1];
            ruleCount = 0;
        }
        else if (randomRule == 2)
        {
            currentRule = rule[2];
            ruleCount = 0;
        }*/

        Debug.Log(currentRule);
        Debug.Log(ruleCount);

        textUIHandler.updateRuleText();
    }

    public void GameOver()
    {
        textUIHandler.enableGameOverText(true);
        Debug.Log("GAME OVER");
    }
}
