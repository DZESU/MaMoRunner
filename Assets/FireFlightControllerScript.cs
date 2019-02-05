using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlightControllerScript : MonoBehaviour,IGameReset {

    Player player;

    public void OnGameReset()
    {
        GetComponent<ParticleSystem>().maxParticles = 0;
        GetComponent<ParticleSystem>().maxParticles = 15;
    }

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
        player.setGameResetListener(this);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
