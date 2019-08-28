using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPoints : MonoBehaviour
{
    public static List<Transform> turnPoints = new List<Transform>();
    private void Awake()
    {
        for(int i=0; i<this.transform.childCount; ++i)
        {
            turnPoints.Add(this.transform.GetChild(i));
            //Debug.Log("Local pos: " + turnPoints[i].localPosition);
            //Debug.Log("Real pos: " + turnPoints[i].position);
        }
    }
}
