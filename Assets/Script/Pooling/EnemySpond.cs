using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpond : MonoBehaviour {

    public enum SpawState { SPAWNING, WAITING, COUNTING };
    public GameObject enemyPrefab;
    public float spawnTime = 1f;
    public int upForce = 1;
    public int sideForce = 1;

    private float spawn = 1f;

    System.Random random = new System.Random();

    ObjectPooler objectPooler;
    private SpawState state = SpawState.COUNTING;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        
    }
    public int xForce, yForce;
    private void FixedUpdate()
    {
        if (!GameControllerScript.isPause)
        {
            if (spawn <= 0)
            {
                xForce = random.Next(-sideForce, -2);
                yForce = random.Next(upForce / 2, upForce);

                GameObject tmp = objectPooler.SpawnFromPool("Enemy", transform.position, transform.rotation, yForce, xForce);
                spawn = spawnTime;
                
            }
            else
            {
                spawn -= Time.deltaTime;
            }

        }

    }
}
