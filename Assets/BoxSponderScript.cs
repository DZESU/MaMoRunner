using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class BoxSponderScript : MonoBehaviour {

    public GameObject boxPrefab;
    public int timeRange1, timeRange2;

    ObjectPooler objectPooler;
    double startTime;
    System.Random random;
    int delay;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        objectPooler = ObjectPooler.Instance;
        random = new System.Random();
        //timeRange1 = timeRange1 * 1000;
        //timeRange2 = timeRange2 * 1000;
        delay = random.Next(timeRange1, timeRange2);
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameControllerScript.isPause)
        {
            if((Time.time - startTime) > delay)
            {
                objectPooler.SpawnFromPool("Box", transform.position, transform.rotation);
                delay = random.Next(timeRange1, timeRange2);
                startTime = Time.time;
            }
        }

    }
}
