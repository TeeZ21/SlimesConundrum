using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 _origin;
    private Vector3 _difference;
    private Vector3 _resetCamera;

    private bool _isDrag = false;

    void Start()
    {
        _resetCamera = Camera.main.transform.position;
    }

    void LateUpdate()
    {
        if(Input.GetMouseButton(0)) 
        {
            _difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (_isDrag == false )
            {
                _isDrag = true;
                _origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            _isDrag = false;
        }

        if(_isDrag == true )
        {
            Camera.main.transform.position = _origin - _difference;
        }

        if(Input.GetMouseButton(1))
        {
            Camera.main.transform.position = _resetCamera;
        }
    }
}
