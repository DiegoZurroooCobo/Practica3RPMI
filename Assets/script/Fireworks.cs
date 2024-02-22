using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public float speed = 5;
    public GameObject FireworksPrefab;
    private Vector2 dir;
    private Rigidbody2D rb;
    private float currentTime = 0, MaxTime = 3f;
    int index;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      Movement();
    }
    void Movement() 
    {
        dir.y = 1;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= MaxTime) 
        {
            Destroy(gameObject);
        }

        if(transform.position.y >= 0) 
        {
            Destroy(gameObject);
            if(index < 4) 
            {
                int Fireworks2 = Random.Range(0, 4);
                index++;
                for( Fireworks2 = 0; Fireworks2 < 3; Fireworks2++) 
                {
                    GameObject FireWorks = Instantiate(FireworksPrefab, transform.position, Quaternion.identity);
                    FireWorks.transform.localScale /= 2;
                    dir.x = (Random.Range(-1, 2));
                    do
                    {
                        dir.y = Random.Range(-1, 2);
                    } while (dir.y == 0);
                    FireWorks.GetComponent<Fireworks>().index = index;
                }
            }
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = dir * speed;
    }

}
