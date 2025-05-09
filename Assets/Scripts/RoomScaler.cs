using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RoomScalerVR : MonoBehaviour
{
    [Header("Room Scaling")]
    public Transform roomParent;
    public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    public float scaleDuration = 1.0f;

    private Vector3 originalScale;

    [Header("Height Transform")]
    public GameObject objectToMove;
    private Vector3 originalPosition;

    [Header("Visibility Control")]
    public GameObject[] objectsToHide; // e.g., the Blue Book
    public GameObject[] objectsToShow; // e.g., the Tennis Ball

    [Header("UI Prompt")]
    public VRUIPromptManager uiManager;

    [Header("Audio")]
    public AudioClip sound; // Assign this in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        originalScale = roomParent.localScale;

        // Add or get AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.spatialBlend = 1f; // Make it 3D
    }

    public void ScaleRoomUp()
    {
        StopAllCoroutines();
        StartCoroutine(ScaleOverTime(roomParent, targetScale, scaleDuration));

        if (sound != null)
        {
            audioSource.PlayOneShot(sound);
        }

        if (objectToMove != null)
            objectToMove.SetActive(false);

        foreach (GameObject go in objectsToHide)
        {
            if (go != null) go.SetActive(false);
        }

        foreach (GameObject go in objectsToShow)
        {
            if (go != null) go.SetActive(true);
        }

        if (uiManager != null)
            uiManager.ShowBallPrompt(); // Show “Look for the tennis ball”
    }

    public void ScaleRoomDown()
    {
        StopAllCoroutines();
        StartCoroutine(ScaleOverTime(roomParent, originalScale, scaleDuration));
    }

    private System.Collections.IEnumerator ScaleOverTime(Transform target, Vector3 toScale, float duration)
    {
        Vector3 fromScale = target.localScale;
        float time = 0;

        while (time < duration)
        {
            target.localScale = Vector3.Lerp(fromScale, toScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        target.localScale = toScale;
    }
}
