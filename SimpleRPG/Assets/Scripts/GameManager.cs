using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject m_NoticePanel;
    public GameObject m_AskPanel;

    public void ShowNotice()
    {
        this.m_NoticePanel.SetActive(true);
    }

    public void CloseNotice()
    {
        this.m_NoticePanel.SetActive(false);
    }

    public void ShowAsk()
    {
        this.m_AskPanel.SetActive(true);
    }

    public void CloseAsk()
    {
        this.m_AskPanel.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        this.ShowNotice();
    }
}
