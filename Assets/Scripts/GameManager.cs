using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject DialogueBox;
    public GameObject ESCMenuPanel;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        ESCMenuPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ESCMenuPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOverGM");
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
