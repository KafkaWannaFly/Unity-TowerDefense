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
    int damage;

    public void setTarget(Transform _target)
    {
        this.target = _target;
    }

    public void setBulletSpeed(float _speed)
    {
        this.speed = _speed;
    }

    public void setBulletDamage(int _damage)
    {
        this.damage = _damage;
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
        //Destroy(hitEffect, 3f);
        return;
    }

    void dealDamage(GameObject enemy)
    {
        Minion creep = enemy.GetComponent<Minion>();
        if(creep == null)
        {
            return;
        }
        creep.takeDamage(this.damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, explosionRadius);
    }
}
