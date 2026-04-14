using UnityEngine;

public class GameManager : MonoBehaviour
{
public static int vidas = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Vidas: " + vidas);
    }
}
