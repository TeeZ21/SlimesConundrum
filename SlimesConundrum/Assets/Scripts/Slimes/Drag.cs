using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    #region Fields
    private Transform _drag = null;
    private bool _isDragging = false;
    private Vector3 _offset = Vector3.zero;
    [SerializeField] private SlimeWander _slimeWander = null;
    [SerializeField] private LayerMask _maskMovable;
    [SerializeField] private AudioSource _carrySound = null;
    #endregion Fields
    #region Property
    public bool IsDragging
    {
        get
        {
            return _isDragging;
        }
    }
    #endregion Property
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _slimeWander.IsObstacled == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, _maskMovable);
            if(hit == true)
            {
                _drag = hit.transform;
                _offset = _drag.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _carrySound.Play();
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            _drag = null;
            _isDragging = true;
        }
        
        if(_drag != null)
        {
            _drag.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
        }

        if(Input.GetMouseButtonUp(0) && _slimeWander.IsObstacled == true)
        {
            
        }
    }
}
