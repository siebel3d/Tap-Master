using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectBehavior : MonoBehaviour
{
    int objCount;

    public Rigidbody2D objRB;
    private gameController gameController;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<gameController>();
        objRB = GetComponent<Rigidbody2D>();
        objRB.velocity = new Vector2(0, -(gameController.level* gameController.speed));
    }

    void Update()
    {
        objRB.velocity = new Vector2(0, -(gameController.level * gameController.speed));

        /*if (gameController.speed < gameController.level)
        {
            gameController.speed = gameController.level / 2;
        }*/
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "collisionBottom")
        {
            DestroyObject();
        }
    }

    public void OnMouseDown()
    {
        /*for (int i = 0; i < gameObject.GetComponent<gameController>().rule.Length; i++)
        {
            if (this.gameObject.tag == gameObject.GetComponent<gameController>().rule[i])
            {
                DestroyObject();
                gameObject.GetComponent<gameController>().ruleCount++;
            }
        }*/
        if (gameObject.tag == gameController.currentRule)
        {
            DestroyObject();
            gameController.ruleCount++;
        }
        else
        {
            DestroyObject();
            Debug.Log("Destroyed wrong object");
            gameController.ruleCount--;
            
        }
            

                
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);     
    }
}
