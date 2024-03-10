using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Middle;
    public GameObject PointA; 
    public GameObject PointB;

    void Start()
    {
        
    }


    void Update()
    {
        Middle.transform.position = (PointA.transform.position + PointB.transform.position) / 2;
    }
}
