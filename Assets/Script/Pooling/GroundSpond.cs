using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpond : MonoBehaviour {

    public GameObject tileObject;
    public Transform target;
    ObjectPooler objectPooler;

    private float tileWidth;

    private void Start()
    {
        tileWidth = Mathf.Abs(tileObject.GetComponent<EdgeCollider2D>().points[0][0]- tileObject.GetComponent<EdgeCollider2D>().points[1][0]);
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        if (!GameControllerScript.isPause)
        {
            if (transform.position.x < target.transform.position.x)
            {

                objectPooler.SpawnFromPool("GroundForest", transform.position, transform.rotation);
                transform.position = new Vector3(tileWidth + transform.position.x, transform.position.y, transform.position.z);
            }
        }

    }
}
