using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public float speed = 5;
    public GameObject FireworksPrefab;
    public Color[] Colors = new Color[4];

    private Vector2 dir;
    private Rigidbody2D rb;
    private float currentTime = 0, MaxTime = 3f, MaxTime2;
    private int index = 0;
    private int index2 = 0;
    //int _index = 0;
    private SpriteRenderer render;
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

        if (transform.position.y >= 0)
        {
            if (index < 4)
            {
                int Fireworks2 = Random.Range(0, 3);
                index++;
                for (Fireworks2 = 0; Fireworks2 < 2; Fireworks2++)
                {
                    GameObject FireWorks = Instantiate(FireworksPrefab, transform.position, Quaternion.identity);
                    FireWorks.transform.localScale /= 2;
                    speed *= 0.9f;
                    FireWorks.GetComponent<Fireworks>().index = index;

                    MaxTime2 = 1f;
                    if (currentTime >= MaxTime2)
                    {
                        Destroy(FireworksPrefab.gameObject);
                        currentTime = 0;
                    }
                    dir.x = Random.Range(-1, 2);
                    dir.y = Random.Range(-1, 2);

                    Random.Range(Colors.Length, Colors.Length);
                    render.color = Colors[index2];
                    index2++;
                    if (index2 > Colors.Length)
                    {
                        index2 = 0;
                    }

                    Color color = render.color; // Para guardar el color actual del objecto
                    for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)  // En cada vuelta de este bucle, el alpha va bajando
                    {
                        color.a = alpha;
                        render.color = color;
                    }
                } 
            }
        }      
    }

    
    private void FixedUpdate()
    {
        rb.velocity = dir * speed;
    }

}
