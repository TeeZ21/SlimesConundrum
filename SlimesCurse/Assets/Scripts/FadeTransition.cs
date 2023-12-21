using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour
{
    [SerializeField] private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeInCircle = null;
    [SerializeField] private GameObject _tutorialPanel = null;
    [SerializeField] private Tutorial _tutorial = null;
    void Start()
    {
        _fadeInCircle.SetActive(true);
        _tutorialPanel.SetActive(false);
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
            _tutorialPanel.SetActive(true);
            _tutorial.HasTutorial = true;
        }
    }
}
