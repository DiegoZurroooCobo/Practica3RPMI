using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fades : MonoBehaviour
{
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeOut() 
    { 
        Color color = rend.color; // Para guardar el color actual del objecto
        for(float alpha = 1.0f; alpha >=0; alpha -= 0.01f)  // En cada vuelta de este bucle, el alpha va bajando
        { 
            color.a = alpha;
            rend.color = color;
            yield return new WaitForSeconds(0.02f); // le devuelve el control a unity durante el tiempo establecido
        }
    }
    
    IEnumerator FadeIn() 
    { 
        Color color = rend.color;
        for(float alpha = 0.0f; alpha >=0; alpha += 0.01f) 
        {
            color.a = 1;
            rend.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
