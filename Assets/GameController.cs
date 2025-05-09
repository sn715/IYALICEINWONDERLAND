using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI WelcomeUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WelcomeUI.gameObject.SetActive(false);
        }
    }
}
