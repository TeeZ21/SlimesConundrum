using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour
{
    [SerializeField] private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeInCircle = null;
    void Start()
    {
        _fadeInCircle.SetActive(true);
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
