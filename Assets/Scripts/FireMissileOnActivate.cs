using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireMissileOnActivate : MonoBehaviour
{
    [SerializeField]
    private GameObject _missile;

    [SerializeField]
    private float _fireSpeed;

    private Transform _spawnPoint;


    private void Awake()
    {
        _spawnPoint = GetComponentInChildren<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireMissile);

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireMissile(ActivateEventArgs arg)
    {
        GameObject spawnedMissile = Instantiate(_missile);

        spawnedMissile.transform.position = _spawnPoint.position;
        spawnedMissile.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * _fireSpeed;

        Destroy(spawnedMissile, 5);
    }
}
