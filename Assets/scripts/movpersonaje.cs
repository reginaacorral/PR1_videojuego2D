using UnityEngine;
using UnityEngine.InputSystem;

public class movpersonaje : MonoBehaviour
{
    public float velocidad = 0.5f;
    public float impulsoSalto = 1.0f;

    Rigidbody2D rb;

bool puedoSaltar = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();
        this.transform.Translate(moveInput.x*velocidad, 0, 0);

//flip
        if(moveInput.x < 0)
        {
        this.GetComponent<SpriteRenderer>().flipX = true;
    }else if(moveInput.x > 0)
{
    this.GetComponent<SpriteRenderer>().flipX = false;
    }


RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down*0.5f);
Debug.DrawRay(transform.position,Vector2.down*0.5f, Color.red);

if(hit.collider == true)
    {
puedoSaltar = true;
this.GetComponent<SpriteRenderer>().color = Color.red;
transform.localScale = new Vector3(1,1,1);
    }
else
    {
puedoSaltar = false;
this.GetComponent<SpriteRenderer>().color = Color.white;
transform.localScale = new Vector3(2,2,1);
     }


//salto
    bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();
    if(salto == true && puedoSaltar == true)
    {
     rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
    }
    

}
}
