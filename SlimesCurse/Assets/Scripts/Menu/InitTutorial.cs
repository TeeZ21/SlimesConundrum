using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitTutorial : MonoBehaviour
{
    #region Fields
    private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeInCircle = null;
    [SerializeField] private GameObject _tutorialPanel = null;
    [SerializeField] private Tutorial _tutorial = null;
    [SerializeField] private AudioSource _backgroundMusic = null;
    #endregion Fields
    #region Property
    public AudioSource BackgroundMusic
    {
        get
        {
            return _backgroundMusic;
        }
    }
    #endregion Property
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

        if (_fadeAnimationTime <= 0 && _tutorial.HasTutorial == false)
        {
            _fadeInCircle.SetActive(false);
            _tutorialPanel.SetActive(true);
        }
    }
}
