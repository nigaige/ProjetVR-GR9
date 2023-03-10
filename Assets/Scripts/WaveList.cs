using System;
using UnityEngine;
using System.Collections.Generic;   


    [Serializable]
    public struct range{
        public float min;
        public float max;
       
    }

    [Serializable]
    public struct Wave{
        public int asteroidCount;
        public int maxAsteroidWave;
        public float asteroidSpeed;
        public float TimeBeforeNextWave;
        public range timeBetweenSpawn;
    }


[CreateAssetMenu]
public class WaveList : ScriptableObject{

    [SerializeField]
    public List<Wave> waveList = new List<Wave>();

}
