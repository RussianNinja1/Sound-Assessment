using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    public bool DialogActive;

    public string[] dialogueLines;
    public int currentLine;

    private FirstPersonController ThePlayer;
    // Start is called before the first frame update
    void Start()
    {
        ThePlayer = FindObjectOfType<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogActive && Input.GetKeyDown(KeyCode.E))
        {
            //dialogueBox.SetActive(false);
            //DialogActive = false;
            currentLine++;
        }
        if (currentLine >= dialogueLines.Length)
        {
            dialogueBox.SetActive(false);
            DialogActive = false;

            currentLine = 0;
            ThePlayer.playerCanMove = true;
        }
        dialogueText.text = dialogueLines[currentLine];

    }
    public void ShowBox(string dialogue)
    {
        DialogActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }

    public void ShowDialogue()
    {
        DialogActive = true;
        dialogueBox.SetActive(true);
        ThePlayer.playerCanMove = false;

    }
}
