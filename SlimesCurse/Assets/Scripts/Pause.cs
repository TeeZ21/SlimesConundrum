using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu = null;
    [SerializeField] private GameObject _resumeMenu = null;
    [SerializeField] private GameObject _blurBackground = null;
    private bool _isPaused = false;
    public bool IsPaused
    {
        get
        {
            return _isPaused;
        }

        set
        {
            _isPaused = value;
        }
    }

    void Start()
    {
        _pauseMenu.SetActive(false);
        _resumeMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = true;
            _pauseMenu.SetActive(true);
            _resumeMenu.SetActive(true);
            _blurBackground.SetActive(true);
        }
    }
}
