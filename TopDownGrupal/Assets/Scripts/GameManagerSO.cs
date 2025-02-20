using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scriptable Objects/GameManager")]
public class GameManagerSO : ScriptableObject
{
    private SistemaInventario inventario;

    /** Cantidad de monedas que tiene el jugador. */
    [SerializeField] private int playerCoins;

    public SistemaInventario Inventario { get => inventario; }
    public int PlayerCoins { get => playerCoins; }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += NuevaEscenaCargada;
    }

    private void NuevaEscenaCargada(Scene arg0, LoadSceneMode arg1)
    {
        inventario = FindObjectOfType<SistemaInventario>();
    }

    public bool CanBuy(int amount)
    {
        return playerCoins >= amount;
    }

    public void AddCoins(int amount)
    {
        playerCoins += amount;
    }

    public void RemoveCoins(int amount)
    {
        playerCoins -= amount;
    }
}
