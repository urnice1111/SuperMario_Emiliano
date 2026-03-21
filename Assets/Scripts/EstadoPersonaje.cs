using UnityEngine;

public class EstadoPersonaje : MonoBehaviour
{
    public bool estaEnSuelo {get; private set;} = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        estaEnSuelo = true;
        print(estaEnSuelo);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        estaEnSuelo = false;
        print(estaEnSuelo);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
