using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTP : MonoBehaviour
{

    [SerializeField] private Vector2 cavePosition = new Vector2();
    [SerializeField] private Vector2 villagePosition = new Vector2();

    private bool isOnVillage = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(isOnVillage)
                collision.gameObject.transform.position = cavePosition;
            else
                collision.gameObject.transform.position = villagePosition;

            collision.gameObject.GetComponent<Player>().StopAllCoroutines();
            collision.gameObject.GetComponent<Player>().moviendo = false;

            isOnVillage = !isOnVillage;
        }
    }
}
