using UnityEngine;

public class BreadOrder : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        // Find all DialogueManager instances in the scene
        DialogueManager[] managers = FindObjectsByType<DialogueManager>();

        if (managers.Length > 0 && managers[0] != null)
        {
            managers[0].StartDialogue(dialogue);
        }
        else
        {
            Debug.LogWarning("No DialogueManager found in the scene.");
        }
    }
}
