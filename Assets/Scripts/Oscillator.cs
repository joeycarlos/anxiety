using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

    // ----- PUBLIC VARIABLES
    public float amplitude;         // determines how far to travel
    public float speed;         // how many cycles per second (speed)
    public float eulerAngle;        // the angle of patrol (0 to 360)
    public float startingPoint;     // at which point in the oscillation it starts (-1 to 1)

    public bool enablePlayerSticky;

    private Rigidbody2D rb;
    private bool positiveDirection;
    private float distanceSinceSwitch;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distanceSinceSwitch = amplitude + startingPoint*amplitude;
        positiveDirection = true;

    }

    void Update()
    {
        if (distanceSinceSwitch > amplitude*2f)
            SwitchDirection();
        Move(new Vector2((float)Mathf.Cos(eulerAngle*Mathf.Deg2Rad), (float)Mathf.Sin(eulerAngle*Mathf.Deg2Rad)));
    }


    private void SwitchDirection()
    {
        positiveDirection = !positiveDirection;
        distanceSinceSwitch = 0;
        if (eulerAngle != 90)
        {
            if (positiveDirection == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }

        
    }


    private void Move(Vector2 direction)
    {
        Vector2 moveVector = direction.normalized * speed * Time.deltaTime;
        if (positiveDirection)
            rb.transform.Translate(moveVector.x, moveVector.y, 0, Space.World);
        if (!positiveDirection)
            rb.transform.Translate(-moveVector.x, -moveVector.y, 0, Space.World);

        distanceSinceSwitch += moveVector.magnitude;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && enablePlayerSticky == true)
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && enablePlayerSticky == true)
        {
            collision.collider.transform.SetParent(null);
        }
    }

}
