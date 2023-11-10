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

    protected override void Update()
    {
        ChangeHappiness();
    }
    public void ChangeHappiness()
    {
        if( _happinessChange != null )
        {
            _happinessChange();
        }
    }
}
