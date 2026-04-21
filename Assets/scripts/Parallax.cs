using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocidadParallax = 1.0f;
    public GameObject personaje;
    public GameObject Camara;

    void Start()
    {
        Camara = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //CONTROL ELEMENTOS DEL FONDO (LEJANOS,CERCANOS)
        float posicionX =Camara.transform.position.x + transform.position.x;
        float posicionY =Camara.transform.position.x + transform.position.x;
        transform.position = new Vector3(Camara.transform.position.x*velocidadParallax, Camara.transform.position.y*velocidadParallax, -5f);
    }
}
