using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text _displayTutorialLabel = null;
    [SerializeField] private string[] _labelsArray = null;
    [SerializeField] private AudioSource _buttonSound = null;
    private int _currentLabelIndex = 0;
    private bool _isOutside = false;
    private bool _hasTutorial = false;
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

    void Start()
    {
        _displayTutorialLabel.text = _labelsArray[_currentLabelIndex];
        _hasTutorial = false;

    }

    public void ChangeTextOnClick()
    {
        if(_isOutside == false && _currentLabelIndex < _labelsArray.Length)
        {
            _buttonSound.Play();
            _currentLabelIndex++;

            if (_currentLabelIndex > _labelsArray.Length)
            {
                gameObject.SetActive(false);
                _hasTutorial = true;
                _isOutside = true;
            }
            _displayTutorialLabel.text = _labelsArray[_currentLabelIndex];
        }
        else
        {
            gameObject.SetActive(false);
            _hasTutorial = true;
        }

        if(_currentLabelIndex >= 4)
        {
            gameObject.SetActive(false);
            _hasTutorial = true;
            Debug.Log("AHHH");
        }

    }
}
