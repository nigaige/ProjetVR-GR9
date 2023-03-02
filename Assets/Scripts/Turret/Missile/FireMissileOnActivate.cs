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

    private bool isFiring = false;
    private bool isCoolingDown = false;

    private XRGrabInteractable _interactable;

    [SerializeField]
    private HapticInteractable _haptic;

    [field:SerializeField] 
    public int Ammo { get; private set; } = 10;
    [field:SerializeField] 
    public int MaxAmmo { get; private set; } = 20;

    private XRBaseController _controller;

    [SerializeField]
    private float hapticDuration = 0;
    [SerializeField]
    private float hapticIntensity = 0;

    [SerializeField]
    public TMP_Text AmmoText;
    [SerializeField]
    public TMP_Text MaxAmmoText;

    [SerializeField]
    private TurretSFX _tSFX;


    private void Start(){
        MaxAmmoText.SetText(MaxAmmo.ToString());
        AmmoText.SetText(Ammo.ToString());
    }
    
    private void Awake()
    {
        _interactable = GetComponentInParent<XRGrabInteractable>();
        Mathf.Clamp(_timeBetweenShots, 0f, 1f);
    }



    public void StartFire(ActivateEventArgs arg) {
        isFiring = true;
        if (arg.interactorObject is XRBaseControllerInteractor controllerInteractor){
            Debug.Log(controllerInteractor);
            _controller = controllerInteractor.xrController;
        }
        FireMissile();
        
    }

    public void StopFire(DeactivateEventArgs arg) { 
        isFiring = false;
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

    private IEnumerator coolingDown (){
        isCoolingDown = true;
        yield return new WaitForSeconds(_timeBetweenShots);
        isCoolingDown = false;
        FireMissile();
    }

    public void TriggerHaptic(){
            _controller.SendHapticImpulse(hapticIntensity,hapticDuration);
  
      }

    public void FireMissile()
    {
        if (isCoolingDown) return;
        if (Ammo > 0 && isFiring){
            GameObject spawnedMissile = Instantiate(_missile);

            spawnedMissile.transform.position = _spawnPoint.transform.position;
            spawnedMissile.GetComponent<Rigidbody>().velocity = _spawnPoint.transform.forward * _fireSpeed;

            Destroy(spawnedMissile, 5);
            Ammo--;
            AmmoText.SetText(Ammo.ToString());
            TriggerHaptic();
            _tSFX.PlayShootSound();
            StartCoroutine(coolingDown());
        }
    }
}
