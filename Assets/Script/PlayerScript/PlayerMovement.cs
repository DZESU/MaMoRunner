using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public PlayerContoller2D controller;
    public Animator animator;
    public GameObject runDust;
    public float runSpeed;
    public float crouchSpeed;
    public bool autoRun;
    private float screenCenterX;



    bool isJump;
    bool isCrouch;
    float h_move;
    // Use this for initialization
    void Start()
    {
        isJump = false;
        screenCenterX = Screen.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.isPause)
        {
            if (!autoRun)
            {
                if (Input.GetKey(KeyCode.D) || Input.GetMouseButton(1))
                {
                    animator.SetFloat("running", 1);
                    h_move = runSpeed;
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetMouseButton(1))
                {

                    animator.SetFloat("running", 1);
                    h_move = -runSpeed;
                }
                else
                    animator.SetFloat("running", 0);
                animator.speed = 0;
            }
            else
            {

                h_move = runSpeed;
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (h_move < crouchSpeed + runSpeed)
                    {
                        h_move = runSpeed + crouchSpeed;
                        isCrouch = true;

                        runDust.GetComponent<ParticleSystem>().startSize = 6;
                        runDust.GetComponent<ParticleSystem>().emissionRate = 60;
                    }
                }
                if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(1))
                {
                    isJump = true;
                    Player.isJumping = true;

                }
                animator.SetFloat("running", 1);

            }
            if (Input.touchCount > 0)
            {

                Touch firstTouch = Input.GetTouch(0);

                if (firstTouch.phase == TouchPhase.Began)
                {
                    if (firstTouch.position.x > screenCenterX)
                    {
                        if (h_move < crouchSpeed + runSpeed)
                        {
                            h_move = runSpeed + crouchSpeed;
                            isCrouch = true;
                            runDust.GetComponent<ParticleSystem>().startSize = 6;
                            runDust.GetComponent<ParticleSystem>().emissionRate = 50;
                        }

                    }
                    else if (firstTouch.position.x < screenCenterX)
                    {
                        isJump = true;
                        Player.isJumping = true;
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (!GameControllerScript.isPause)
        {
            controller.Move(h_move * Time.deltaTime, false, isJump);
            isJump = false;
            if (h_move * Time.deltaTime < runSpeed)
            {
                h_move = runSpeed;
                runDust.GetComponent<ParticleSystem>().startSize = 2;
                runDust.GetComponent<ParticleSystem>().emissionRate = 10;

            }
            else if (h_move * Time.deltaTime >= runSpeed)
            {
                h_move -= 15;
            }
        }
    }

    int calculateEmissionRate()
    {
        int rate=0;
        if (h_move <= 120)
            rate = 10;
        else if (h_move > 300)
            rate = 15;
        else if (h_move > 400)
            rate = 20;
        else if (h_move > 500)
            rate = 25;
        else if (h_move > 3000)
            rate = 50;
        else rate = 10;

        return rate;
    }


    int calculateStartSize()
    {
        int size = 0;
        if (h_move <= 120)
            size = 2;
        else if (h_move > 400)
            size = 3;
        else if (h_move > 500)
            size = 4;
        else if (h_move > 3000)
            size = 6;
        else size = 2;
        return size;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (!GameControllerScript.isPause)
    //    {
    //        if (!autoRun)
    //        {
    //            if (Input.GetKey(KeyCode.D) || Input.GetMouseButton(1))
    //            {
    //                animator.SetFloat("running", 1);
    //                h_move = runSpeed;
    //            }
    //            else if (Input.GetKey(KeyCode.A) || Input.GetMouseButton(1))
    //            {

    //                animator.SetFloat("running", 1);
    //                h_move = -runSpeed;
    //            }
    //            else
    //                animator.SetFloat("running", 0);
    //            animator.speed = 0;
    //        }
    //        else
    //        {

    //            h_move = runSpeed;
    //            if (Input.GetKeyDown(KeyCode.D))
    //            {
    //                if (h_move < crouchSpeed + runSpeed)
    //                {
    //                    h_move = runSpeed + crouchSpeed;
    //                    isCrouch = true;
    //                    runDust.GetComponent<ParticleSystem>().startSize = 6;
    //                    runDust.GetComponent<ParticleSystem>().emissionRate = 50;

    //                }
    //            }
    //            if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(1))
    //            {
    //                isJump = true;
    //                Player.isJumping = true;

    //            }
    //            animator.SetFloat("running", 1);

    //        }

    //        if (Input.touchCount > 0)
    //        {

    //            Touch firstTouch = Input.GetTouch(0);

    //            if (firstTouch.phase == TouchPhase.Began)
    //            {
    //                if (firstTouch.position.x > screenCenterX)
    //                {
    //                    if (h_move < crouchSpeed + runSpeed)
    //                    {
    //                        h_move = runSpeed + crouchSpeed;
    //                        isCrouch = true;
    //                        runDust.GetComponent<ParticleSystem>().startSize = 6;
    //                        runDust.GetComponent<ParticleSystem>().emissionRate = 50;
    //                    }

    //                }
    //                else if (firstTouch.position.x < screenCenterX)
    //                {
    //                    isJump = true;
    //                    Player.isJumping = true;
    //                }
    //            }
    //        }
    //    }
    //}
    //private void FixedUpdate()
    //{
    //    if (!GameControllerScript.isPause)
    //    {
    //        controller.Move(h_move * Time.deltaTime, false, isJump);
    //        isJump = false;
    //        if (h_move < runSpeed)
    //        {
    //            h_move = runSpeed;
    //            runDust.GetComponent<ParticleSystem>().startSize = 2;
    //            runDust.GetComponent<ParticleSystem>().emissionRate = 10;

    //        }
    //        else if (h_move >= runSpeed)
    //        {
    //            h_move -= 15;
    //        }
    //    }
    //}


}
