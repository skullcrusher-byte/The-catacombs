using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : MonoBehaviour
{
    public string sceneToLoad;
    public string destinationSpawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTRANCE TOUCHED BY: " + other.name);

        if (other.CompareTag("Player"))
        {
            SceneSpawnData.spawnPointName = destinationSpawnPoint;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}