using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;

public class HappinessManager : Singleton<HappinessManager>
{
    private event Action _happinessChange = null;
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

    private event Action _gameOver = null;
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
}
