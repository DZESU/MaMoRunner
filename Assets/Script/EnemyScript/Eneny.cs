using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eneny : MonoBehaviour
{

    Rigidbody2D rigidbody;
    Collider boxCollider;
    // Use this for initialization

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<Collider>();
    }

    private void Update()
    {
        if (GameControllerScript.isPause)
        {
            rigidbody.constraints = RigidbodyConstraints2D.FreezePosition|RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints2D.None;
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Physics.IgnoreCollision(boxCollider, collision.collider);
        }
    }
}
