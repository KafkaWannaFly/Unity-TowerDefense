using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject cartouche;
    public float explosionRadius = 15f;
    public string enemyTag = "Enemies";

    Transform target;
    float speed = 50f;

    public void setTarget(Transform _target)
    {
        target = _target;
    }

    public void setBulletSpeed(float _speed)
    {
        speed = _speed;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Vector3 dir = target.position - this.transform.position;

            if(dir.magnitude <= speed*Time.deltaTime)
            {
                hitTheTarget();
                return;
            }

            this.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            this.transform.LookAt(target);
        }
    }

    void hitTheTarget()
    {
        if(explosionRadius > 0)
        {
            Collider[] hitObject =  Physics.OverlapSphere(this.transform.position, explosionRadius);
            foreach (Collider item in hitObject)
            {
                if(item.tag == enemyTag)
                {
                    dealDamage(item.gameObject);
                }
            }
        }
        else
        {
            dealDamage(target.gameObject);
        }

        Destroy(this.gameObject);
        GameObject hitEffect = Instantiate(cartouche, target.position, target.rotation);
        //Destroy(hitEffect, 0.3f);
        return;
    }

    void dealDamage(GameObject enemy)
    {
        Destroy(enemy);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, explosionRadius);
    }
}
