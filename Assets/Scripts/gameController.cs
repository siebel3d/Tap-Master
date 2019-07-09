using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{

    public int level=1;
    public int ruleCount=0;
    public int randomRule;
    public float speed;
    public float spawnTime;
    public string[] rule;
    public string currentRule;

    public GameObject spawner;

    void Start()
    {
        level = 1;
        speed = 1;
        rule = new string[] { "Circle", "Cube", "Triangle" };
        RandomRule();
    }

    void Update()
    {
        if(ruleCount != 0 && ruleCount < 5)
        {
            Debug.Log("Rule: "+currentRule);
            Debug.Log("Count: "+ruleCount);
            Debug.Log("Level: " + level);
        }

        if (ruleCount < 0 && level > 1)
        {
            level--;
            ruleCount = 0;
            RandomRule();
        }

        if (ruleCount < 0) ruleCount = 0;

        if (ruleCount == 5)
        {
            level++;
            ruleCount = 0;
            RandomRule();
        }
        
        
    }

    void RandomRule()
    {
        randomRule = Random.Range(0, 2);
        if (randomRule == 0)
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
        }

        Debug.Log(currentRule);
        Debug.Log(ruleCount);
    }
}
