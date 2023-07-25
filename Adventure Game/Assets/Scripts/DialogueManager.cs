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

    [Header("Audio")]
    [SerializeField] private AudioClip[] dialogueTypingSoundClips;
    [SerializeField] private bool StopAudioSource;
    [Range(1,5)]
    [SerializeField] private int frequencyLevel = 2;
    [Range(-3, 3)]
    [SerializeField] private float minPitch = 0.5f;
    [Range(-3, 3)]
    [SerializeField] private float maxPitch = 3f;

    private AudioSource audioSource;

    private FirstPersonController ThePlayer;
    // Start is called before the first frame update
    void Start()
    {
        ThePlayer = FindObjectOfType<FirstPersonController>();

        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogActive && Input.GetKeyDown(KeyCode.E))
        {
            //dialogueBox.SetActive(false);
            //DialogActive = false;
            
            currentLine++;

            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            string nextline = dialogueLines[currentLine];
         displayLineCoroutine = StartCoroutine(DisplayLine(nextline));
            //dialogueText.text = dialogueLines[currentLine];
        }

        if (currentLine >= dialogueLines.Length)
        {
            dialogueBox.SetActive(false);
            DialogActive = false;

            currentLine = 0;
            ThePlayer.playerCanMove = true;
        }
        
        
    }
    private IEnumerator DisplayLine(string line)
    {
        // empty dialogue text
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;

        //typing effect
        foreach(char letter in line.ToCharArray())
        {
            PlayDialogueSound(dialogueText.maxVisibleCharacters);
            dialogueText.maxVisibleCharacters++;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    private void PlayDialogueSound (int currentDisplayedCharacterCount)
    {
        if(currentDisplayedCharacterCount % frequencyLevel == 0)
        {
            if (StopAudioSource)
            {
                audioSource.Stop();
            }
            //sound clip
            int randomIndex = Random.Range(0, dialogueTypingSoundClips.Length);
            AudioClip soundClip = dialogueTypingSoundClips[randomIndex];
            //pitch
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            //play sound
            audioSource.PlayOneShot(soundClip);
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
