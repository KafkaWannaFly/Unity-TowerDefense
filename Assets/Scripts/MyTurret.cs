using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTurret : MonoBehaviour
{
    [Header("General")]
    public float fireRange = 8f;
    public float rotatingSpeed = 10f;
    public int damage = 30;
    public int cost;

    [Header("Laser")]
    public bool useLaser;
    [Range(0,1)]
    public float slowDebuffPercentage;
    public LineRenderer laserBulletEffect;

    [Header("Bullet")]
    public float fireRate = 2f; //(bullet/s)
    public float bulletSpeed = 50f;

    float fireCountdown = 0f;
    LineRenderer laser;

    Transform currentTarget;
    Minion laserTarget;

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
        if(this.useLaser)
        {
            this.laser = Instantiate<LineRenderer>(laserBulletEffect, this.bulletInitialPosition.position, Quaternion.identity);
        }
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (currentTarget == null)
        {
            if(useLaser)
            {
                laser.enabled = false;
            }

            return;
        }

        lockOnTarget();

        if (useLaser == true)   //Use laser here
        {
            laser.enabled = true;
            loadLaserBeam();

            laserTarget = currentTarget.GetComponent<Minion>();

            laserTarget.takeSlowDebuff(slowDebuffPercentage);
            laserTarget.takeDamage(damage * Time.deltaTime);
        }
        else    //Use bullet here
        {
            if (fireCountdown <= 0)
            {
                loadTheBullet();

                //Start count down again
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
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

        if(laserTarget != null && currentTarget != null)
        {
            if(currentTarget.GetComponent<Minion>().speed != laserTarget.speed) //Laser changes target
            {
                laserTarget.takeSlowDebuff(0);  //Clear debuff
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

        if (bullet != null)
        {
            bullet.setBulletSpeed(this.bulletSpeed);
            bullet.setBulletDamage(this.damage);
            bullet.setTarget(currentTarget);
        }
    }

    void loadLaserBeam()
    {
        this.laser.SetPosition(0, this.bulletInitialPosition.position);
        this.laser.SetPosition(1, this.currentTarget.position);
    }

    public int getTurretDamage()
    {
        return this.damage;
    }
}
