using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;

public class HappinessManager : Singleton<HappinessManager>
{
    #region Fields
    private event Action _happinessChange = null;
    private event Action _gameOver = null;
    #endregion Fields

    #region Properties

    public event Action OnHappinessChange
    {
        add
        {
            _happinessChange -= value;
            _happinessChange += value;
        }
        remove
        {
            _happinessChange -= value;
        }
    }

    public event Action OnGameOver
    {
        add
        {
            _gameOver -= value;
            _gameOver += value;
        }
        remove
        {
            _gameOver -= value;
        }
    }

    #endregion Properties

    #region Methods
    protected override void Update()
    {
        ChangeHappiness();
        DisplayGameOver();
    }
    public void ChangeHappiness()
    {
        if( _happinessChange != null )
        {
            _happinessChange();
        }
    }
    public void DisplayGameOver()
    {
        if(_gameOver != null)
        {
            _gameOver();
        }
    }

    #endregion Methods
}
