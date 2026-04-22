using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class movpersonaje : MonoBehaviour
{
    public float velocidad = 0.5f;
    public float impulsoSalto = 1.0f;

    public GameObject senyal;

    Rigidbody2D rb;

    Animator ControlAnimacion;

    bool puedoSaltar = false;
    GameObject respawn;
    public bool direccionBalaDerecha = true;

    public string direccionPersonaje = "quieto";

    bool estoyAzul = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        senyal = GameObject.Find("sign");
        ControlAnimacion = GetComponent<Animator>();
        respawn = GameObject.Find("Respawn");
        transform.position = respawn.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       // ControlAnimacion.SetBool("ActivaCaminar", true);

        //movimeinto
        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();
        this.transform.Translate(moveInput.x*velocidad, 0, 0);

//flip
    if(moveInput.x < 0)
        {
            direccionBalaDerecha = false;
        this.GetComponent<SpriteRenderer>().flipX = true;
        direccionPersonaje = "izq";
        }
    else if(moveInput.x > 0)
        {
        direccionBalaDerecha = true;
        this.GetComponent<SpriteRenderer>().flipX = false;
        direccionPersonaje = "izq";
        }
        
            
        

//animaciones
    if(moveInput.x != 0)
        {
        ControlAnimacion.SetBool("ActivaCaminar", true);
        }
    else
        {
        ControlAnimacion.SetBool("ActivaCaminar", false);
        }

//salto
    RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down*0.5f);
    Debug.DrawRay(transform.position,Vector2.down*0.5f, Color.red);

    if(hit.collider == true)
        {
        puedoSaltar = true;
        }
    else
        {
        puedoSaltar = false;
        }

//salto
        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();
    if(salto == true && puedoSaltar == true)
        {
        rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
        }
    }
 

    void OnTriggerEnter2D(Collider2D col)
        {
        //muerte

        if(col.gameObject.name == "dead")
        {
        Muerte();
        }

        //CHECKPOINT
        if(col.gameObject.name == "checkpoint")
        {
        respawn.transform.position = col.transform.position;
        }

        

    }
    public void Muerte()
    {
        GameManager.vidas -=1;
        transform.position = respawn.transform.position;
    }

    public void CambiaColor()
    { 
       if (estoyAzul)
        {
        this.GetComponent<SpriteRenderer>().color = Color.white;
        estoyAzul = false;
        }

        else
        {
        this.GetComponent<SpriteRenderer>().color = Color.blue;
        estoyAzul = true;
        }
       
    }
}

