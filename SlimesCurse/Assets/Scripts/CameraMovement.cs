using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _zoomSize = 5f;
    private float _maxOrtographicSize = 20;
    [SerializeField] private Camera _camera;
    private Vector3 _origin;
    private Vector3 _difference;
    private Vector3 _resetCamera;

    private bool _isDrag = false;

    void Start()
    {
        _maxOrtographicSize = _camera.orthographicSize + 20;
        _resetCamera = Camera.main.transform.position;
        _zoomSize = _camera.orthographicSize;
    }

    private void Update()
    {
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, 3, _maxOrtographicSize);
        Zooming();
        UnZooming();
        MovingCamera();
        CheckZooming();
    }

    void CheckZooming()
    {
        if(_camera.orthographicSize < 3)
        {
            _camera.orthographicSize = 5;
        }
    }
    void Zooming()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            _camera.orthographicSize -= _zoomSize;
        }
    }
    void UnZooming()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            _camera.orthographicSize += _zoomSize;
        }
    }

    void MovingCamera()
    {
        if (Input.GetMouseButton(1))
        {
            _difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (_isDrag == false)
            {
                _isDrag = true;
                _origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            _isDrag = false;
        }

        if (_isDrag == true)
        {
            Camera.main.transform.position = _origin - _difference;
        }

        if (Input.GetMouseButton(2))
        {
            Camera.main.transform.position = _resetCamera;
        }
    }
}