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
    private GameObject _objToSpawn;



    private Wave currentWave;
    private int leftToSpawn = 0;


    private List<GameObject> spawnedObjectsList = new();

    private UnityEvent _spawnEvent;



    // Start is called before the first frame update
    private void Start()
    {

        if (_spawnEvent == null)
            _spawnEvent = new UnityEvent();

        


        _center = transform.position;

    }

    private void Update()
    {
        Debug.Log(spawnedObjectsList.Count);
    }

    public void startNewWave(Wave waveData){
        StopCoroutine(SpawnAsteroid());
        currentWave = waveData;
        leftToSpawn = waveData.asteroidCount;
        StartCoroutine(SpawnAsteroid());
    }




    public IEnumerator SpawnAsteroid()
    {
        while (leftToSpawn > 0)
        {
            print("Spawn Coroutine");
            if (spawnedObjectsList.Count >= currentWave.maxAsteroidWave)
                yield return new WaitUntil(() => spawnedObjectsList.Count < currentWave.maxAsteroidWave);

            float timeBetweenSpawn = Random.Range(currentWave.timeBetweenSpawn.min, currentWave.timeBetweenSpawn.max);

            print("time between spawn : " + timeBetweenSpawn);

            yield return new WaitForSeconds(timeBetweenSpawn);

            Vector3 pos = MakeRandomTransform();
            GameObject spawnedObj = Instantiate(_objToSpawn, pos, Quaternion.identity);
            spawnedObjectsList.Add(spawnedObj);

            print("Objects spawned : " + spawnedObjectsList.Count);
            leftToSpawn--;


        }

        //TODO EMIT****************************************************************************************************************************************************************
         
    
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
