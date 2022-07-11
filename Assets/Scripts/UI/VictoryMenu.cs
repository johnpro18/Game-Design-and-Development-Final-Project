using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    [Header ("UI Parameters")]
    [SerializeField] private GameObject victoryMenuUI;

    public void Resume()
    {
        victoryMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Resume();
        Debug.Log("G004");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("G001");
    }
}
