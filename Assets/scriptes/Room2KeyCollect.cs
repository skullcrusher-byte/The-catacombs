using UnityEngine;

public class Room2KeyCollect : MonoBehaviour
{
    public static int keysCollected = 0;

    private bool playerNearby = false;
    private bool collected = false;

    void Update()
    {
        if (playerNearby && !collected && Input.GetKeyDown(KeyCode.F))
        {
            collected = true;
            keysCollected = 1;
            KeyInventory.room2Key = true;
            Debug.Log("Room 2 key collected!");

            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}