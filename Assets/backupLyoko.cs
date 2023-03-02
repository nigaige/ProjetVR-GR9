using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backupLyoko : MonoBehaviour
{
    [SerializeField]
    private Transform _deathZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){

        
        Debug.Log("Lyoko");
        other.gameObject.transform.position = _deathZone.position;
        Destroy(gameObject);


    }
}
