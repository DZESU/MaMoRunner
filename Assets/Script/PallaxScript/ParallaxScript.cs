using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour {
    public Transform[] backgrounds;
    public float smoothing=1f;
    public Transform playerPos,resetPos;
    public int offset;
    private float[] parallaxScales;
    private Transform cam;
    private Vector3 preCam;


    private void Awake()
    {
        cam = Camera.main.transform;
    }
    // Use this for initialization
    void Start () {
        preCam = cam.position;

        parallaxScales = new float[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * 1;
        }
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {


            float parallx = (preCam.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallx;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX,backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,backgroundTargetPos,smoothing*Time.deltaTime);

        }
        preCam = cam.position;
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < backgrounds.Length; i++)
        {
            if(backgrounds[i].transform.position.x < playerPos.transform.position.x-offset)
            {
                backgrounds[i].transform.position = new Vector3(resetPos.transform.position.x, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);
            }
        }
    }
}
