using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument menu;
    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCreditos;
    private Button botonCloseHelp;
    private Button botonCloseCredits;
    private VisualElement buttonContainer;
    private VisualElement helpPopup;
    private VisualElement creditsPopup;
    private ScrollView creditsScroll;

    private bool creditsScrolling = false;
    [SerializeField] private float scrollSpeed = 50f;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonJugar = root.Q<Button>("BtnJugar");
        botonAyuda = root.Q<Button>("BtnAyuda");
        botonCreditos = root.Q<Button>("BtnCreditos");
        botonCloseHelp = root.Q<Button>("BtnCloseHelp");
        botonCloseCredits = root.Q<Button>("BtnCloseCredits");
        buttonContainer = root.Q<VisualElement>("ButtonContainer");
        helpPopup = root.Q<VisualElement>("HelpPopup");
        creditsPopup = root.Q<VisualElement>("CreditsPopup");
        creditsScroll = root.Q<ScrollView>("CreditsScroll");

        botonJugar.RegisterCallback<ClickEvent>(AbrirJugar);
        botonAyuda.RegisterCallback<ClickEvent>(MostrarAyuda);
        botonCloseHelp.RegisterCallback<ClickEvent>(CerrarAyuda);
        botonCreditos.RegisterCallback<ClickEvent>(MostrarCreditos);
        botonCloseCredits.RegisterCallback<ClickEvent>(CerrarCreditos);
    }

    void Update()
    {
        if (!creditsScrolling) return;

        creditsScroll.scrollOffset += new Vector2(0, scrollSpeed * Time.deltaTime);
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

    private void MostrarCreditos(ClickEvent evt)
    {
        buttonContainer.style.display = DisplayStyle.None;
        creditsPopup.RemoveFromClassList("hidden");
        creditsScroll.scrollOffset = Vector2.zero;
        creditsScrolling = true;
    }

    private void CerrarCreditos(ClickEvent evt)
    {
        creditsScrolling = false;
        creditsPopup.AddToClassList("hidden");
        buttonContainer.style.display = DisplayStyle.Flex;
    }
}
