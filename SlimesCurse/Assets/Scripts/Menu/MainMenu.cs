using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _settingsMenu = null;
    [SerializeField] private GameObject _quitCheck = null;
    [SerializeField] private GameObject _blur = null;
    [Header("Text")]
    [SerializeField] private TMP_Text _settings = null;
    private float _fontSize = 75f;
    [Header("Animation")]
    [SerializeField] private Animator _fade = null;
    private float _transitionTime = 1f;
    private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeOutCircle = null;
    private bool _hasFinishedQuitAnimation = false;

    void Start()
    {
        _mainMenu.SetActive(true);
        _quitCheck.SetActive(false);
    }

    public void Play()
    {
        //StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        SceneManager.LoadScene("Game");
    }

    public IEnumerator LoadScene(int levelIndex)
    {
        _fade.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void OpenSettings()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
        _settings.fontSize = _fontSize;
    }

    #region Quit Methods
    public void QuitChecking()
    {
        _quitCheck.SetActive(true);
        _blur.SetActive(true);
    }
    private void Update()
    {
        if (_hasFinishedQuitAnimation == true && _fadeAnimationTime > 0)
        {
            _fadeOutCircle.SetActive(true);
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedQuitAnimation == true)
        {
            Application.Quit();
        }
    }

    public void QuitY()
    {
        _hasFinishedQuitAnimation = true;
    }

    public void QuitN()
    {
        _quitCheck.SetActive(false);
        _blur.SetActive(false);
    }
    #endregion Quit Methods
}
