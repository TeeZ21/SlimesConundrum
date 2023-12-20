using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner : MonoBehaviour
{
    [SerializeField] private Outline _outline = null;
    [SerializeField] private SlimeWander _slimeWander = null;
    [SerializeField] private GameOver _gameOver = null;
    private void Start()
    {
        _outline.enabled = false;
    }

    private void OnMouseEnter()
    {
        if(_slimeWander._isObstacled == false && _gameOver.IsGameOver == false)
        {
            _outline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        _outline.enabled = false;
    }
}
