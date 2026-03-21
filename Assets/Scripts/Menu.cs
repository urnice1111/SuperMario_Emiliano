using System.Xml.Serialization;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument menu;
    private Button botonJugar;

    private Button botonAyuda;


    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonJugar = root.Q<Button>("BtnJugar");
        botonAyuda = root.Q<Button>("BtnAyuda");


        botonJugar.RegisterCallback<ClickEvent>(AbrirJugar);
        botonAyuda.RegisterCallback<ClickEvent>(AbrirJugarMapa);
    }

    private void AbrirJugar(ClickEvent evt)
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void AbrirJugarMapa(ClickEvent evt)
    {
        SceneManager.LoadScene("EscenaMapa");   
    }
}
