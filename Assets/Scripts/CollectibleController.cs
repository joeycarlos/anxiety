using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour {

    private GameObject player;
    private PlayerController pc;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        RotateCollectible();
	}

    private void RotateCollectible()
    {
        transform.Rotate(Vector3.forward, 50.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        // if (collision.tag == "Player" && pc.GetDashCharges() < pc.GetMaxDashCharges())
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
