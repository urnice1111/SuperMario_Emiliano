using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ConfirmUser : MonoBehaviour
{
    public class LoginData
    {
        public string email;
        public string password;

        public string deviceType;
    }
    
    [System.Serializable]
    public class LoginResponse
    {
        public SignInResult result;
    }

    [System.Serializable]
    public class SignInResult
    {
        public bool ok;
        public UserInfo user;
    }

    [System.Serializable]
    public class UserInfo{
        public int id_cuenta;
        public string correo;
        
    }

    private TextField emailEntry;
    private TextField passwordEntry;
    private Label resultMessage;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        emailEntry = root.Q<TextField>("EmailEntry");
        passwordEntry = root.Q<TextField>("PasswordEntry");
        resultMessage = root.Q<Label>("Response");

        Button loginButton = root.Q<Button>("LogInButton");
        loginButton.clicked += ConfirmCredentials;
    }

    private void ConfirmCredentials()
    {
        string email = emailEntry.value;
        string password = passwordEntry.value;
        string type = SystemInfo.deviceType.ToString();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ShowMessage("Please enter both email and password.", Color.red);
            return;
        }

        StartCoroutine(PostRequestLogin(email, password, type));
    }

    IEnumerator PostRequestLogin(string email, string password, string deviceType)
    {
        LoginData loginData = new LoginData
        {
            email = email,
            password = password,
            deviceType = deviceType
        };

        string jsonBody = JsonUtility.ToJson(loginData);

        using UnityWebRequest www = UnityWebRequest.Post("https://udqzin2siulhcshfje2amhkiey0pkadb.lambda-url.us-east-1.on.aws/login", jsonBody, "application/json");


        yield return www.SendWebRequest();

        if (www.responseCode == 201)
        {

            Debug.Log("Response text: " + www.downloadHandler.text);
            LoginResponse response = JsonUtility.FromJson<LoginResponse>(www.downloadHandler.text);


            Debug.Log(www.responseCode);
            ShowMessage("Login successful! Loading game...", Color.green);
            SceneManager.LoadScene("Menu");
            // StartCoroutine(RegisterSessionInDB(response.user.id));
        }
        else if (www.responseCode == 401 || www.responseCode == 403)
        {
            ShowMessage("Email or password is incorrect.", Color.red);
        }
        else
        {
            Debug.LogWarning("Unexpected login response: " + www.responseCode + " - " + www.downloadHandler.text);
            ShowMessage("Login failed. Please try again.", Color.red);
        }
    }
    
    private void ShowMessage(string text, Color color)
    {
        if (resultMessage != null)
        {
            resultMessage.text = text;
            resultMessage.style.color = color;
            resultMessage.style.opacity = 1;
        }
    }
}
