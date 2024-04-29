/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Transform camera;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1.0f;
    Vector3 initialPosition;

    void Start()
    {

    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + UnityEngine.Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    void Awake()
    {
        if (transform == null)
        {
            if (transform == null)
            {
                // Get the main camera's transform
                transform = Camera.main.transform;
            }
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    public void TriggerShake()
    {
        shakeDuration = 2.0f;
    }
}*/