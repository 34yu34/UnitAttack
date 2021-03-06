﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // dictates the speed at which cameras move
    public float _camera_speed;

    // Cameras 
    private Camera _camera;
    public Camera Camera { get { return _camera; } }

    // Inputs
    private float _hori;
    private float _vert;

    // top references
    private PlayerController _player_controller;
    
    private void Awake()
    {
        _player_controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _hori = Input.GetAxis("Horizontal");
        _vert = Input.GetAxis("Vertical");

        Move();
        Zoom();
    }

    void Move()
    {
        Vector3 pos = gameObject.transform.position;

        pos.x += _hori * _camera_speed * Time.deltaTime;
        pos.z += _vert * _camera_speed * Time.deltaTime;

        gameObject.transform.position = pos;
    }

    void Zoom()
    {
        Vector3 cam_pos = _camera.transform.position;
        Quaternion obj_rot = gameObject.transform.rotation;

        float scroll = Input.mouseScrollDelta.y;

        cam_pos += obj_rot * new Vector3(0, 0, scroll);

        _camera.transform.position = cam_pos;
    }
}
