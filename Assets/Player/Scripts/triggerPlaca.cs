using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class triggerPlaca : MonoBehaviour
{

    private float timer;

    public static int countCorrectAns = 0;

    private static int countQuestions = 0;

    [SerializeField] private Animator placa;

    [SerializeField] private GameObject placaObjeto;

    [SerializeField] private GameObject otraPlaca1;
    
    [SerializeField] private GameObject otraPlaca2;

    [SerializeField] private GameObject otraPlaca3;

    [SerializeField] private GameObject puerta;

    [SerializeField] private TextMeshProUGUI TMPAnswer;

    [SerializeField] private TextMeshProUGUI Idusuario;

    [SerializeField] private string presionado = "botonPresionado"; 

    [SerializeField] private string normal = "botonIdle";

    private string textAnswer;

    private string subStringAnswer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                placa.Play(normal, 0, 0.0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        textAnswer = TMPAnswer.text;
        subStringAnswer = textAnswer.Substring(0, 1);
        if (collider2D.gameObject.CompareTag("Player"))
        {
            placa.Play(presionado, 0, 0.0f);
            if (placa.tag == subStringAnswer)
            {
                placaObjeto.SetActive(false);
                otraPlaca1.SetActive(false);
                otraPlaca2.SetActive(false);
                otraPlaca3.SetActive(false);
                countQuestions += 1;
                countCorrectAns += 1;
                Debug.Log(countCorrectAns);
                Debug.Log(countQuestions);
                if (countQuestions >= 20){
                    int answersTotal = countCorrectAns;
                    PlayerPrefs.SetInt("Score", answersTotal);
                    PlayerPrefs.SetInt("Idusuario", int.Parse(Idusuario.text));
                    SceneManager.LoadScene("ScoreBoard");
                    //TMPScore.text = countQuestions.ToString();
                }
                puerta.SetActive(true);

            } else {
                placaObjeto.SetActive(false);
                otraPlaca1.SetActive(false);
                otraPlaca2.SetActive(false);
                otraPlaca3.SetActive(false);
                countQuestions += 1;
                Debug.Log(countCorrectAns);
                Debug.Log(countQuestions);
                puerta.SetActive(true);
                if (countQuestions >= 20){
                    int answersTotal = countCorrectAns;
                    PlayerPrefs.SetInt("Score", answersTotal);
                    PlayerPrefs.SetInt("Idusuario", int.Parse(Idusuario.text));
                    SceneManager.LoadScene("ScoreBoard");
                }
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            timer = 1f;
        }
    }
}
