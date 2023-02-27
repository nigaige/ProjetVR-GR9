using UnityEngine;

public class AsteroidDestroyHandle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem;

    private void OnDestroy()
    {
        Explode();
    }

    private void Explode()
    {
        particleSystem.Play();
    }
}
