using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float afterSec;
    void Start()
    {
        Destroy(this.gameObject, afterSec);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We hit something");
    }
}
