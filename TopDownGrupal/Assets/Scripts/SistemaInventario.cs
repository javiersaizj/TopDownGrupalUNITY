using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaInventario : MonoBehaviour
{
    [SerializeField] private GameObject marcoInventario;
    [SerializeField] private Button[] botones;
    private int itemsDisponibles = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            int indice = i;
            botones[i].onClick.AddListener(() => BotonClickado(indice));
        }
    }

    private void BotonClickado(int indice)
    {
        Debug.Log("Boton click" + indice);
    }

    public void NuevoItem(ItemSO datos)
    {
        botones[itemsDisponibles].gameObject.SetActive(true);
        botones[itemsDisponibles].GetComponent<Image>().sprite = datos.icono;
        itemsDisponibles++;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            marcoInventario.SetActive(!marcoInventario.activeSelf);
        }
    }
}
