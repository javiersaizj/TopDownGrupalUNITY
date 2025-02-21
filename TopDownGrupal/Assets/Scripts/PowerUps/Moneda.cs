using UnityEngine;

public class Moneda : PowerUp
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private GameManagerSO gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RecogerMoneda();
        }
    }
    private void RecogerMoneda()
    {
        gameManager.AddCoins(coinValue); 
        AudioManager.Instance.PlaySFX(3); 
        Destroy(gameObject); 
    }

    public override void Interactuar()
    {
        gameManager.AddCoins(coinValue);
        AudioManager.Instance.PlaySFX(3);

        Destroy(gameObject);
    }
}
