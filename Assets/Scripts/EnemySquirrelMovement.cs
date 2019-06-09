using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquirrelMovement : MonoBehaviour {

    public float speed;
    public float groundDistance;
    public float wallDistance;

    public bool movingRight = true;

    public Transform groundDetector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, groundDistance);

        Vector2 temp;
        if (movingRight == true)
            temp = Vector2.right;
        else
            temp = Vector2.left;
        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetector.position, temp, wallDistance);

        // if (groundInfo.collider == false || (wallInfo.collider == true && (wallInfo.collider.tag == "Boundary" || wallInfo.collider.tag == "Wall")))
        if (groundInfo.collider == false || (wallInfo.collider == true && wallInfo.collider.tag != "Player"))
        {
           if(movingRight == true)
            {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
            }
            else
            {
             transform.eulerAngles = new Vector3(0, 0, 0);
             movingRight = true;
            }
        }
        
        //if (groundInfo.collider == true)
        //{
        //    if (groundInfo.collider.tag == "Ground")
        //    {
        //        if (movingRight == true)
        //        {
        //            transform.eulerAngles = new Vector3(0, 0, 0);
        //            movingRight = true;
        //        }

        //    }

        //}
        //else
        //{
        //    transform.eulerAngles = new Vector3(0, -180, 0);
        //    movingRight = false;
        //}
    }
}
