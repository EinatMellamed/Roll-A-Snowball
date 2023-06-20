using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class UiManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] List<GameObject> panels;

    [SerializeField] static bool GameIsPaused = false;
    [SerializeField] bool gameIsOver = false;

    [SerializeField] Animator anim;

    private void Awake()
    {
        panels[0].SetActive(true);
        Time.timeScale = 0f;
    }
    void Start()
    {
       // CloseAllPanels();
       
        panels[1].SetActive(true);
        EventManager.Instance.PlayMusic("Waiting");
        EventManager.Instance.musicSource.volume = 0.7f;
        EventManager.Instance.musicSource.loop = true;
        EventManager.Instance.sfxSource.volume = 1f;
        gameIsOver = false;
        GameIsPaused = false;
    }

    // Update is called once per frame


    private void CloseAllPanels()
    {
        foreach (GameObject p in panels)
        {
            p.SetActive(false);

        }


    }

    public void Resume()
    {

        CloseAllPanels();
        panels[5].SetActive(true);
        panels[6].SetActive(true);
        EventManager.Instance.musicSource.volume = 0.7f;
        EventManager.Instance.musicSource.loop = true;
        EventManager.Instance.sfxSource.volume = 1f;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }




     public void PlayGame()
    {
        Debug.Log("playing");
        CloseAllPanels();
        EventManager.Instance.PlayMusic("BackgroundMusic");
        EventManager.Instance.musicSource.volume = 0.7f;
        EventManager.Instance.musicSource.loop = true;
        panels[5].SetActive(true);
        panels[6].SetActive(true);
       
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panels[5].SetActive(true);

    }

    public void OpenGameOverPanel()
    {
        if (gameIsOver)
        {
            return;
        }
        else
        {
            CloseAllPanels();
            panels[3].SetActive(true);
            EventManager.Instance.PlayMusic("GameOverTheme");
            EventManager.Instance.musicSource.loop = false;

            Time.timeScale = 0f;
            gameIsOver = true;
        }


    }
    public void OpenWinMenuPanel()
    {

        CloseAllPanels();
        panels[4].SetActive(true);
        EventManager.Instance.PlayMusic("WinTheme");
        EventManager.Instance.musicSource.loop = false;

        Time.timeScale = 0f;
    }


    public void PauseButton()
    {

        CloseAllPanels();
        panels[2].SetActive(true);
        EventManager.Instance.musicSource.volume = 0.1f;
        EventManager.Instance.sfxSource.volume = 0.1f;
        Time.timeScale = 0f;
        GameIsPaused = true;
       
    }

    public void CloseOpeningImage()
    {
        panels[0].SetActive(false);


    }

 

}


