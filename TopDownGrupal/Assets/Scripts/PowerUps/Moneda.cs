using UnityEngine;

public class Moneda : PowerUp
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private GameManagerSO gameManager;

    public override void Interactuar()
    {
        gameManager.AddCoins(coinValue);
        AudioManager.Instance.PlaySFX(3);

        Destroy(gameObject);
    }
}
