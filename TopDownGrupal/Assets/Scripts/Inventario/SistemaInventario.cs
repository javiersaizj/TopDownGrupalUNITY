using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class SistemaInventario : MonoBehaviour
{
    [SerializeField] private GameObject marcoInventario;
    [SerializeField] private Button[] botones;
    private int itemsCollected = 0;

    private List<ItemSO> items = new List<ItemSO>();
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
        
    }

    public void NuevoItem(ItemSO datos)
    {
        items.Add(datos);
        botones[itemsCollected].gameObject.SetActive(true);
        botones[itemsCollected].GetComponent<Image>().sprite = datos.icono;
        itemsCollected++;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (!marcoInventario.activeSelf)
                AudioManager.Instance.PlaySFX(0);
            else
                AudioManager.Instance.PlaySFX(1);

            marcoInventario.SetActive(!marcoInventario.activeSelf);
        }
    }
}
