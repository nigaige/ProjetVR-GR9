using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnZone : MonoBehaviour
{
    /// <summary>
    /// Zone
    /// </summary>
    [SerializeField]
    private Vector3 _center;
    [SerializeField]
    private Vector3 _size;
    [SerializeField]
    private int _maxAsteroidInZone;

    /// <summary>
    /// Object To Spawn
    /// </summary>
    [SerializeField]
    private Asteroid asteroid;

    [SerializeField]
    private GameManager GM;



    private Wave currentWave;
    private int leftToSpawn = 0;


    //private List<GameObject> spawnedObjectsList = new();

    private int currentAsteroidCount = 0;

    private UnityEvent _spawnEvent;



    // Start is called before the first frame update
    private void Start()
    {

        if (_spawnEvent == null)
            _spawnEvent = new UnityEvent();

        _center = transform.position;

    }

    private void Update(){
    }

    public void startNewWave(Wave waveData){
        StopCoroutine(SpawnAsteroid());
        currentWave = waveData;
        leftToSpawn = waveData.asteroidCount;
        StartCoroutine(SpawnAsteroid());
    }

    public void asteroidDestroyed(){
        currentAsteroidCount --;
    }


    public IEnumerator SpawnAsteroid()
    {
        while (leftToSpawn > 0)
        {
            if (currentAsteroidCount >= currentWave.maxAsteroidWave)
                yield return new WaitUntil(() => currentAsteroidCount < currentWave.maxAsteroidWave);

            float timeBetweenSpawn = Random.Range(currentWave.timeBetweenSpawn.min, currentWave.timeBetweenSpawn.max);

            yield return new WaitForSeconds(timeBetweenSpawn);

            Vector3 pos = MakeRandomTransform();
            Asteroid spawnedObj = Instantiate(asteroid, pos, Quaternion.identity);
            spawnedObj.spawner = this;
            spawnedObj.transform.forward = transform.forward;
            currentAsteroidCount ++;

            leftToSpawn--;
        }

        GM.endWave();
    
    }
    
    private Vector3 MakeRandomTransform()
    {
        Vector3 pos = _center + new Vector3(Random.Range(-_size.x / 2, _size.x / 2), Random.Range(-_size.y / 2, _size.y / 2), Random.Range(-_size.z / 2, _size.z / 2));

        return pos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube( transform.position, _size );
    }
}
