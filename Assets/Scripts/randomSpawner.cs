using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawner : MonoBehaviour
{

    public GameObject[] spawnees;
    public Transform spawnPos;

    int randomInt;
    Vector2 randomPosition;
    float spawnTime = 0;
    float repeatTime = 3;

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
        repeatTime = gameController.level/(gameController.level/2);

        if (Time.time - spawnTime >= repeatTime)
        {
            spawnTime = Time.time;
            Spawn();
        }
    }

    void Spawn()
    {
        randomPosition.x = Random.Range(-8, 8);
        randomInt = Random.Range(0, spawnees.Length);
        Instantiate(spawnees[randomInt], randomPosition, spawnees[randomInt].transform.rotation);
    }
}