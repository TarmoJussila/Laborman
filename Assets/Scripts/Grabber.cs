﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public LayerMask GrabbableLayer;
    public float DragForce = 100.0f;

    private bool holding = false;
    private readonly float maxDistance = 3.0f;
    private readonly float holdDistance = 2.2f;
    private RaycastHit hit;
    private Rigidbody holdingRb;

    [SerializeField]
    private AnimationCurve dragCurve;

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            Debug.Log("move obj");
            Vector3 targetPos = Camera.main.transform.position + Camera.main.transform.forward * holdDistance;
            float distance = Vector3.Distance(holdingRb.transform.position, targetPos);
            Vector3 dir = targetPos - holdingRb.position;
            holdingRb.velocity = dir * dragCurve.Evaluate(distance);
            holdingRb.transform.forward = Camera.main.transform.forward;

            //holdingRb.transform.position = Vector3.Lerp(holdingRb.transform.position, targetPos, 0.5f);
            /*if (distance > 2)
            {
                holdingRb.transform.position = Vector3.Lerp(holdingRb.transform.position, targetPos, 0.9f);
            }
            else
            {
                holdingRb.velocity = (targetPos - holdingRb.transform.position) * DragForce;
                //holdingRb.AddForce(targetPos - holdingRb.transform.position * Time.deltaTime * DragForce);
            }*/

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("let go");
                holding = false;
                holdingRb.useGravity = true;
                holdingRb = null;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("try grab");
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, GrabbableLayer))
            {
                Debug.Log("raycast hit");
                holdingRb = hit.collider.GetComponent<Rigidbody>();
                holdingRb.isKinematic = false;
                holdingRb.transform.SetParent(null);
                holdingRb.useGravity = false;
                holding = true;
            }
        }
    }
}