using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HappinessController : MonoBehaviour
{
    #region Fields
    private float _currentHappiness = 100f;
    private int _slimeScore = 0;
    private float _maxHappiness = 100f;
    private float _anger = 5f;
    private float _happiness = 1f;
    [SerializeField] private TMP_Text _highScore = null;
    #endregion Fields

    #region Properties
    public float Anger
    {
        get
        {
            return _anger;
        }
    }
    public float HappinessPerc
    {
        get
        {
            return CurrentHappiness / _maxHappiness;
        }
    }
    public float CurrentHappiness
    {
        get
        {
            return _currentHappiness;
        }
        set
        {
            _currentHappiness = Mathf.Clamp(value, 0, _maxHappiness);
            HappinessManager.Instance.ChangeHappiness();
        }
    }

    public int SlimeScore
    {
        get
        {
            return _slimeScore;
        }
        set
        {
            _slimeScore += 1;
        }
    }

    #endregion Properties

    #region Methods
    void Start()
    {
        CurrentHappiness = _maxHappiness;
        HappinessManager.Instance.OnHappinessChange += UpdateHighScoreText;
    }

    public void ProvokeAnger(float value)
    {
        CurrentHappiness -= value;
    }

    public void IncreaseSlimeScore(int value)
    {
        SlimeScore += value;
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if(SlimeScore > PlayerPrefs.GetInt("HighScore", 0)) 
        {
            PlayerPrefs.SetInt("HighScore", SlimeScore);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        _highScore.text = $"HighScore : {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    private void OnApplicationQuit()
    {
        HappinessManager.Instance.OnHappinessChange -= UpdateHighScoreText;
    }

    #endregion Methods
}
