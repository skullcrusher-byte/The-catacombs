using UnityEngine;
using TMPro;

public class Room2Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject youDiedText;
    public GameObject player;

    public float timeRemaining = 30f;

    private bool gameOver = false;

    void Update()
    {
        if (gameOver) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            LoseGame();
        }

        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = "00:" + seconds.ToString("00");
    }

    void LoseGame()
    {
        gameOver = true;

        youDiedText.SetActive(true);

        // Stop Eliska from moving
        if (player != null)
        {
            MonoBehaviour[] scripts =
                player.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour script in scripts)
            {
                if (script != null)
                    script.enabled = false;
            }

            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            if (rb != null)
                rb.linearVelocity = Vector2.zero;
        }

        Debug.Log("YOU DIED! Time ran out.");
    }
}