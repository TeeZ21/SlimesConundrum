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
    [SerializeField] private AudioSource _backgroundMusic = null;
    public AudioSource BackgroundMusic
    {
        get
        {
            return _backgroundMusic;
        }
    }
    void Start()
    {
        _fadeInCircle.SetActive(true);
        _tutorialPanel.SetActive(false);
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
            _tutorialPanel.SetActive(true);
            _tutorial.HasTutorial = true;
        }
    }
}
