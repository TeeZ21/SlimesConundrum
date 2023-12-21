using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private HappinessController _happinessController = null;
    [SerializeField] private GameObject _gameOverScreen = null;
    private string _scoreString = null;
    [SerializeField] private TMP_Text _scoreText = null;
    private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeOutCircle = null;
    private bool _hasFinishedMenuAnimation = false;
    private bool _hasFinishedRestartAnimation = false;
    private bool _isGameOver = false;
    public bool IsGameOver
    {
        get
        {
            return _isGameOver;
        }
    }
    void Start()
    {
        _gameOverScreen.SetActive(false);
        _fadeOutCircle.SetActive(false);
        HappinessManager.Instance.OnGameOver += DisplayScreen;
        HappinessManager.Instance.OnGameOver += SetScoreText;
    }

    private void Update()
    {
        if(_hasFinishedMenuAnimation == true || _hasFinishedRestartAnimation == true && _fadeAnimationTime > 0)
        {
            _fadeOutCircle.SetActive(true);
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedMenuAnimation == true)
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedRestartAnimation == true)
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void DisplayScreen()
    {
        if(_happinessController.CurrentHappiness <= 0)
        {
            _gameOverScreen.SetActive(true);
            _isGameOver = true;
        }
    }

    private void SetScoreText()
    {
        _scoreText.text = _scoreString;
        _scoreString = "Score : " + _happinessController.SlimeScore.ToString();
    }

    public void RestartLevel()
    {
        _hasFinishedRestartAnimation = true;
        Debug.Log("AHHHH");
    }

    public void OpenMainMenu()
    {
        _hasFinishedMenuAnimation = true;
    }

    private void OnApplicationQuit()
    {
        HappinessManager.Instance.OnGameOver -= DisplayScreen;
        HappinessManager.Instance.OnGameOver -= SetScoreText;
    }

    private void OnDestroy()
    {
        HappinessManager.Instance.OnGameOver -= DisplayScreen;
        HappinessManager.Instance.OnGameOver -= SetScoreText;
    }
}
