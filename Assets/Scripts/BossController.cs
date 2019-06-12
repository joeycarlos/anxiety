using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public float chaseSpeed;
    public float chaseSpeedIncrement;

    private float currentChaseSpeed;

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        CatchUp();
        MoveBoss();
	}

    void CatchUp()
    {
        if (player.transform.position.y - this.transform.position.y > 7.0f)
        {
            currentChaseSpeed = 4.5f;
        }
        else
        {
            currentChaseSpeed = chaseSpeed;
        }
    }

    void MoveBoss()
    {
        Vector3 moveVector = new Vector3(0, currentChaseSpeed * Time.deltaTime, 0);
        transform.Translate(moveVector);
    }

    public void IncrementBossSpeed()
    {
        currentChaseSpeed += chaseSpeedIncrement;
    }
}
