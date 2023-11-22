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


    void Start()
    {
        _mainMenu.SetActive(true);
        _quitCheck.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
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

    public void QuitY()
    {
        Application.Quit();
    }

    public void QuitN()
    {
        _quitCheck.SetActive(false);
        _blur.SetActive(false);
    }
    #endregion Quit Methods
}
