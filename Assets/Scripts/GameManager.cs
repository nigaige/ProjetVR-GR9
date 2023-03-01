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


}
