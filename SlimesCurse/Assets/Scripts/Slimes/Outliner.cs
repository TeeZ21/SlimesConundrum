using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner : MonoBehaviour
{
    #region Fields
    [SerializeField] private Outline _outline = null;
    [SerializeField] private SlimeWander _slimeWander = null;
    [SerializeField] private GameOver _gameOver = null;
    #endregion Fields
    #region Methods
    private void Start()
    {
        _outline.enabled = false;
    }

    private void OnMouseEnter()
    {
        if(_slimeWander.IsObstacled == false && _gameOver.IsGameOver == false)
        {
            _outline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        _outline.enabled = false;
    }
    #endregion Methods
}
