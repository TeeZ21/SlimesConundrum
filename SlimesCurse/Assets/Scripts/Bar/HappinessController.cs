using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessController : MonoBehaviour
{
    private float _currentHappiness = 100f;
    private float _maxHappiness = 100f;
    private float _sadness = 5f;
    private float _happiness = 1f;
    public float Sadness
    {
        get
        {
            return _sadness;
        }
    }
    public float HappinessPerc
    {
        get
        {
            return CurrentHappiness / _maxHappiness;
        }
    }
    public float CurrentHappiness
    {
        get
        {
            return _currentHappiness;
        }
        set
        {
            _currentHappiness = Mathf.Clamp(value, 0, _maxHappiness);
            HappinessManager.Instance.ChangeHappiness();
        }
    }
    void Start()
    {
        CurrentHappiness = _maxHappiness;
        GameLoopManager.Instance.OnGameLoop += Sadnessing;
        GameLoopManager.Instance.OnGameLoop += Happinessing;
    }

    void Sadnessing()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CurrentHappiness -= Sadness;
        }
    }

    public void Sadnessed(float value)
    {
        CurrentHappiness -= value;
    }

    void Happinessing()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CurrentHappiness += Sadness;
        }
    }

    private void OnDestroy()
    {
        GameLoopManager.Instance.OnGameLoop -= Sadnessing;
        GameLoopManager.Instance.OnGameLoop -= Happinessing;
    }

    private void OnApplicationQuit()
    {
        GameLoopManager.Instance.OnGameLoop -= Sadnessing;
        GameLoopManager.Instance.OnGameLoop -= Happinessing;
    }
}
