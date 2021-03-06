﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NodDetectionCardboard : MonoBehaviour
{
    private Vector3 angles;
    public float timeLimit; // Time limit to detect the head gesture
    private bool up = false, down = false;
    public UnityEvent nodCompletedEvent;

    
    void CheckMovement()
    {
        if (angles.x < 330 && angles.x > 300 && !up)
        {
            up = true;
        }
        if (angles.x < 30 && angles.x > 20 && !down)
        {
            down = true;
        }

        if (up && down) // head nod complete condition
        {
            //put the method you with to call when the nod completes here.
            if (nodCompletedEvent != null)
            {
                nodCompletedEvent.Invoke();
            }
            resetGesture();

        }
    }
    public void ResetGesture()
    {
        angles = new Vector3();
        up = false;
        down = false;
    }


    void Start()
    {
        InvokeRepeating("resetGesture", 0f, timeLimit);
    }


    void Update()
    {
        angles = Camera.main.transform.rotation.eulerAngles;
        checkMovement();
    }
}
