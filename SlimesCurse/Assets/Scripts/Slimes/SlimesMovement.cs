using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlimesMovement : MonoBehaviour
{
    [SerializeField] private GameObject _gameArea = null;
    [SerializeField] private SlimesSpawner _spawner = null;

    private float _speed = 15f; 
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
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
    }
}
