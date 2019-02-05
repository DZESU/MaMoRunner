using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    public GameObject sponderPoint;
    public GameObject playerObj;
    public GameObject cameraObj;
    public GameObject parallaxPoint;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public Text txt_score;


    private Vector3 startPointSponder;
    private Transform startPoint;
    private Vector3 startparallaxPoint;
    private Vector3 sp1;
    private Vector3 sp2;
    private Vector3 sp3;
    Rigidbody2D playerRigi;

    public static Stopwatch timer;
    public static int score = 0;
    public static bool isPause = false;

    // Use this for initialization
    void Start()
    {
        startparallaxPoint = parallaxPoint.transform.position;
        //startPoint = playerObj.transform.position;
        startPointSponder = sponderPoint.transform.position;
        sp1 = p1.transform.position;
        sp2 = p2.transform.position;
        sp3 = p3.transform.position;
        playerRigi = playerObj.GetComponent<Rigidbody2D>();
        startPoint = playerObj.GetComponent<Transform>();

        timer = new Stopwatch();

        timer.Start();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!isPause)
        {
            score = Mathf.RoundToInt(timer.ElapsedMilliseconds / 1000);
            
            setScore(score);
            if (score > 0 && (score % 10) == 0)
            {
                playerObj.GetComponent<PlayerMovement>().runSpeed += 15 * Time.deltaTime;
                cameraObj.GetComponent<CameraFollowPlayerScript>().smoothSpeed += 0.25f *Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            resetGame();
            
            Time.timeScale = 0;
            playerRigi.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void resetGame()
    {
        playerRigi.transform.position = startPoint.position;
        sponderPoint.transform.position = startPointSponder;
        parallaxPoint.transform.position = startparallaxPoint;
        p1.transform.position = sp1;
        p2.transform.position = sp2;
        p3.transform.position = sp3;
        timer.Reset();
        setScore(0);
    }

    public void setScore(int score)
    {
        txt_score.text = "Score: " + score + "' s";
    }
}
