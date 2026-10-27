using UnityEngine;

public class Room1KeyCollect : MonoBehaviour
{
    public GameObject keySeal;
    public AudioClip collectSound;

    private AudioSource audioSource;
    private bool playerNearby = false;
    private bool collected = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Hide the key if it was already collected
        if (KeyInventory.room1Key)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (playerNearby &&
            !collected &&
            !KeyInventory.room1Key &&
            keySeal != null &&
            !keySeal.activeSelf &&
            Input.GetKeyDown(KeyCode.F))
        {
            collected = true;

            // Add Room 1 key to the inventory
            KeyInventory.room1Key = true;

            Debug.Log("Room 1 key collected! Total keys: "
                + KeyInventory.TotalKeys + "/3");

            // Play collection sound
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // Hide the key
            GetComponent<SpriteRenderer>().enabled = false;

            // Stop further interaction
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
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