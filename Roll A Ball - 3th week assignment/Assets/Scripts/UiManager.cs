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

        Time.timeScale = 1f;
        GameIsPaused = false;
    }




    async public void PlayGame()
    {
        Debug.Log("playing");
        CloseAllPanels();
        panels[5].SetActive(true);
        panels[6].SetActive(true);
        await Task.Delay(1000);
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
            Time.timeScale = 0f;
            gameIsOver = true;
        }


    }
    public void OpenWinMenuPanel()
    {

        CloseAllPanels();
        panels[4].SetActive(true);
        Time.timeScale = 0f;
    }


    public void PauseButton()
    {

        CloseAllPanels();
        panels[2].SetActive(true);
        
        Time.timeScale = 0f;
        GameIsPaused = true;
       
    }

    public void CloseOpeningImage()
    {
        panels[0].SetActive(false);


    }

 

}


