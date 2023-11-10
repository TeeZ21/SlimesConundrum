using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameLoopManager : Singleton<GameLoopManager>
{
    private event Action _earlyGameLoop = null;
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

    private event Action _gameLoop = null;
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

    private event Action _lateGameLoop = null;
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
