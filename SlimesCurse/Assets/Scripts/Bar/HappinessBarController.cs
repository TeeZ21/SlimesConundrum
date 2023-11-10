using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HappinessBarController2 : MonoBehaviour
{
    [SerializeField] private Image _fill = null;
    [SerializeField] private HappinessController _happinessController = null;

    private Vector3 _endPos = Vector3.zero;
    private Vector3 _fullPos = Vector3.zero;

    void Start()
    {
        _endPos.y = _fill.rectTransform.rect.height;
        HappinessManager.Instance.OnHappinessChange += UpdateBar;
    }
    private void UpdateBar()
    {
        _fill.rectTransform.localPosition = Vector3.Lerp(_endPos, _fullPos, _happinessController.HappinessPerc);
    }

    private void OnApplicationQuit()
    {
        HappinessManager.Instance.OnHappinessChange -= UpdateBar;
    }
}
