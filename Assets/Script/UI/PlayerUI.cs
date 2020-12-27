using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private PlayerCamera _player_camera;
    public PlayerCamera PlayerCamera { get { return _player_camera; } }

    private PlayerController _player_controller;
    public PlayerController PlayerController { get { return _player_controller; } }

    private UnitShop _shop;
    public UnitShop Shop { get { return _shop; } }

    private UnitBoard _board;
    public UnitBoard Board { get { return _board; } }

    public UnitDragData _dragger;

    public void Awake()
    {
        _player_camera = GetComponentInParent<PlayerCamera>();
        _player_controller = GetComponentInParent<PlayerController>();
        _shop = GetComponentInParent<UnitShop>();
        _board = GetComponentInChildren<UnitBoard>();
    }
}
