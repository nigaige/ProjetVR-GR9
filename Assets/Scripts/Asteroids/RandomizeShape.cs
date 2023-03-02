using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeShape : MonoBehaviour
{


    [SerializeField]
    private List<Mesh> _asteroidMeshes = new();

    [SerializeField]
    private List<Material> _asteroidMaterials = new();

    private Mesh _currentMesh;
    private Material _currentMaterial;


    private void Awake()
    {
        _currentMesh = GetComponent<MeshFilter>().mesh;
        _currentMaterial = GetComponent<MeshRenderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetRandomMesh();
        SetRandomMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetRandomMesh()
    {
        int random = Random.Range(0, _asteroidMeshes.Count - 1);
        _currentMesh = _asteroidMeshes[random];
    }

    private void SetRandomMaterial()
    {
        int random = Random.Range(0, _asteroidMaterials.Count - 1);
        _currentMaterial = _asteroidMaterials[random];
    }



}
