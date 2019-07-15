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
        //rule = new string[] { "Blue Circle", "Pink Circle", "Blue Cube", "Pink Cube", "Yellow Circle", "Yellow Cube", "Blue Triangle", "Pink Triangle", "Yellow Triangle"};
        rule = new string[] { "Blue Circle", "Pink Circle", "Blue Cube", "Pink Cube"};
        RandomRule();
        leftLimiter.transform.position = new Vector2(leftScreenLimit, 0);
        rightLimiter.transform.position = new Vector2(rightScreenLimit, 0);
    }

    void Update()
    {
        if (oldRule == currentRule) RandomRule();
        //Debug.Log("Rule: " + currentRule + " |Count: " + ruleCount + " |Count Max: " + ruleCountLevel + " |Level: " + level);

        if (ruleCount < 0 && level > 1)
        {
            textUIHandler.updateLevelText();
            level--;
            ruleCount = 0;
            RandomRule();
        }

        if (ruleCount < 0) ruleCount = 0;

        if (ruleCount == ruleCountLevel)
        {
            textUIHandler.updateLevelText();
            level++;
            ruleCount = 0;
            RandomRule();
        }
        textUIHandler.updateRuleText();
    }

    void RandomRule()
    {
        oldRule = currentRule;
        if (level <= 4)
        {
            randomRule = Random.Range(0, 3);
            ruleCountLevel = 2;
        }
        if ((level > 4) && (level <= 7))
        {
            randomRule = Random.Range(0, 6);
            ruleCountLevel = 5;
        }
        if (level > 7)
        {
            randomRule = Random.Range(0, 9);
            ruleCountLevel = 8;
        }
        currentRule = rule[randomRule];
        ruleCount = 0;
        //Debug.Log(currentRule);
        //Debug.Log(ruleCount);
        textUIHandler.updateRuleText();
    }

    public void GameOver()
    {
        textUIHandler.enableGameOverText(true);
        //Debug.Log("GAME OVER");
    }

    void checkLevel(int currentLevel)
    {
        if (currentLevel <= 4) rule = new string[] { "Blue Circle", "Pink Circle", "Blue Cube", "Pink Cube" };
        if ((currentLevel > 4)&&(currentLevel <= 7)) rule = new string[] { "Blue Circle", "Pink Circle", "Blue Cube", "Pink Cube", "Yellow Circle", "Yellow Cube"};
        if (currentLevel > 7) rule = new string[] { "Blue Circle", "Pink Circle", "Blue Cube", "Pink Cube", "Yellow Circle", "Yellow Cube", "Blue Triangle", "Pink Triangle", "Yellow Triangle" };
    }
}
