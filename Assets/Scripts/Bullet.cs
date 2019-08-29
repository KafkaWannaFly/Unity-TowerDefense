using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    float speed = 50f;

    public GameObject cartouche;

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
        }
    }

    void hitTheTarget()
    {
        Destroy(this.gameObject);
        GameObject hitEffect = Instantiate(cartouche, target.position, target.rotation);
        Destroy(hitEffect, 0.3f);
        return;
    }
}
