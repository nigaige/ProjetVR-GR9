using UnityEngine;

public class RandomRotator : MonoBehaviour
{

    private float _rotationSpeed = 1f;

    [SerializeField]
    private float _minRotationSpeed = .2f;

    [SerializeField]
    private float _maxRotationSpeed = .8f;

    private Vector3 _randomQuaternion;

    private void Start()
    {
        _rotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
        _randomQuaternion = Random.rotation.eulerAngles;
    }

    void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime * _randomQuaternion, Space.Self);
    }
}
