using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FireMissileOnActivate : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty _indexTrigger; 

    [SerializeField]
    private GameObject _missile;

    [SerializeField]
    private GameObject _spawnPoint;

    [SerializeField]
    private float _fireSpeed;

    private XRBaseController _leftHand;
    private XRBaseController _rightHand;

    [SerializeField]
    [Range(0f, 1f)]
    private float _timeBetweenShots;

    private XRGrabInteractable _interactable;

    [SerializeField]
    private HapticInteractable _haptic;

    [field:SerializeField] 
    public int Ammo { get; private set; } = 10;
    [field:SerializeField] 
    public int MaxAmmo { get; private set; } = 20;
    
    [SerializeField]
    public TMP_Text AmmoText;
    [SerializeField]
    public TMP_Text MaxAmmoText;

    [SerializeField]
    private TurretSFX _tSFX;


    private void Start(){
        MaxAmmoText.SetText(MaxAmmo.ToString());
        AmmoText.SetText(MaxAmmo.ToString());
    }
    
    private void Awake()
    {
        _interactable = GetComponentInParent<XRGrabInteractable>();
        Mathf.Clamp(_timeBetweenShots, 0f, 1f);
    }


    private IEnumerator FireMissile()
    {
        while (true) 
        {
            if(Ammo <= 0)
            {
                Mathf.Clamp(Ammo, 0, MaxAmmo);
                StopCoroutine(FireMissile());
            }
            
            // Set missile
            GameObject spawnedMissile = Instantiate(_missile);
            spawnedMissile.transform.position = _spawnPoint.transform.position;
            spawnedMissile.GetComponent<Rigidbody>().velocity = _spawnPoint.transform.forward * _fireSpeed;
            Destroy(spawnedMissile, 5);

            _haptic.TriggerHaptic();
            Ammo--;

            yield return new WaitForSeconds(_timeBetweenShots);
        }
    }


    public void StartFire(ActivateEventArgs arg)
    {
        if (Ammo >= 0 && _interactable.interactorsSelecting.Count == 2)
            StartCoroutine(FireMissile());
    }

    public void StopFire(DeactivateEventArgs arg) 
    { 
        StopCoroutine(FireMissile());
    }

    public void getAmmo(int count)
    {
        if (count > 0)
        {
            Debug.Log("Got Ammo");
            Ammo += count;
        }
        if (Ammo > MaxAmmo)
        {
            Ammo = MaxAmmo;
        }
    }

    public void FireMissile(ActivateEventArgs arg)
    {
        if (Ammo > 0){
            GameObject spawnedMissile = Instantiate(_missile);

            spawnedMissile.transform.position = _spawnPoint.transform.position;
            spawnedMissile.GetComponent<Rigidbody>().velocity = _spawnPoint.transform.forward * _fireSpeed;

            Destroy(spawnedMissile, 5);
            Ammo--;
            _tSFX.PlayShootSound();
            AmmoText.SetText(Ammo.ToString());
        }
    }
}
