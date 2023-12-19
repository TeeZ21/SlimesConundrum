using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWander : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Rigidbody2D _rigidbody;
    public bool _isObstacled = false;
    [SerializeField] private HappinessBarController _happinessBarController = null;
    [SerializeField] private HappinessController _happinessController = null;
    private Vector2 _wayPoint;
    /*public bool IsObstacled
    {
        get 
        { 
            return _isObstacled; 
        }
    }*/
    void Start()
    {
        _isObstacled = false;
        SetNewDestination();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoint, _speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, _wayPoint) < _range && _isObstacled == false)
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        _wayPoint = new Vector2(Random.Range(-_maxDistance, _maxDistance), Random.Range(-_maxDistance, _maxDistance));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Debug.Log("Obstacle");
            _isObstacled = true;
            _wayPoint = collision.transform.position;
            _rigidbody.velocity = Vector2.zero;
            _happinessController.IncreaseSlimeScore(1);
            Debug.Log(_isObstacled);
        }
    }
}
