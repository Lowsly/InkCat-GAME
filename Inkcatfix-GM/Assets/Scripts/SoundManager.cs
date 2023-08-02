using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        // Aquí debes implementar la lógica para reproducir el sonido proporcionado como parámetro.
    }
}

