using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _settingsMenu = null;
    [SerializeField] private GameObject _quitCheck = null;


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
    }

    #region Quit Methods
    public void QuitChecking()
    {
        _quitCheck.SetActive(true);
    }

    public void QuitY()
    {
        Application.Quit();
    }

    public void QuitN()
    {
        _quitCheck.SetActive(false);
    }
    #endregion Quit Methods
}
