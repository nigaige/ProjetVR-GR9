using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeShape : MonoBehaviour
{


    [SerializeField]
    private List<Mesh> _asteroidMeshes = new();

    [SerializeField]
    private List<Material> _asteroidMaterials = new();

    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;


    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();

        
    }

    // Start is called before the first frame update
    void Start()
    {
        SetRandomMesh();
        SetRandomMaterial();

    }


    private void SetRandomMesh()
    {
        int random = Random.Range(0, _asteroidMeshes.Count - 1);
        _meshFilter.mesh = _asteroidMeshes[random];

    }

    private void SetRandomMaterial()
    {
        int random = Random.Range(0, _asteroidMaterials.Count - 1);
        _meshRenderer.material = _asteroidMaterials[random];
    }



}
