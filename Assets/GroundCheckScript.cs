using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour {

    public GameObject dustCloud;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Instantiate(dustCloud, transform);
        }
    }
}
