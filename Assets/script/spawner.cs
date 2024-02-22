using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject objtToSpawn;
    private float currentTime = 0, MaxTime;
    // Start is called before the first frame update
    void Start()
    {
        MaxTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= MaxTime) 
        { 
            Instantiate(objtToSpawn, new Vector2(Random.Range(-17f, 1.8f), transform.position.y), Quaternion.identity);
            currentTime = 0;
            MaxTime = 3;
        }
    }
}
