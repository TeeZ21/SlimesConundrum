using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HappinessBarController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Image _fill = null;
    [SerializeField] private HappinessController _happinessController = null;
    [SerializeField] private TMP_Text _scoreText = null;
    private string _scoreString = null;
    private Vector3 _endPos = Vector3.zero;
    private Vector3 _fullPos = Vector3.zero;
    #endregion Fields

    #region Methods
    void Start()
    {
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
        _scoreString = "Score : " + _happinessController.SlimeScore.ToString();
    }

    private void OnApplicationQuit()
    {
        HappinessManager.Instance.OnHappinessChange -= UpdateBar;
        HappinessManager.Instance.OnHappinessChange -= UpdateScoreText;
    }
    
    #endregion Methods
}
