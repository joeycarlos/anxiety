using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController : MonoBehaviour {

    public float jumpPadForce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Rigidbody2D rb;
            rb = collision.collider.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.up * jumpPadForce;
        }
    }
}
