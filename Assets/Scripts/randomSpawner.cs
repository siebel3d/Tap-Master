using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawner : MonoBehaviour
{

    public GameObject[] spawnees;
    public Transform spawnPos;
    public Transform leftLimiter;
    public Transform rightLimiter;

    int randomInt;
    public Vector2 randomPosition;
    float spawnTime = 0;
    float repeatTime = 5;

    private gameController gameController;

    private void Start()
    {
        gameController = GameObject.FindObjectOfType<gameController>();
        randomPosition.y = 6;
        //InvokeRepeating("Spawn", spawnTime, repeatTime);
        Spawn();
    }

    void Update()
    {
        //spawnTime = gameController.level;
        //spawnTime = Time.time;
        //repeatTime = gameController.level/(gameController.level/2);

        if (gameController.level == 1) repeatTime = 3;
        if (gameController.level == 2) repeatTime = 2;
        if (gameController.level == 3) repeatTime = 1.5f;
        if (gameController.level == 4) repeatTime = 1;
        if (gameController.level > 4 && repeatTime >= 0.5f) repeatTime = 1/(gameController.level*0.2f);

        if (repeatTime < 0.5f) repeatTime = 0.5f;

        if (Time.time - spawnTime >= repeatTime)
        {
            spawnTime = Time.time;
            Spawn();
        }
    }

    void Spawn()
    {
        randomPosition.x = Random.Range(leftLimiter.transform.position.x, rightLimiter.transform.position.x);
        randomInt = Random.Range(0, spawnees.Length);
        Instantiate(spawnees[randomInt], randomPosition, spawnees[randomInt].transform.rotation);
    }
}