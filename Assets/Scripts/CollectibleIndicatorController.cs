using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleIndicatorController : MonoBehaviour {

    private float followDistance;
    public float indexMultiplier;
    public float speed;

    private Transform player;

    //private List<Vector3> storedPositions;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //storedPositions = new List<Vector3>();
    }
	
	// Update is called once per frame
	void Update () {
        //MoveToPlayer();
        if (Vector2.Distance(transform.position, player.position) > followDistance)
            {

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            }
        RotateCollectible();
        
	}

    private void RotateCollectible()
    {
        transform.Rotate(Vector3.forward, 50.0f * Time.deltaTime);
    }

    public void setIndicatorFollowDistance(int listIndex)
    {

        followDistance = listIndex * indexMultiplier;

    }

    
    /*void MoveToPlayer()
    {
        if(storedPositions.Count == 0)
        {
            //Debug.Log("blank list");
            storedPositions.Add(player.transform.position); //store the players currect position
            return;
        }
        else if (storedPositions[storedPositions.Count - 1] != player.transform.position)
        {
            //Debug.Log("Add to list");
            storedPositions.Add(player.transform.position); //store the position every frame
        }

        if (storedPositions.Count > followDistance)
        {
            transform.position = storedPositions[0]; //move
            storedPositions.RemoveAt(0); //delete the position that player just move to
        }
    } */
}
