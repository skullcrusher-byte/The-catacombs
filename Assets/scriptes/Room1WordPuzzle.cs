using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Room1WordPuzzle : MonoBehaviour
{
    [Header("Blank Text")]
    public TMP_Text blank1Text;
    public TMP_Text blank2Text;
    public TMP_Text blank3Text;

    [Header("Word Buttons")]
    public Button cleansedButton;
    public Button bloodButton;
    public Button forgivenessButton;

    [Header("Magic Seal")]
    public GameObject keySeal;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip successSound;

    private string selectedWord = "";

    private string[] answers = { "", "", "" };

    private bool puzzleSolved = false;

    public void SelectCleansed()
    {
        selectedWord = "CLEANSED";
    }

    public void SelectBlood()
    {
        selectedWord = "BLOOD";
    }

    public void SelectForgiveness()
    {
        selectedWord = "FORGIVENESS";
    }

    public void PlaceWord1()
    {
        PlaceWord(0, blank1Text);
    }

    public void PlaceWord2()
    {
        PlaceWord(1, blank2Text);
    }

    public void PlaceWord3()
    {
        PlaceWord(2, blank3Text);
    }

    void PlaceWord(int index, TMP_Text blankText)
    {
        if (puzzleSolved || selectedWord == "")
            return;

        // Remove this word from any other blank.
        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i] == selectedWord)
            {
                answers[i] = "";
                UpdateBlank(i, "________");
            }
        }

        answers[index] = selectedWord;
        blankText.text = selectedWord;

        selectedWord = "";

        CheckAnswers();
    }

    void UpdateBlank(int index, string text)
    {
        if (index == 0) blank1Text.text = text;
        if (index == 1) blank2Text.text = text;
        if (index == 2) blank3Text.text = text;
    }

    void CheckAnswers()
    {
        if (answers[0] == "CLEANSED" &&
            answers[1] == "BLOOD" &&
            answers[2] == "FORGIVENESS")
        {
            SolvePuzzle();
        }
    }

    void SolvePuzzle()
    {
        puzzleSolved = true;

        if (audioSource != null && successSound != null)
        {
            audioSource.PlayOneShot(successSound);
        }

        if (keySeal != null)
        {
            keySeal.SetActive(false);
        }

        Debug.Log("Room 1 puzzle solved!");
    }
}