using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointNavigation : MonoBehaviour
{
    public float speed = 20f;
    Transform target;
    int turnPointNum = 0;

    private void Update()
    {
        target = TurnPoints.turnPoints[turnPointNum];
        Vector3 direction = target.position - this.transform.position;

        this.transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);

        if (Vector3.Distance(this.transform.position, target.position) <= 0.4f)
        {
            getNextTurnPoint();
        }
    }

    void getNextTurnPoint()
    {
        if (turnPointNum >= TurnPoints.turnPoints.Count - 1)
        {
            Destroy(this.gameObject);
            return;
        }

        turnPointNum++;
        target = TurnPoints.turnPoints[turnPointNum];
       
    }
    
    //private Transform target;
    //private int wavepointIndex = 0;

    //void Start()
    //{
    //    target = TurnPoints.turnPoints[0];
    //}

    //void Update()
    //{
    //    Vector3 dir = target.position - transform.position;
    //    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    //    if (Vector3.Distance(transform.position, target.position) <= 0.4f)
    //    {
    //        GetNextWaypoint();
    //    }
    //}

    //void GetNextWaypoint()
    //{
    //    if (wavepointIndex >= TurnPoints.turnPoints.Count - 1)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }

    //    wavepointIndex++;
    //    target = TurnPoints.turnPoints[wavepointIndex];
    //}
}
