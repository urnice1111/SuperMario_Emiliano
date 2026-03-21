using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument menu;
    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCloseHelp;
    private VisualElement buttonContainer;
    private VisualElement helpPopup;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonJugar = root.Q<Button>("BtnJugar");
        botonAyuda = root.Q<Button>("BtnAyuda");
        botonCloseHelp = root.Q<Button>("BtnCloseHelp");
        buttonContainer = root.Q<VisualElement>("ButtonContainer");
        helpPopup = root.Q<VisualElement>("HelpPopup");

        botonJugar.RegisterCallback<ClickEvent>(AbrirJugar);
        botonAyuda.RegisterCallback<ClickEvent>(MostrarAyuda);
        botonCloseHelp.RegisterCallback<ClickEvent>(CerrarAyuda);
    }

    private void AbrirJugar(ClickEvent evt)
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void MostrarAyuda(ClickEvent evt)
    {
        buttonContainer.style.display = DisplayStyle.None;
        helpPopup.RemoveFromClassList("hidden");
    }

    private void CerrarAyuda(ClickEvent evt)
    {
        helpPopup.AddToClassList("hidden");
        buttonContainer.style.display = DisplayStyle.Flex;
    }
}
