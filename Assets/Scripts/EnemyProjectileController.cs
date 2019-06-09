using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{

    // ----- PRIVATE VARIABLES
    private Vector3 moveVector;

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
}
