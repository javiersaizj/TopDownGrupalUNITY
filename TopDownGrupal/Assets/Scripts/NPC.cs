using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{

    [SerializeField, TextArea(1,5)] private string[] frases;
    [SerializeField] private float tiempoEntreLetras;
    [SerializeField] private GameObject cuadroDialogo;
    [SerializeField] private TextMeshProUGUI textoDialogo;
    private bool hablando = false;
    private int indiceActual = -1;

    void Start()
    {
        
    }

    public void Interactuar()
    {
        cuadroDialogo.SetActive(true);
        if (!hablando)
        {
            SiguienteFrase();
        }
        else
        {
            CompletarFrase();
        }
        
    }

    private void SiguienteFrase()
    {
        AudioManager.Instance.PlaySFX(5);

        indiceActual++;
        if (indiceActual >= frases.Length)
        {
            TerminarDialogo();
        }
        else
        {
            StartCoroutine(EscribirFrase());
        }
    }

    private void TerminarDialogo()
    {
        hablando = false;
        cuadroDialogo.SetActive(false);
        textoDialogo.text = "";
        indiceActual = -1;
    }

    IEnumerator EscribirFrase()
    {
        hablando = true;
        textoDialogo.text = "";

        char[] caracteresFrase = frases[indiceActual].ToCharArray(); //Subdivide la frase actual en caracteres

        foreach (char c in caracteresFrase)
        {
            textoDialogo.text += c;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }
        hablando = false;

    }

    private void CompletarFrase()
    {
        StopAllCoroutines();
        textoDialogo.text = frases[indiceActual];
        hablando = false;
    }

}
