using TMPro;
using System.Collections;
using UnityEngine;

public class OnClickEvent : MonoBehaviour
{
    public TextMeshProUGUI soundText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
            soundText.text = "/";
        else
            soundText.text = "";
    }

    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            soundText.text = "";
        }

        else
        {
            GameManager.mute = true;
            soundText.text = "/";
        }
    }

   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void PauseResumeGame()
    {
        if (!GameManager.isPaused)
        {
            Time.timeScale = 0;
            Debug.Log("pause");
            GameManager.isPaused = true;
            GameObject.FindObjectOfType<GameManager>().gamePausedPanel.SetActive(true);
            GameObject.FindObjectOfType<GameManager>().gamePlayPanel.SetActive(false);
        }
      
    }
}
