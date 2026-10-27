using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoorRestart : MonoBehaviour
{
    private bool playerNearby = false;

    void Update()
    {
        // Only activate when Eliska is near the door and presses F
        if (playerNearby && Input.GetKeyDown(KeyCode.F))
        {
            if (KeyInventory.TotalKeys == 3)
            {
                Debug.Log("All 3 keys inserted! Returning to title screen.");

                // Reset inventory
                KeyInventory.ResetKeys();

                Room2KeyCollect.keysCollected = 0;
                KeyCollect.hasMiddleKey = false;

                // Clear spawn point
                SceneSpawnData.spawnPointName = "";

                // Return to title screen
                SceneManager.LoadScene("StartScreen");
            }
            else
            {
                Debug.Log("You need all 3 keys to unlock the final door!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Press F to insert the keys.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}