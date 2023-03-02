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
    private int BaseHP{ get; set;} = 10;
    [SerializeField]
    private CodeLyoko _codeLyoko;
    [SerializeField]
    private Image _healthBar;
    [field:SerializeField]
    private TMP_Text _healthPoints;
    [field:SerializeField]
    private TMP_Text WaveDisplay;
    [field:SerializeField]
    private TMP_Text WaveCoolDownDisplay;

    bool waitNextWave = false;
    float timeToNextWave = 0;



    // Start is called before the first frame update
    void Start(){
        startWave();
        updateHP(BaseHP);
    }

    // Update is called once per frame
    void Update(){
        if (waitNextWave){
            
            timeToNextWave -= Time.deltaTime;
            if (timeToNextWave <=0){
                newWave();
            }
            updateCoolDownDisplay();
        }
    }

    void newWave(){
        currentWave ++;
        waitNextWave = false;
        updateWaveDisplay();
        startWave();
    }

    void startWave(){
        spawner.startNewWave(wave.waveList[currentWave]);
    }

    public void endWave(){
        timeToNextWave = wave.waveList[currentWave].TimeBeforeNextWave;
        waitNextWave = true;



    }

    void updateWaveDisplay(){
        WaveDisplay.SetText("Wave " + (currentWave).ToString() );
    }
    void updateCoolDownDisplay(){
        if (timeToNextWave>0){
            WaveCoolDownDisplay.SetText("Next wave " + (timeToNextWave).ToString() );
        }else{
            WaveCoolDownDisplay.SetText("");
        }
        
    }


//PV
    void updateHP(int HP){
        _healthBar.fillAmount = (float)HP / 10.0f;
        _healthPoints.SetText((HP).ToString() + " HP");
    }

    public void TakeDamage(int damage = 1){
        BaseHP -= damage;
        updateHP(BaseHP);      
        if (BaseHP <= 0.0f){
            _codeLyoko.StartScaling();
        }
    }
}
