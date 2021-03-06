﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float SpeedCamera = 2f;

    public Vector2 xClampValue;
    public Vector2 yClampValue;

    //private Vector2 xClampValueGame = new Vector2(-105f,105f);
    //private Vector2 yClampValueGame = new Vector2(-27f,27f);

    private Vector3 mousePositionAfterClickFirst;
    private Vector3 mousePositionAfterClickSecond;
    private Vector3 cameraPositionAfterClick;
    private Vector3 DistanceBetweenTwoClicks;

    private void Start()
    {
        transform.position = new Vector3(xClampValue.x, transform.position.y, transform.position.z);
    }

    void LateUpdate () {
        
		if (Input.GetMouseButtonDown(0))
        {
            mousePositionAfterClickFirst = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObject.transform.position.z);
            cameraPositionAfterClick = gameObject.transform.position;

        }
        if (Input.GetMouseButton(0))
        {
            mousePositionAfterClickSecond = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObject.transform.position.z);
            DistanceBetweenTwoClicks = (mousePositionAfterClickSecond - mousePositionAfterClickFirst) * Time.fixedDeltaTime * SpeedCamera;

            transform.position = cameraPositionAfterClick - DistanceBetweenTwoClicks;

            var pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x, xClampValue.x, xClampValue.y);
            pos.y = Mathf.Clamp(transform.position.y, yClampValue.x, yClampValue.y);
            transform.position = pos;
            
        }
    }
}
