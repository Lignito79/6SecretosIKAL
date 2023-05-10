using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Net.Http;
using TMPro;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
 
public class APIController : MonoBehaviour
{

    InputField questionText;
    TextMeshProUGUI answer1Text;
    TextMeshProUGUI answer2Text;
    TextMeshProUGUI answer3Text;
    TextMeshProUGUI answer4Text;
    TextMeshProUGUI answerCorrectText;
    TextMeshProUGUI idusuarioText;
    string preguntasJson;

    void Start()
    {
        questionText = GameObject.Find("QuestionText").GetComponent<InputField>();
        answer1Text = GameObject.Find("Respuesta1").GetComponent<TextMeshProUGUI>();
        answer2Text = GameObject.Find("Respuesta2").GetComponent<TextMeshProUGUI>();
        answer3Text = GameObject.Find("Respuesta3").GetComponent<TextMeshProUGUI>();
        answer4Text = GameObject.Find("Respuesta4").GetComponent<TextMeshProUGUI>();
        answerCorrectText = GameObject.Find("RespuestaCorrecta").GetComponent<TextMeshProUGUI>();
        idusuarioText = GameObject.Find("Idusuario").GetComponent<TextMeshProUGUI>();
        GetData();
        //GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    }

    void GetData() => StartCoroutine(GetData_Coroutine());

    // Originalmente era un Get
    IEnumerator GetData_Coroutine(){
        UnityWebRequest request;
        int rInt = Random.Range(0, 19);
        questionText.text = "Loading...";
        string url = "https://localhost:44344/api/apiquestion";
        using (request = UnityWebRequest.Get(url)){
            yield return request.SendWebRequest();
            if(request.isNetworkError || request.isHttpError){
                questionText.text = request.error;
            } else{
                preguntasJson = request.downloadHandler.text;
                var preguntasParse = JToken.Parse(preguntasJson);
                var IDPregunta = preguntasParse[rInt]["idPregunta"].ToString();
                var IDPuesto = preguntasParse[rInt]["idPuesto"].ToString();
                var pregunta = preguntasParse[rInt]["pregunta"].ToString();
                var respuestaCorrecta = preguntasParse[rInt]["respuesta_correcta"].ToString();
                var respuesta1 = preguntasParse[rInt]["respuesta1"].ToString();
                var respuesta2 = preguntasParse[rInt]["respuesta2"].ToString();
                var respuesta3 = preguntasParse[rInt]["respuesta3"].ToString();
                var respuesta4 = preguntasParse[rInt]["respuesta4"].ToString();
                var idusuarioGET = preguntasParse[rInt]["idusuarioGET"].ToString();

                questionText.text = pregunta;
                answerCorrectText.text = respuestaCorrecta;
                answer1Text.text = respuesta1;
                answer2Text.text = respuesta2;
                answer3Text.text = respuesta3;
                answer4Text.text = respuesta4;
                idusuarioText.text = idusuarioGET;
            }
        }

    }


}