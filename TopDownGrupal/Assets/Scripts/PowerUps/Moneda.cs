using UnityEngine;

public class Moneda : PowerUp
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private GameManagerSO gameManager;

    public override void Interactuar()
    {
        gameManager.AddCoins(coinValue);
        Destroy(gameObject);
    }
}
