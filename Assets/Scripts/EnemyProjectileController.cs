using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProjectileController : MonoBehaviour
{

    // ----- PRIVATE VARIABLES
    private Vector3 moveVector;

    private Transform childCanvas;

    void Start()
    {
        childCanvas = this.gameObject.transform.GetChild(0);
        UpdateText();
    }

    // ----- MAIN UPDATE LOOP
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(moveVector * Time.deltaTime);
    }

    public void InitializeEnemyProjectile(Vector3 newVector, float projectileSpeed)
    {
        // calculate the movement vector of enemy projectile per update frame
        moveVector = newVector;
        moveVector.z = 0;
        moveVector = Vector3.Normalize(newVector);
        moveVector *= projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        // if it collides with obstacle, this projectile disappears
        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Ice")
        {
            Destroy(gameObject);
        }
        */
    }

    private void UpdateText()
    {
        string negativeThought;

        switch (Random.Range(1, 5))
        {
            case 4:
                negativeThought = "GIVE UP, FOX!";
                break;
            case 3:
                negativeThought = "YOU'LL NEVER ESCAPE!";
                break;
            case 2:
                negativeThought = "MUAHAHAH";
                break;
            case 1:
                negativeThought = "I'M COMING FOR YOU...";
                break;
            default:
                negativeThought = "Error";
                break;
        }
        Text projectileText = childCanvas.GetComponentInChildren<Text>();
        projectileText.text = negativeThought;
    }
}
