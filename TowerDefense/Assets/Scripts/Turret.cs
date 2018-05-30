﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    Transform target;
    [Header("Turret Movement")]
    public float range;
    public Transform rotate;

    [Header("Turret Shooting Settings")]
    public float fireRate = 1f;
    private float fireCountdown;
    public GameObject bullet;
    public List<Transform> firePoint = new List<Transform>();

	// Use this for initialization
	void Start () {
        InvokeRepeating("LockTarget", 0f, 0.5f);
	}

    void LockTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else target = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isGameOver)
        {
            enabled = false;
            return;
        }

        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotate.rotation, lookRotation, Time.deltaTime * 3).eulerAngles;
        rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
	}

    void Shoot()
    {
        foreach (Transform f in firePoint)
        {
            GameObject bullettemp = Instantiate(bullet, f.position, f.rotation);
            Bullet _bullet = bullettemp.GetComponent<Bullet>();

            if (_bullet != null)
                _bullet.Seek(target);
        }
    }
}
