using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField]
    private Vector3 _center;

    [SerializeField]
    private Vector3 _size;


    // Start is called before the first frame update
    void Start()
    {
        _center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube( transform.position, _size );
    }
}
