using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
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
    [SerializeField]
    private ParticleSystem _destroyParticle;

    [field:SerializeField] 
    public SpawnZone spawner { get; set; }



    //[SerializeField]
    //private Transform _targetTransform;


    // Start is called before the first frame update
    void Start()
    {
        _speed = Random.Range(_minSpeed, _maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //var dir = (_targetTransform.position - transform.position).normalized;

        _rb.velocity = _speed * transform.forward * Time.fixedDeltaTime;
    }


    private void OnDestroy()
    {
        spawner.asteroidDestroyed();

        ParticleSystem particle = Instantiate(_destroyParticle);
        particle.GetComponent<ParticleSystem>().Play(true);
        particle.gameObject.transform.position = transform.position;
       // Destroy(particle, 2);
        //_particleSystem.Play();
    }
}
