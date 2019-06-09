using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAcorns : MonoBehaviour {

    public GameObject acorn;
    public float fireRate;

    private GameObject player;
    public float verticalOffset;
    public float acornMinFallSpeed;
    public float acornMaxFallSpeed;

    public float acornMinSpawnInterval;
    public float acornMaxSpawnInterval;

    public float horizontalOffset;

    public float horizontalSpawnRange;

    private GameObject iAcorn;

    private float timeSinceFire;

    public float startDelayTime;

    // Use this for initialization
    void Start () {
        timeSinceFire = startDelayTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        UpdateTimers();
        FollowPlayer();
        if (timeSinceFire <= 0) SpawnAcorn();
	}

    private void UpdateTimers()
    {
        timeSinceFire -= Time.deltaTime;
    }

    void FollowPlayer()
    {
        float playerYPosition = player.transform.position.y;

        Vector3 temp = new Vector3(horizontalOffset, playerYPosition + verticalOffset, 0);
        transform.position = temp;
    }

    void SpawnAcorn()
    {
        float randomXPosition = Random.Range(-horizontalSpawnRange, horizontalSpawnRange);
        float tempAcornFallSpeed = Random.Range(acornMinFallSpeed, acornMaxFallSpeed);
        Vector3 acornSpawnOffset = new Vector3 (randomXPosition, 0, 0);
        iAcorn = Instantiate(acorn, transform.position + acornSpawnOffset, Quaternion.identity);
        iAcorn.GetComponent<AcornController>().InitializeEnemyProjectile(Vector3.down, tempAcornFallSpeed);
        timeSinceFire = Random.Range(acornMinSpawnInterval, acornMaxSpawnInterval);
    }
}
