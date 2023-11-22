using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Transform _drag = null;
    public static bool _isDragging = false;
    private Vector3 _offset = Vector3.zero;
    [SerializeField] private LayerMask _maskMovable;

    private void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, _maskMovable);
            if(hit == true)
            {
                _drag = hit.transform;
                _offset = _drag.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _isDragging = true;
            }
        }
        else if(Input.GetMouseButtonUp(2))
        {
            _drag = null;
            _isDragging = false;
        }
        
        if(_drag != null)
        {
            _drag.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
        }
    }
}
