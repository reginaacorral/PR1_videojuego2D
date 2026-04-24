using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip clipBotones;
    public AudioClip bandaSonora;
    public AudioClip monedas;
    public AudioClip muerte;
    public AudioClip fantasmas;
    public AudioClip fuego;
    public AudioSource _audioSource;

    void Awake()
    {
        if( Instance != null && Instance != this)
        {
            Destroy(this.gameObject); return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<AudioSource>().clip = bandaSonora;
        GetComponent<AudioSource>().Play();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() { }

    public void SonarBoton()
    {
        //GetComponent<AudioSource>().PlayOneShot(clipBotones);
        SonarClipUnaVez(clipBotones);
    }

    public void SonarClipUnaVez(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

}
