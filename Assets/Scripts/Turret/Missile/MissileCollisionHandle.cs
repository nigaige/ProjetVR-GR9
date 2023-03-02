using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileCollisionHandle : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem _hitParticle;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        _hitParticle.Play();
        Destroy(this);

        if (collision.collider.CompareTag("Hittable"))
        {
            Destroy(collision.gameObject);
        }
            
    }

}
