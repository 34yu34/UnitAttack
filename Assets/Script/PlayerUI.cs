using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private PlayerCamera _camera;

    private UnitShop _shop;

    public void Awake()
    {
        _camera = GetComponentInParent<PlayerCamera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
