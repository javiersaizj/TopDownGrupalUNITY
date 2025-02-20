using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * ShopSystem maneja la interfaz de la tienda y las compras del jugador.
 */
public class Shop : MonoBehaviour
{
    /** Texto UI que muestra la cantidad de monedas del jugador. */
    [SerializeField] private TextMeshProUGUI coinText;
    /** Lista de objetos disponibles en la tienda. */
    [SerializeField] private List<ItemSO> shopItems = new List<ItemSO>();
    /** Interfaz de usuario de la tienda. */
    [SerializeField] private GameObject shopUI;
    /** Botones que representan los items en la tienda. */
    [SerializeField] private Button[] botones;
    /** Interfaz de usuario del inventario**/
    [SerializeField] private SistemaInventario inventario;
    [SerializeField] private GameManagerSO gameManager;

    /** Inicializa la tienda, ocultándola y cargando los productos. */
    private void Start()
    {
        shopUI.SetActive(false);
        UpdateCoinText();
        PopulateShop();
    }

    /** Actualiza el texto de la cantidad de monedas. */
    void UpdateCoinText()
    {
        coinText.text = "Coins: " + gameManager.PlayerCoins;
    }

    /** Llena la tienda con los objetos disponibles. */
    void PopulateShop()
    {
        for (int i = 0; i < botones.Length && i < shopItems.Count; i++)
        {
            int indice = i;
            botones[i].gameObject.SetActive(true);
            botones[i].GetComponent<Image>().sprite = shopItems[i].icono;
            botones[i].GetComponentInChildren<TextMeshProUGUI>().text = "$" + shopItems[i].precio;
            botones[i].onClick.AddListener(() => PurchaseItem(shopItems[indice]));
        }
    }

    /**
     * Permite al jugador comprar un objeto si tiene suficientes monedas.
     * @param item El objeto a comprar.
     */
    public void PurchaseItem(ItemSO item)
    {
        if (gameManager.CanBuy(item.precio))
        {
            AudioManager.Instance.PlaySFX(4);

            gameManager.RemoveCoins(item.precio);
            UpdateCoinText();
            Debug.Log("Purchased: " + item.name);
            inventario.NuevoItem(item);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    /** Abre la tienda cuando el jugador interactúa con ella. */
    public void Interactuar()
    {
        shopUI.SetActive(true);
        UpdateCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopUI.SetActive(false);
        }
    }
}