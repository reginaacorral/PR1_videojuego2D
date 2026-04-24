using UnityEngine;

public class Enemigo : MonoBehaviour
{
    GameObject personaje;

    //estados: patrulla
    string estado = "patrulla";

    public float distanciaPatrulla = 2.0f;
    public float velocidadPatrulla = 1f;
    bool dirPatrullaDcha = true;

    Vector3 posicionInicial;
    Vector3 posicionLimitDcha,
        posicionLimitIzq;

    //estados: ataque
    public float distanciaAtaque = 1.0f;
    public float velocidadAtaque = 1f;
    public float distanciaEvitar = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personaje = GameObject.FindWithTag("Player");
        posicionInicial = transform.position;
        posicionLimitIzq = new Vector3(
            posicionInicial.x - distanciaPatrulla,
            posicionInicial.y,
            posicionInicial.z
        );
        posicionLimitDcha = new Vector3(
            posicionInicial.x + distanciaPatrulla,
            posicionInicial.y,
            posicionInicial.z
        );
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, personaje.transform.position);

        //deteccion
        if (distancia <= distanciaAtaque)
        {
            estado = "ataque";
        }

        if (distancia >= distanciaEvitar)
        {
            estado = "patrulla";
        }

        //patrulla
        if (estado == "patrulla")
        {
            Debug.Log("posicionLimitDcha" + posicionLimitDcha);
            Debug.Log("posicionLimitDcha" + posicionLimitDcha);

            if (transform.position.x >= posicionLimitDcha.x)
            {
                dirPatrullaDcha = false;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (transform.position.x <= posicionLimitIzq.x)
            {
                dirPatrullaDcha = true;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (dirPatrullaDcha == true)
            {
                transform.Translate(velocidadPatrulla, 0, 0);
            }
            else
            {
                transform.Translate(velocidadPatrulla * -1, 0, 0);
            }
        }

        if (estado == "ataque")
        {
            transform.position = Vector3.MoveTowards(transform.position,personaje.transform.position,velocidadAtaque);

            if(AudioManager.Instance.GetComponent<AudioSource>().isPlaying == true)
            { }
            else
            {
               AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fantasmas);
            }

            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fantasmas);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("MUERTE");
            personaje.GetComponent<movpersonaje>().Muerte();
        }

        if (col.gameObject.name == "bala")
        {
            Debug.Log("Destruye");
            Destroy(this.gameObject, 0.5f);
            Destroy(col.gameObject, 0.5f);
        }
    }
}
