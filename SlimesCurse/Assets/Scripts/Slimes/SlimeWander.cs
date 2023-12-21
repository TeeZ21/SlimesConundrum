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
    [SerializeField] private GameOver _gameOver = null;
    [SerializeField] private ESlimeTypes _slimeTypes = ESlimeTypes.BLACK;
    [SerializeField] private Tutorial _tutorial = null;
    [SerializeField] private Drag _drag = null;

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
        MovingToWayPoint();
    }
    void MovingToWayPoint()
    {
        if(_gameOver.IsGameOver == false && _tutorial.HasTutorial == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _wayPoint, _speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _wayPoint) < _range && _isObstacled == false)
            {
                SetNewDestination();
            }
        }
    }

    void SetNewDestination()
    {
        _wayPoint = new Vector2(Random.Range(-_maxDistance, _maxDistance), Random.Range(-_maxDistance, _maxDistance));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && _drag.IsDragging == true)
        {
            HappinessSpace spaceTypes = collision.GetComponent<HappinessSpace>();
            if(_slimeTypes == spaceTypes.SpaceTypes)
            {
                _isObstacled = true;
                _wayPoint = collision.transform.position;
                _rigidbody.velocity = Vector2.zero;
                _happinessController.IncreaseSlimeScore(5);
            }
        }

        if(collision.tag == "Slime")
        {
            _happinessController.Sadnessed(20f);
        }
    }
}
