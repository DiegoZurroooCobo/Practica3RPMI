using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera _camera;
    public Transform FollowObject;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(FollowObject.position.x, transform.position.y, transform.position.z);
        transform.position = position;
    }
}
