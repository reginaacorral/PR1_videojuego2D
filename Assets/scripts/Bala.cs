using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{
    GameObject personaje;
    public GameObject disparo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personaje = GameObject.Find("personaje");
    }

    // Update is called once per frame
    void Update()
    {
transform.Rotate(0,0,0.5f);

bool direccionPersonaje = personaje.GetComponent<movpersonaje>().direccionBalaDerecha;
if (direccionPersonaje)
{
    disparo.transform.Translate(0.01f,0,0);
   } 
else
{
disparo.transform.Translate(0.01f,0,0);
}

    }
}
