using UnityEngine;

public class movpersonaje : MonoBehaviour
{
    int miNumero = 1;

    float miNumeroFlotante = 0.8f;

    string miCadenaDeTexto = "Hola cadena de texto";

    bool miBoolean = true;
                                        
    bool estrella = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int sumaEntreDecenas = Sumar(10,20);
        Debug.Log("Inicio");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hola");
    }
    //esto es un comentario, * y barras es para encerrar comentario

int Sumar(int num1, int num2)
{

int suma = num1 + num2;

return suma;
}

}
