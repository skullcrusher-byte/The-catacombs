using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public static bool hasMiddleKey = false;

    public AudioClip keyJingle;

    private bool playerNearby = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetKey()
    {
        hasMiddleKey = false;
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.F))
        {
            // Collect the church key
            hasMiddleKey = true;

            // Add church key to the inventory
            KeyInventory.churchKey = true;

            Debug.Log("Church key collected! Total keys: "
                + KeyInventory.TotalKeys + "/3");

            // Play key collection sound
            if (keyJingle != null)
            {
                Vector3 soundPosition = Camera.main != null
                    ? Camera.main.transform.position
                    : transform.position;

                AudioSource.PlayClipAtPoint(keyJingle, soundPosition);
            }

            // Hide the collected key
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            playerNearby = false;
        }
    }
}