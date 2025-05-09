using UnityEngine;

public class RoomEntryTrigger : MonoBehaviour
{
    public VRUIPromptManager uiManager;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            if (uiManager != null)
            {
                uiManager.ShowFinalPrompt(); // or a different prompt method if you want
            }
        }
    }
}
