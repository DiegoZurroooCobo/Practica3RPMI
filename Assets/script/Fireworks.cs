using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public float speed = 5;
    private Vector2 dir;
    private Rigidbody2D rb;
    private float currentTime = 0, MaxTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      Movement();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= MaxTime) 
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = dir * speed;
    }

    void Movement() 
    {
        dir.y = 1;
    }
}
