using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustScript : MonoBehaviour {

    // Use this for initialization
    private void FixedUpdate()
    {
        if (Player.isJumping)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            Player.isJumping = false;
        }
    }

}