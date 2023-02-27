using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireMissileOnActivate : MonoBehaviour
{
    [SerializeField]
    private GameObject _missile;

    [SerializeField]
    private GameObject _spawnPoint;

    [SerializeField]
    private float _fireSpeed;


    public void FireMissile(ActivateEventArgs arg)
    {
        GameObject spawnedMissile = Instantiate(_missile);

        spawnedMissile.transform.position = _spawnPoint.transform.position;
        spawnedMissile.GetComponent<Rigidbody>().velocity = _spawnPoint.transform.forward * _fireSpeed;

        Destroy(spawnedMissile, 5);
    }
}
