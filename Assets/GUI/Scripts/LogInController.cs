using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
using System.Net.Http;
using TMPro;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class LogInController : MonoBehaviour
{
    [SerializeField] TMP_InputField CorreoInput;
    [SerializeField] TMP_InputField ContrasenaInput;
    [SerializeField] TextMeshProUGUI responseText;
    [SerializeField] Button buttonLogIn;

    public void OnButtonClicked() => StartCoroutine(PostLog_Coroutine());

    // Update is called once per frame
    IEnumerator PostLog_Coroutine()
    {

        UnityWebRequest request;
        string url = "https://localhost:44344/api/apiquestion";
        WWWForm form = new WWWForm();
        form.AddField("correo", CorreoInput.text);
        form.AddField("contrasena", ContrasenaInput.text);

        using (request = UnityWebRequest.Post(url, form)){
            yield return request.SendWebRequest();
            if(request.isNetworkError || request.isHttpError){
                responseText.text = request.error;
            } else{
                responseText.text = "Success";
                SceneManager.LoadScene("Menu");
            }
        }
    }


    
}
