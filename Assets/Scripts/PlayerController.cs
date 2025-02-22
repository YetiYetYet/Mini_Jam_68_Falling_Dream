﻿using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.InfiniteRunnerEngine;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public LayerMask movableLayer;
    public Vector3 playerOffset;
    public float deltaY;
    public float animatorTolerance = 0.1f;

    public Animator animator;
    
    [SerializeField]
    private Vector3 _target;
    [SerializeField]
    private Vector3 _mousePosition;

    private Vector3 _initialRotation;
    private Vector3 _targetRotation;
    
    private Ray _ray;

    private Camera _camera;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _target = transform.position;
        _initialRotation = transform.eulerAngles;
        _targetRotation = _initialRotation;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = _targetRotation;

        deltaY = _target.y - transform.position.y;
        if (Math.Abs(deltaY) > animatorTolerance)
        {
            animator.SetBool("MovingFoward", deltaY > 0);
        }
        else
        {
            animator.SetBool("MovingFoward", true);
        }

        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray.origin, _ray.direction, out RaycastHit hit, Mathf.Infinity, movableLayer))
        {
            _target = hit.point;
            _target += playerOffset;
        }
        
        Debug.DrawRay(_ray.origin, _ray.direction * 10, Color.yellow);
        transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
    }
}
