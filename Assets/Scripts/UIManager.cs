using UnityEngine;
using System.Collections;


public class VRUIPromptManager : MonoBehaviour
{
    [Header("UI Prompts")]
    public GameObject startPrompt;
    public GameObject bookPrompt;
    public GameObject ballPrompt;
    public GameObject lampPrompt;
    public GameObject finalPrompt;

    void Start()
    {
        HideAll();
        StartCoroutine(ShowStartThenBookPrompt());
    }

    private IEnumerator ShowStartThenBookPrompt()
    {
        startPrompt.SetActive(true);
        yield return new WaitForSeconds(10f);
        startPrompt.SetActive(false);
        bookPrompt.SetActive(true);
    }

    public void ShowBallPrompt()
    {
        HideAll();
        ballPrompt.SetActive(true);
    }

    public void ShowLampPrompt()
    {
        HideAll();
        lampPrompt.SetActive(true);
    }

    public void ShowFinalPrompt()
    {
        HideAll();
        finalPrompt.SetActive(true);
    }

    void HideAll()
    {
        bookPrompt.SetActive(false);
        ballPrompt.SetActive(false);
        lampPrompt.SetActive(false);
        finalPrompt.SetActive(false);
    }
}
