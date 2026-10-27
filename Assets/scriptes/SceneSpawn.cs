using UnityEngine;

public class SceneSpawn : MonoBehaviour
{
    void Start()
    {
        if (string.IsNullOrEmpty(SceneSpawnData.spawnPointName))
            return;

        GameObject spawnPoint = GameObject.Find(SceneSpawnData.spawnPointName);

        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
        }
    }
}