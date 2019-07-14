using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectBehavior : MonoBehaviour
{
    int objCount;

    public Rigidbody2D objRB;
    private gameController gameController;
    private textUIHandler textUIHandler;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<gameController>();
        textUIHandler = GameObject.FindObjectOfType<textUIHandler>();
        objRB = GetComponent<Rigidbody2D>();
        objRB.velocity = new Vector2(0, -(gameController.level* gameController.speed));
    }

    void Update()
    {
        objRB.velocity = new Vector2(0, -(gameController.level * gameController.speed));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "collisionBottom")
        {
            if (string.Compare(this.gameObject.tag, gameController.currentRule) == 0)
            {
                gameController.GameOver();
            }
            DestroyObject();
        }
    }

    public void OnMouseDown()
    {
        if (gameObject.tag == gameController.currentRule)
        {
            DestroyObject();
            gameController.ruleCount++;
            gameController.score++;
            textUIHandler.updateScoreText();

        }
        else
        {
            DestroyObject();
            Debug.Log("Destroyed wrong object");
            gameController.ruleCount--;
            gameController.GameOver();            
        }
            

                
    }

    

    void DestroyObject()
    {
        Destroy(this.gameObject);     
    }
}
