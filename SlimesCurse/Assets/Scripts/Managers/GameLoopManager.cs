using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameLoopManager : Singleton<GameLoopManager>
{
    #region Fields
    private event Action _earlyGameLoop = null;
    private event Action _gameLoop = null;
    private event Action _lateGameLoop = null;
    #endregion Fields

    #region Properties

    public event Action OnEarlyGameLoop
    {
        add
        {
            _earlyGameLoop -= value;
            _earlyGameLoop += value;
        }
        remove
        {
            _earlyGameLoop -= value;
        }
    }

    public event Action OnGameLoop
    {
        add
        {
            _gameLoop -= value;
            _gameLoop += value;
        }
        remove
        {
            _gameLoop -= value;
        }
    }

    public event Action OnLateGameLoop
    {
        add
        {
            _lateGameLoop -= value;
            _lateGameLoop += value;
        }
        remove
        {
            _lateGameLoop -= value;
        }
    }
    #endregion Properties

    protected override void Update()
    {
        if (_earlyGameLoop != null)
            _earlyGameLoop();
        if (_gameLoop != null)
            _gameLoop();
        if (_lateGameLoop != null)
            _lateGameLoop();
    }
}
