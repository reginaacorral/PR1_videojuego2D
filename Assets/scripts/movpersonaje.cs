using UnityEngine;
using UnityEngine.InputSystem;

public class movpersonaje : MonoBehaviour
{
    public float velocidad = 0.5f;

    Rigibody2D rb;

bool estoySaltando = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigibody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
    
        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();
        this.transform.Translate(moveInput.x*velocidad, 0, 0);
        
//flip

        if(moveInput.x > 0)
        {
        this.GetComponent<SpriteRenderer>().flipX = false;
    }
    


//salto
    bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();
    if(salto == true)
    {
Debug.Log("salto");
     rb.Addforce(transform.up,ForceMode2D.Impulse);
    
    }
    

}
}
