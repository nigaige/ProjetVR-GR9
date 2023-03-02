using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour{


    private int currentAsteroidCount = 0;

    private int currentWave = 0;

    [SerializeField]
    private WaveList wave;
    [SerializeField]
    private SpawnZone spawner;
    [SerializeField]
    private float BaseHP{ get; set;} = 10.0f;
    [SerializeField]
    private CodeLyoko _codeLyoko;
    [SerializeField]
    private Image _healthBar;
    [field:SerializeField]
    private TMP_Text _healthPoints;

    // Start is called before the first frame update
    void Start(){
        newWave();
        _healthBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.fillAmount = BaseHP / 10.0f;
        _healthPoints.SetText(((int) BaseHP).ToString() + " HP");
    }

    void newWave(){
        spawner.startNewWave(wave.waveList[currentWave]);

    }

    public void TakeDamage(){
        BaseHP = BaseHP - 1.0f;        
        if (BaseHP <= 0.0f){
            _codeLyoko.StartScaling();
        }
    }
}
