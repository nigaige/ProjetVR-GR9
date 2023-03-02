using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private CodeLyoko cl;

    // Start is called before the first frame update
    void Start(){
        newWave();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void newWave(){
        spawner.startNewWave(wave.waveList[currentWave]);

    }

    public void TakeDamage(){
        BaseHP--;
        if (BaseHP == 0){
            cl.StartScaling();
        }
    }
}
