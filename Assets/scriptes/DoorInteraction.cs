using UnityEngine;
using TMPro;

public class DoorInteraction : MonoBehaviour
{
    public GameObject doorCloseUp;
    public TMP_Text inscriptionText;
    public GameObject middleKeyInserted;

    public string ancientText = "???";
    public string translatedText =
        "Remember you are dust, and to dust you shall return.";

    private bool panelOpen;
    private bool middleKeyPlaced = false;

    void Start()
    {
        doorCloseUp.SetActive(false);
        middleKeyInserted.SetActive(false);
    }

    void Update()
    {
        if (panelOpen && Input.GetKeyDown(KeyCode.E))
        {
            inscriptionText.text = translatedText;
        }
        // Press F to insert the collected key into the middle slot.
if (panelOpen && Input.GetKeyDown(KeyCode.F))
{
    if (KeyCollect.hasMiddleKey && !middleKeyPlaced)
    {
        middleKeyPlaced = true;
        middleKeyInserted.SetActive(true);
    }
}
        if (panelOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseDoor();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            panelOpen = true;
            inscriptionText.text = ancientText;
            doorCloseUp.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            CloseDoor();
        }
    }

    public void CloseDoor()
    {
        panelOpen = false;
        doorCloseUp.SetActive(false);
    }
}