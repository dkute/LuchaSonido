using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ayuda
public class Audio : MonoBehaviour
{
    public static Audio instance; // Una instancia estática de la clase Audio para permitir el acceso desde otros scripts

    public Slider volumeSlider;// Referencia al control deslizante de volumen en la interfaz de usuario
    public Toggle muteToggle;// Referencia al interruptor de silencio en la interfaz de usuario

    private AudioSource audioSource;// Referencia a la fuente de audio que se controlará
    private float defaultVolume = 0.5f;// Volumen predeterminado al inicio
    private bool isMuted = false;// Estado de silencio al inicio
    // Claves para guardar y cargar ajustes de volumen y silencio
    private string volumeKey = "Volume";
    private string muteKey = "Muted";

    void Awake()
    {
        // Si no existe una instancia de Audio, esta se convierte en la instancia
        if (instance == null)
        {
            instance = this;
            // No destruir este objeto al cargar una nueva escena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruir este objeto
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();// Obtener la referencia a la fuente de audio


        if (PlayerPrefs.HasKey(volumeKey))// Cargar los ajustes guardados
        {
            float savedVolume = PlayerPrefs.GetFloat(volumeKey);
            volumeSlider.value = savedVolume;
            audioSource.volume = savedVolume;
        }
        else
        {
            //si no hay ajustes guardados, usa el valor predeterminado
            volumeSlider.value = defaultVolume;
            audioSource.volume = defaultVolume;
        }
        //si hay ajustes de silencio guardados, cargalos
        if (PlayerPrefs.HasKey(muteKey))
        {
            isMuted = PlayerPrefs.GetInt(muteKey) == 1;
            muteToggle.isOn = isMuted;
            audioSource.mute = isMuted;
        }
    }

    public void SetVolume(float volume)//Metodo para ajustar y guardar el ajuste
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(volumeKey, volume);
    }

    public void ToggleMute(bool isMuted) //Metodo para alternar el silencio y guardar el ajuste
    {
        audioSource.mute = isMuted;
        PlayerPrefs.SetInt(muteKey, isMuted ? 1 : 0);
    }
}