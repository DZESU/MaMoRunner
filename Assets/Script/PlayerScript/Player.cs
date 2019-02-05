using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    private Vector3 startPoint,startPointSponder;
    public Transform sponderPoint, groundCheck;
    public GameObject losePanel;
    public GameObject runDust;
    public GameObject dieDust;
    public Text Txt_HighScore;
    
    

    public static bool isJumping;

    private IGameReset gameResetListener;

    internal void setGameResetListener(FireFlightControllerScript fireFlightControllerScript)
    {
        throw new NotImplementedException();
    }

    public void setGameResetListener(IGameReset listener)
    {
        gameResetListener = listener;
    }

	// Use this for initialization
	void Start () {
        startPoint = transform.position;
        startPointSponder = sponderPoint.position;
        dieDust.GetComponent<ParticleSystem>().Stop();
        
	}
	
	// Update is called once per frame
	void Update () {
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        if (GameControllerScript.isPause)
        {
 
            tmp.a -= 0.75f * Time.deltaTime;
        }else
            tmp.a = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = tmp;
	}

    private void FixedUpdate()
    {
        if (!isJumping)
        {
            runDust.SetActive(true);
        }
    }
    private void setHighScore(int score)
    {
        Txt_HighScore.text = "HighScore\n" + score + "' s";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            int highscore = PlayerPrefs.GetInt("HighScore", 0);
            Vector3 v3 = new Vector3();
            v3 = transform.position;
            v3.z = 100;
            losePanel.SetActive(true);
            
            GameControllerScript.isPause = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition|RigidbodyConstraints2D.FreezeRotation;

            dieDust.transform.position = v3;

            dieDust.GetComponent<ParticleSystem>().Play();
            runDust.GetComponent<ParticleSystem>().emissionRate = 0;
            
            if (highscore < GameControllerScript.score)
            {
                highscore = GameControllerScript.score;
                PlayerPrefs.SetInt("HighScore", highscore);
            }
            
            setHighScore(highscore);
        }
    }

    public void ResetPlayer()
    {
        Debug.Log("Reset Player");
        transform.position = startPoint;
        sponderPoint.position = startPointSponder;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Vector3 v3 = new Vector3();
        v3 = transform.position;

        v3.z = 0;
        //transform.position = v3;

        v3.z = -100;
        dieDust.transform.position = v3;

        dieDust.GetComponent<ParticleSystem>().Stop();

        runDust.GetComponent<ParticleSystem>().emissionRate = 10;


        losePanel.SetActive(false);
        if (gameResetListener != null)
        {
            gameResetListener.OnGameReset();
        }

        for (int i = 0; i < 8; i++)
        {
            GameObject.Find("PoolingObject").GetComponent<ObjectPooler>().ResetGameObject("Enemy");
            GameObject.Find("PoolingObject").GetComponent<ObjectPooler>().ResetGameObject("Box");
        }

        GameControllerScript.timer.Reset();
        GameControllerScript.timer.Start();
        
    }

    public void Landing()
    {
        isJumping = false;
    }
}
