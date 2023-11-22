using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement2 : MonoBehaviour
{
    [SerializeField] private GameObject _gameArea = null;
    [SerializeField] private SlimesSpawner _spawner = null;
    [SerializeField] private HappinessController _happinessController = null;
    [SerializeField] private GameObject _angry = null;

    private float _speed = 1f;
    void Start()
    {
        _angry.SetActive(false);
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        transform.position -= Vector3.right * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" && Drag._isDragging == false)
        {
            _happinessController.Sadnessed(5f);
            _angry.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _angry.SetActive(false);
    }

    /*void Move()
    {
        transform.position += transform.up * (_speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, _gameArea.transform.position);
        if (distance > _spawner._deathCircleRadius)
        {
            RemoveSlime();
        }
    }

    void RemoveSlime()
    {
        Destroy(gameObject);
    }*/
}
