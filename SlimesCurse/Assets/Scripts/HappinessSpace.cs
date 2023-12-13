using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HappinessSpace : MonoBehaviour
{
    [SerializeField] private ESlimeTypes _spaceTypes = ESlimeTypes.BLACK;
    [SerializeField] private Animator _slimeAnim = null;

    void Start()
    {
        _slimeAnim.SetBool("isMoving", true);
    }

    void Update()
    {
        
    }

    void Test()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Slime" && Drag._isDragging == true)
        {
            _slimeAnim.SetBool("isMoving", false);
        }
    }
}
