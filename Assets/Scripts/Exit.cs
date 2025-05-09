using UnityEngine;

public class LampTrigger : MonoBehaviour
{
    [Header("Skybox Settings")]
    public Material newSkybox;
    public Renderer[] walls;
    public Color newColor = Color.red;

    [Header("Visibility Control")]
    public GameObject[] objectsToHide; // e.g., the lamp or previous objects
    public GameObject[] objectsToShow; // e.g., new room or portal

    [Header("UI Prompt")]
    public VRUIPromptManager uiManager;

    [Header("Audio")]
    public AudioClip sound; // Assign this in the Inspector
    private AudioSource audioSource;
    void Start()
    {
        // Add or get AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.spatialBlend = 1f; // Enable 3D spatial sound
    }

    public void TriggerLampEvent()
    {

        // Play sound
        if (sound != null)
        {
            audioSource.PlayOneShot(sound);
        }

        if (newSkybox != null)
            RenderSettings.skybox = newSkybox;

        foreach (Renderer wall in walls)
        {
            if (wall != null)
                wall.material.color = newColor;
        }

        foreach (GameObject go in objectsToHide)
        {
            if (go != null)
                go.SetActive(false);
        }

        foreach (GameObject go in objectsToShow)
        {
            if (go != null)
                go.SetActive(true);
        }

        if (uiManager != null)
            uiManager.ShowFinalPrompt(); // Show “A new path has opened...”
    }
}
