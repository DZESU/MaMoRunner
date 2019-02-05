using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollowPlayerScript : MonoBehaviour, IGameReset{

    public GameObject target;
    public float delayStart;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 startPos;
    float startTime;
    float endTime;
    bool startFollow;

    private void Start()
    {
        startPos = target.transform.position + offset;
        target.GetComponent<Player>().setGameResetListener(this);
        startTime = Time.time;
    }

    private void Update()
    {
        if((Time.time-startTime) > delayStart)
        {
            startFollow = true;
        }
    }

    void FixedUpdate()
    {
       
        if (!GameControllerScript.isPause)
        {
            if (startFollow)
            {
                Vector3 desiredPosition = target.transform.position + offset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
                smoothedPosition.y = transform.position.y;
                smoothedPosition.z = transform.position.z;
                transform.position = smoothedPosition;
            }
        }
    }

    public void OnGameReset()
    {
        Debug.Log("Camera REset");
        startPos.z = transform.position.z;
        startPos.y = transform.position.y;
        transform.position = startPos;
        startFollow = false;
        startTime = Time.time;

    }
}
