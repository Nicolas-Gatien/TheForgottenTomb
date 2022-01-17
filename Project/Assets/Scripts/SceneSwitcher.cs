using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public SceneTransition sceneSwitcher;

    private void Start()
    {
        sceneSwitcher = FindObjectOfType<SceneTransition>();
    }

    public void StartGame()
    {
        sceneSwitcher.LoadScene(1);
    }
    public void MenuControlsScene()
    {
        sceneSwitcher.LoadScene(5);
    }
    public void PauseControls()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        GameObject controlsMenu = gameManager.controlMenu;
        Instantiate(controlsMenu, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        sceneSwitcher.LoadScene(0);
    }
    public void Resume()
    {
        Destroy(gameObject);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.paused = false;
        gameManager.player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void PauseControlX()
    {
        Destroy(gameObject);
    }

    public void ControlsMenuX()
    {
        sceneSwitcher.LoadScene(0);
    }
}
