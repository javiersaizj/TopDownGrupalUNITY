using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemSO misDatos;
    [SerializeField] private GameManagerSO gameManager;
    public void Interactuar()
    {
        gameManager.Inventario.NuevoItem(misDatos);
        AudioManager.Instance.PlaySFX(2);
        Destroy(this.gameObject);
    }
}
