using UnityEngine;

public class AsteroidDestroyHandle : MonoBehaviour
{

    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }


    private void OnDestroy()
    {
        Explode();
    }

    private void Explode()
    {
        _particleSystem.Play();
    }

}
