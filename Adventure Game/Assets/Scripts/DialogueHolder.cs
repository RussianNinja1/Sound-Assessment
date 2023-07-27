using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    
    private DialogueManager dMan;
    public string[] dialogueLines;
    private BoxCollider colid;
    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        colid = GetComponent<BoxCollider>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            //dMan.ShowBox(dialogue);
            if(!dMan.DialogActive)
            {
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                colid.enabled = !colid.enabled;
            }
        }
    }
}
