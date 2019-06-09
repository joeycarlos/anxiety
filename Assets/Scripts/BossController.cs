using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public float chaseSpeed;
    public float chaseSpeedIncrement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveBoss();
	}

    void MoveBoss()
    {
        Vector3 moveVector = new Vector3(0, chaseSpeed * Time.deltaTime, 0);
        transform.Translate(moveVector);
    }

    public void IncrementBossSpeed()
    {
        chaseSpeed += chaseSpeedIncrement;
    }
}
