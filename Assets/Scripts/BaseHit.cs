using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHit : MonoBehaviour
{

    [SerializeField]
    private GameManager gm;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        gm.TakeDamage();
    }
}