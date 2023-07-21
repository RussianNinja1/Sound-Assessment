using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using System.Data;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    [SerializeField] private float typingSpeed = 0.04f;
    private Coroutine displayLineCoroutine;
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
        if (displayLineCoroutine != null)
        {
            StopCoroutine(displayLineCoroutine);
        }
        displayLineCoroutine = StartCoroutine(DisplayLine(dialogueLines[currentLine]));
        //dialogueText.text = dialogueLines[currentLine];

    }
    private IEnumerator DisplayLine(string line)
    {
        // empty dialogue text
        dialogueText.text = "";
        foreach(char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
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
