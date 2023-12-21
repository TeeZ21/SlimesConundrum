using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HappinessBarController : MonoBehaviour
{
    [SerializeField] private Image _fill = null;
    [SerializeField] private HappinessController _happinessController = null;
    private string _scoreString = null;
    [SerializeField] private TMP_Text _scoreText = null;
    [SerializeField] private TMP_Text _highScore = null;
    private Vector3 _endPos = Vector3.zero;
    private Vector3 _fullPos = Vector3.zero;

    void Start()
    {
        UpdateHighScoreText();
        _endPos.y = _fill.rectTransform.rect.height;
        HappinessManager.Instance.OnHappinessChange += UpdateBar;
        HappinessManager.Instance.OnHappinessChange += UpdateScoreText;
    }
    private void UpdateBar()
    {
        _fill.rectTransform.localPosition = Vector3.Lerp(_endPos, _fullPos, _happinessController.HappinessPerc);
    }

    public void UpdateScoreText()
    {
        _scoreText.text = _scoreString;
        _scoreString = "Slime : " + _happinessController.SlimeScore.ToString();
    }

    void UpdateHighScoreText() 
    {
        _highScore.text = $"HighScore : {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    private void OnApplicationQuit()
    {
        HappinessManager.Instance.OnHappinessChange -= UpdateBar;
        HappinessManager.Instance.OnHappinessChange -= UpdateScoreText;
    }
}
