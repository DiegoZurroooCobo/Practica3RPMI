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
            instance = this;    // Convierte este AudioManager en el principal si no hay mas AM
            DontDestroyOnLoad(gameObject);
        }
        else // Si si hay mas AM, se destruye 
        { 
            Destroy(gameObject);
        }
        audioList = new List<GameObject>();
    }
    private void Start()
    {
    }
    // Parametros por defecto 
    public AudioSource PlayAudio(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f)  // Crea el clip de audio para la musica o los efectos de sonido
    {
        GameObject AudioObject = new GameObject(gameObjectName);    // Creamos un GameObject y le añadimos el nombre
        AudioObject.transform.SetParent(transform);
        AudioSource audioSourceComponent = AudioObject.AddComponent<AudioSource>(); // Se le añade el componente AudioSource
        audioSourceComponent.clip = audioClip; // Le asignamos el clip al componente 
        audioSourceComponent.volume = volume; // La variable del volumen
        audioSourceComponent.loop = isLoop;  // La variable del bucle                            
        audioSourceComponent.Play();
        audioList.Add(AudioObject); // añadimos el objecto a la lista para llevar un seguimiento 
        if(!isLoop) // Si el audio no esta en loop, espero a que acabe para destruirlo
        {
            StartCoroutine(WaitAudioEnd(audioSourceComponent)); 
        }
        return audioSourceComponent;
    }

    public AudioSource PlayAudio3D(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f) // Creal el AudioClip en 3D
    {
        AudioSource audioSource = PlayAudio(audioClip, gameObjectName, false, volume);
        audioSource.spatialBlend = 1.0f;

        return audioSource;
    }

    public void ClearAudios() // Limpia los audios al cambiar de escena o reiniciarla 
    { 
        foreach(GameObject AudioObject in audioList) 
        {
            Destroy(AudioObject);
        }
        audioList.Clear();
        StopAllCoroutines(); // Detiene todas las corutinas en el monento
    }
     
    IEnumerator WaitAudioEnd(AudioSource src) // Corutina = No pausan la ejecucion del programa entre los bucles. Hilos y procesos que no hay en Unity 
    { 
        while(src && src.isPlaying) 
        { 
            yield return null; // Al llegar a yield, se corta la ejecucion del metodo y le devuelve al codigo a Unity. En los siguintes frames, se vuelve ejecutar el codigo.
        }
        Destroy(src.gameObject);
    }
}
