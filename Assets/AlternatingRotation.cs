using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingRotation : MonoBehaviour {

    public float rotationSpeed;
    public float timeUntilDirectionSwitch;

    private bool rotateCW;

    private float rotationTimer;

	// Use this for initialization
	void Start () {
        rotateCW = true;
        rotationTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        UpdateTimer();

        if (rotationTimer > timeUntilDirectionSwitch)
            SwitchDirection();

        Rotate();
	}

    void UpdateTimer()
    {
        rotationTimer += Time.deltaTime;
    }

    void SwitchDirection()
    {
        rotateCW = !rotateCW;
        rotationTimer = 0;
    }

    void Rotate()
    {
        if (rotateCW == true)
            transform.Rotate(Vector3.forward, - rotationSpeed * Time.deltaTime);
        else 
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
