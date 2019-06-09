using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornController : MonoBehaviour {


    private Vector3 moveVector;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveAcorn();
	}

    void MoveAcorn()
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
}
