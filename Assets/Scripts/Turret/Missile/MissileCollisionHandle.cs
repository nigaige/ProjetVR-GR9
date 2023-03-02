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

    private void OnTriggerEnter(Collider other)
    {

        //_hitParticle.Play();
        Destroy(other.gameObject);
        Destroy(this);


            
    }

}
