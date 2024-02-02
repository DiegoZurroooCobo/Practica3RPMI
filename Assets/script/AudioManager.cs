using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<GameObject> audioList;
    private void Awake()
    {
        if(!instance) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        { 
            Destroy(gameObject);
        }
        audioList = new List<GameObject>();
    }
    private void Start()
    {
    }
    // Parametros por defecto 
    public AudioSource PlayAudio(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f) 
    {
        GameObject AudioObject = new GameObject(gameObjectName);    // Creamos un GameObject y le añadimos el nombre
        AudioObject.transform.SetParent(transform);
        AudioSource audioSourceComponent = AudioObject.AddComponent<AudioSource>(); // Se le añade el componente AudioSource
        audioSourceComponent.clip = audioClip; // Le asignamos el clip al componente 
        audioSourceComponent.volume = volume; // La variable del volumen
        audioSourceComponent.loop = isLoop;  // La variable del bucle                            
        audioSourceComponent.Play();
        audioList.Add(AudioObject); // añadimos el objecto a la lista para llevar un seguimiento 



        return audioSourceComponent;
    }

    public void ClearAudios() 
    { 
        foreach(GameObject AudioObject in audioList) 
        {
            Destroy(AudioObject);
        }

        audioList.Clear();
    }
}
