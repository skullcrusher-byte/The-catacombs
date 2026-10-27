using UnityEngine;

public class Room1InscriptionInteraction : MonoBehaviour
{
    public GameObject puzzleCanvas;

    void Update()
    {
        // Close the puzzle with Escape
        if (puzzleCanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            puzzleCanvas.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleCanvas.SetActive(true);
        }
    }
}