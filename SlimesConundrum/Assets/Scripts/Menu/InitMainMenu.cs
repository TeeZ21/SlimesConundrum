using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMainMenu : MonoBehaviour
{
    private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeInCircle = null;
    [SerializeField] private AudioSource _backgroundMusic = null;

    void Start()
    {
        _fadeInCircle.SetActive(true);
        _backgroundMusic.Play();
    }

    void Update()
    {
        if (_fadeAnimationTime > 0)
        {
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0)
        {
            _fadeInCircle.SetActive(false);
        }
    }
}
