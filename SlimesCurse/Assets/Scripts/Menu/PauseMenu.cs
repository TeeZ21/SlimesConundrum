using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _resumeMenu = null;
    [SerializeField] private GameObject _settingsMenu = null;
    [SerializeField] private GameObject _quitCheck = null;
    [SerializeField] private GameObject _quitBlur = null;
    [SerializeField] private Pause _pause = null;
    [SerializeField] private GameObject _blurBackground = null;
    [Header("Text")]
    [SerializeField] private TMP_Text _settings = null;
    private float _fontSize = 75f;
    [Header("Animation")]
    [SerializeField] private Animator _fade = null;
    private float _transitionTime = 1f;
    private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeOutCircle = null;
    private bool _hasFinishedQuitAnimation = false;
    private bool _hasFinishedReturnMainAnimation = false;
    [SerializeField] private AudioSource _buttonSound = null;

    void Start()
    {
        _settingsMenu.SetActive(false);
        _quitCheck.SetActive(false);
    }

    public void Resume()
    {
        _pause.IsPaused = false;
        _resumeMenu.SetActive(false);
        _blurBackground.SetActive(false);
    }

    public void OpenSettings()
    {
        _buttonSound.Play();
        _resumeMenu.SetActive(false);
        _settingsMenu.SetActive(true);
        _settings.fontSize = _fontSize;
    }

    #region Quit Methods
    public void QuitChecking()
    {
        _buttonSound.Play();
        _quitCheck.SetActive(true);
        _quitBlur.SetActive(true);
    }
    private void Update()
    {
        if (_hasFinishedQuitAnimation == true | _hasFinishedReturnMainAnimation == true && _fadeAnimationTime > 0)
        {
            _fadeOutCircle.SetActive(true);
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedQuitAnimation == true)
        {
            Application.Quit();
        }

        if(_fadeAnimationTime <= 0 && _hasFinishedReturnMainAnimation == true)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ReturnToMainMenu()
    {
        _buttonSound.Play();
        _hasFinishedReturnMainAnimation = true;
    }

    public void BackQuit()
    {
        _buttonSound.Play();
        _quitCheck.SetActive(false);
        _quitBlur.SetActive(false);
    }

    public void QuitTheGame()
    {
        _buttonSound.Play();
        _hasFinishedQuitAnimation = true;
    }
    #endregion Quit Methods

}
