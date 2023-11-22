using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] private HappinessController _happinessController = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" && Drag._isDragging == false)
        {
            _happinessController.Sadnessed(5f);
        }
    }

}