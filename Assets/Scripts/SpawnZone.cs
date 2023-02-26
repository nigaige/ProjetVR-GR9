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

    /// <summary>
    /// Spawn Time
    /// </summary>
    [SerializeField]
    private float _minSpawnTime;
    [SerializeField]
    private float _maxSpawnTime;


    private List<GameObject> spawnedObjectsList = new();

    private UnityEvent _spawnEvent;



    // Start is called before the first frame update
    private void Start()
    {

        if (_spawnEvent == null)
            _spawnEvent = new UnityEvent();

        


        _center = transform.position;

        StartCoroutine(SpawnAsteroid());
    }

    private void Update()
    {
        
    }


    public IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            print("Spawn Coroutine");
            if (spawnedObjectsList.Count == _maxAsteroidInZone)
                yield return new WaitUntil(() => spawnedObjectsList.Count < _maxAsteroidInZone / 2);

            float timeBetweenSpawn = Random.Range(_minSpawnTime, _maxSpawnTime);

            print("time between spawn : " + timeBetweenSpawn);

            yield return new WaitForSeconds(timeBetweenSpawn);

            Vector3 pos = MakeRandomTransform();
            GameObject spawnedObj = Instantiate(_objToSpawn, pos, Quaternion.identity);
            spawnedObjectsList.Add(spawnedObj);

            print("Objects spawned : " + spawnedObjectsList.Count);


        }
         
    
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
