using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    #region Fields
    private int _currentLabelIndex = 0;
    private bool _hasTutorial = false;
    [Header("Label")]
    [SerializeField] private TMP_Text _displayTutorialLabel = null;
    [SerializeField] private string[] _labelsArray = null;
    [Header("Blur")]
    [SerializeField] private GameObject _blurBackground = null;
    [SerializeField] private GameObject _blurHappinessBar = null;
    [SerializeField] private GameObject _blurScore = null;
    [SerializeField] private GameObject _blurContainer = null;
    [SerializeField] private GameObject _king = null;
    [Header("Sound")]
    [SerializeField] private AudioSource _buttonSound = null;

    #endregion Fields

    #region Property
    public bool HasTutorial
    {
        get
        {
            return _hasTutorial;
        }
        set
        {
            _hasTutorial = value;
        }
    }

    #endregion Property

    #region Methods
    void Start()
    {
        _displayTutorialLabel.text = _labelsArray[_currentLabelIndex];
        _blurBackground.SetActive(true);
        _king.SetActive(true);
        _blurHappinessBar.SetActive(false);
        _blurScore.SetActive(false);
        _blurContainer.SetActive(false);
    }

    public void ChangeTextOnClick()
    {
        if(_currentLabelIndex < _labelsArray.Length)
        {
            _buttonSound.Play();
            _currentLabelIndex++;

            if (_currentLabelIndex == _labelsArray.Length - 1)
            {
                gameObject.SetActive(false);
                HasTutorial = true;
            }
            _displayTutorialLabel.text = _labelsArray[_currentLabelIndex];
        }

        if(_currentLabelIndex == 1)
        {
            SetContainersPanel();
        }
        if (_currentLabelIndex == 2)
        {
            SetHappinessBarPanel();
        }
        if (_currentLabelIndex == 3)
        {
            SetScorePanel();
        }
    }

    #region SetPanels
    private void SetContainersPanel()
    {
        _blurBackground.SetActive(false);
        _blurHappinessBar.SetActive(false);
        _blurScore.SetActive(false);
        _blurContainer.SetActive(true);
        _king.SetActive(true);
    }

    private void SetHappinessBarPanel()
    {
        _blurBackground.SetActive(false);
        _blurHappinessBar.SetActive(true);
        _blurScore.SetActive(false);
        _blurContainer.SetActive(false);
        _king.SetActive(false);
    }
    private void SetScorePanel()
    {
        _blurBackground.SetActive(false);
        _blurHappinessBar.SetActive(false);
        _blurScore.SetActive(true);
        _blurContainer.SetActive(false);
        _king.SetActive(true);
    }

    #endregion SetPanels

    #endregion Methods
}
