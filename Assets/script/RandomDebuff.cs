using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDebuff : MonoBehaviour
{
    private float initialspeed = 3, speed,  currentTime = 0f, MaxTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        initialspeed = speed;
        speed *= Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= MaxTime) 
        { 
            currentTime = 0f;
            speed = initialspeed;
            Destroy(this);
        }
    }
}
