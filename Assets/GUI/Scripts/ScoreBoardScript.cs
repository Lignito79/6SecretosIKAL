using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Net.Http;

using TMPro;

 public class ScoreBoardScript : MonoBehaviour
 {
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        PostAndDisplay();
    }

    void PostAndDisplay() => StartCoroutine(PostAndDisplay_Coroutine());
 
    IEnumerator PostAndDisplay_Coroutine()
    {
        //Display
        string scoreString = PlayerPrefs.GetInt("Score").ToString();
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        string Idusuario = PlayerPrefs.GetInt("Idusuario").ToString();

        string url = "https://localhost:44344/api/apiscore";
        WWWForm form = new WWWForm();

        form.AddField("puntuacion", scoreString);
        form.AddField("idusuario", Idusuario);

        using (UnityWebRequest request = UnityWebRequest.Post(url,form)){
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError){
                scoreText.text = request.error;
            } else {
                scoreText.text = PlayerPrefs.GetInt("Score").ToString();
            }
        }
    }
 }