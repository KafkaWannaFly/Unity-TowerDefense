using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("Attributes")]
    public float fireRange = 8f;
    public float rotatingSpeed = 10f;
    public float fireRate = 2f; //(bullet/s)
    public float bulletSpeed = 50f;
    public float damage = 10f;

    float fireCountdown = 0f;

    Transform currentTarget;

    [Header("Unity Setup Field")]
    public GameObject bulletPrefab;
    public Transform bulletInitialPosition;
    public string enemiesTag = "Enemies";

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, fireRange);
    }

    private void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (currentTarget == null)
        {
            return;
        }

        lockOnTarget();

        if(fireCountdown <= 0)
        {
            loadTheBullet();

            //Start count down again
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void updateTarget()
    {
        GameObject[] enemiesList = GameObject.FindGameObjectsWithTag(enemiesTag);

        float currentDistance = Mathf.Infinity;
        for (int i=0; i<enemiesList.Length; ++i)
        {
            if (Vector3.Distance(this.transform.position, enemiesList[i].transform.position) < currentDistance)
            {
                if (Vector3.Distance(this.transform.position, enemiesList[i].transform.position) <= fireRange)
                {
                    currentTarget = enemiesList[i].transform;
                }
            }
        }
    }

    void lockOnTarget()
    {
        //Vector3 temp = currentTarget.position - this.transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(temp);
        //this.transform.rotation = Quaternion.Euler(0f, lookRotation.y, 0f);

        Vector3 dir = currentTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(this.transform.rotation, lookRotation, Time.deltaTime * rotatingSpeed).eulerAngles;
        this.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void loadTheBullet()
    {
        GameObject temp = Instantiate<GameObject>(bulletPrefab, bulletInitialPosition.position, bulletInitialPosition.rotation);
        Bullet bullet = temp.GetComponent<Bullet>();
        bullet.setBulletSpeed(bulletSpeed);

        if (bullet != null)
        {
            bullet.setTarget(currentTarget);
        }
    }

    public float getTurretDamage()
    {
        return damage;
    }
}
