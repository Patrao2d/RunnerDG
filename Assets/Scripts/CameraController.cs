using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _offsetX;
    private float _offsetY;
    private float _offsetZ;
    public float yMin;
    public float yMax;
    public float smoothSpeed;
    public GameObject target;
    private Vector3 _position;
    private Transform _thisCamera;

    private void Awake()
    {
        _thisCamera = GetComponent<Transform>();
    }

    private void Start()
    {
        _offsetX = _thisCamera.position.x;
        _offsetY = _thisCamera.position.y;
        _offsetZ = _thisCamera.position.z;
    }


    private void LateUpdate()
    {
        float __interpolation = smoothSpeed * Time.fixedDeltaTime;
        //
        _position.x = Mathf.Lerp(transform.position.x, target.transform.position.x, __interpolation);
        //_position.y = Mathf.Lerp(transform.position.y, (target.transform.position.y + _offsetY), __interpolation);
        _position.y = Mathf.Clamp(Mathf.Lerp(transform.position.y, (target.transform.position.y + _offsetY), __interpolation),yMin,yMax);
        _position.z = _offsetZ;

        transform.position = _position;
    }
}
