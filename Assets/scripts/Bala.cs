using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{
    GameObject personaje;
    public GameObject disparo;

    bool direccionpersonaje;

    public float velocidadBala = 0.5f;

    float heNacido;

    public float tiempoHastaDestruccion = 5.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personaje = GameObject.Find("personaje");
        direccionpersonaje = personaje.GetComponent<movpersonaje>().direccionBalaDerecha;
        heNacido = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);

    if (direccionpersonaje)
        {
        disparo.transform.Translate(velocidadBala*Time.deltaTime,0,0);
        transform.Rotate(0,0,0.5f);
        } 
    else
        {
        disparo.transform.Translate(velocidadBala*-1,0,0);
        transform.Rotate(0,0,-0.5f);
        }

        // destruccion por tiempo
    if (Time.time >= heNacido + tiempoHastaDestruccion)
        {
        Destroy(disparo);
        }

    }
}
