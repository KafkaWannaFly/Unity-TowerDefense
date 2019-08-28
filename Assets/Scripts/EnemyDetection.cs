using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float fireRange = 8f;
    public float rotatingSpeed = 10f;
    Transform currentTarget;

    public string enemiesTag = "Enemies";

    private void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.5f);
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

    private void Update()
    {
        if(currentTarget == null)
        {
            return;
        }

        lockOnTarget();
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, fireRange);
    }
}
