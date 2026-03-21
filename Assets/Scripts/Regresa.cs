using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Regresa : MonoBehaviour
{
    private UIDocument menu;
    private Button botonRegresar;
    

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonRegresar = root.Q<Button>("BotonRegresar");

        botonRegresar.clicked += CerrarEscena;
    }

    void CerrarEscena()
    {
        SceneManager.LoadScene("Menu");
    }

    void OnDisable()
    {
        botonRegresar.clicked -= CerrarEscena;
    }
}
