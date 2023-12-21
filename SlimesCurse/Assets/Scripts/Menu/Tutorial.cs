using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text _displayTutorialLabel = null;
    [SerializeField] private string[] _labelsArray = null;
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
            _currentLabelIndex++;

            if (_currentLabelIndex > _labelsArray.Length)
            {
                this.gameObject.SetActive(false);
                _hasTutorial = false;
                _isOutside = true;
            }
            _displayTutorialLabel.text = _labelsArray[_currentLabelIndex];
        }
        else
        {
            this.gameObject.SetActive(false);
            _hasTutorial = false;
        }

    }
}
