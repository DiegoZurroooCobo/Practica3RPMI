using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //private Camera _camera;
    public Transform FollowObject; //El objeto al que sigue la camara 
    public Vector2 FollowOffset;
    //public float FollowSpeed;
    private Vector2 Threshold;
    void Start()
    {
        Threshold = CalculateThreshold();
        //_camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(FollowObject.position.x, transform.position.y, transform.position.z);   
        //Solamente sigue la posicion del personaje en el eje X
        transform.position = position;
    }
    private Vector3 CalculateThreshold() 
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width/ aspect.height, Camera.main.orthographicSize);
        t.y -= FollowOffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 border = CalculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }

    private void FixedUpdate()
    {
        Vector2 follow = FollowObject.transform.position;
        float YDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position; // 
        if(Mathf.Abs(YDifference) >= Threshold.y) 
        { 
            newPosition.y = follow.y;
        }
        transform.position = newPosition;
        //transform.position = Vector3.MoveTowards(transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }
}
