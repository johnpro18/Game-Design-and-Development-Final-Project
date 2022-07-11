using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    [Header ("UI Parameters")]
    [SerializeField] private GameObject defeatMenuUI;

    public void Resume()
    {
        defeatMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
        Debug.Log("G003");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("G001");
    }
}
