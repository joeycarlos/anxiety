using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    // ----- PUBLIC VARIABLES
    public GameObject enemyProjectile;
    public float fireRate;
    public float projectileSpeed;

    public bool enableTracking;

    // ----- PRIVATE VARIABLES
    private GameObject eProjectile;

    private float timeSinceFire;

    private GameObject player;

    public float startDelayTime;

    // Use this for initialization
    void Start () {
        timeSinceFire = startDelayTime;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTimers();
        if (enableTracking == true) FaceTarget();
        if (timeSinceFire <= 0) Fire();

    }

    private void UpdateTimers()
    {
        timeSinceFire -= Time.deltaTime;
    }

    private void FaceTarget()
    {

        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90.0f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5.0f);

    }

    private void Fire()
    {
        eProjectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
        eProjectile.GetComponent<EnemyProjectileController>().InitializeEnemyProjectile(transform.up, projectileSpeed);
        timeSinceFire = fireRate;
    }
}
