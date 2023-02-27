using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveAsteroid : MonoBehaviour
{
    /// <summary>
    /// Asteroid Speed
    /// </summary>
    [SerializeField]
    private float _maxSpeed = 1f;

    [SerializeField]
    private float _minSpeed = 1f;

    private float _speed = 1f;

    [SerializeField]
    private Rigidbody _rb;

    //[SerializeField]
    //private Transform _targetTransform;


    // Start is called before the first frame update
    void Start()
    {
        _speed = Random.Range(_minSpeed, _maxSpeed);
        print("Speed : " + _speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //var dir = (_targetTransform.position - transform.position).normalized;

        _rb.velocity = _speed * Vector3.forward * Time.fixedDeltaTime;
    }

}
