using UnityEngine;
using UnityEngine.SceneManagement;

public class Room2LockedDoor : MonoBehaviour
{
    public string sceneToLoad = "StartScreen";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (Room2KeyCollect.keysCollected >= 1)
        {
            Debug.Log("Both keys inserted! Game complete!");

            // Reset keys for the next playthrough
            Room2KeyCollect.keysCollected = 0;

            // Clear the previous spawn point
            SceneSpawnData.spawnPointName = "";

            // Return to the start menu
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.Log("The door is locked. Find both keys!");
        }
    }
}