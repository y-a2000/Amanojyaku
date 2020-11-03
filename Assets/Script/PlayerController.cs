﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    
    private Transform PlayerTransform;
    private Transform CameraTransform;
    private float ii;
    
    // Use this for initialization
    void Start()
    {

        PlayerTransform = transform.parent;
        CameraTransform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        PlayerTransform.transform.Rotate(0, X_Rotation, 0);
        
        ii = Camera.transform.localEulerAngles.x;
        if (ii > 334 && ii < 360 || ii > 0 && 79 > ii)
        {
            CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
            float kk = Y_Rotation;
        }
        else
        {

            if (ii > 300)
            {

                if (Input.GetAxis("Mouse Y") < 0)
                {

                    CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);

                }
            }
            else
            {
                if (Input.GetAxis("Mouse Y") > 0)
                {

                    CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);

                }

            }
        }

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));


        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                PlayerTransform.transform.position += dir1 * speed * Time.deltaTime * 2;
            }
            else
            {
                PlayerTransform.transform.position += dir1 * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerTransform.transform.position += dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerTransform.transform.position += -dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerTransform.transform.position += -dir1 * speed * Time.deltaTime;
        }

        
    }
}