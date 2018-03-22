using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    public GameObject managerScene;
    private LevelManager script;
    public GameManager gameManager;
    public AudioSource sounds;

    private void Start()
    {
        managerScene = GameObject.FindWithTag("Manager");

        script = managerScene.GetComponent<LevelManager>();
    }

    public void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void NewGame()
    {
        sounds.Play();
        script.LoadNext();
    }

    public void TryAgain()
    {
        sounds.Play();
        gameManager.RestartGame();
    }

    public void MainGame()
    {
        sounds.Play();
        script.LoadMenu();
    }

    public void QuitGame()
    {
        sounds.Play();
        script.ExitGame();
    }

    public void SoundClick()
    {
        sounds.Play();
    }
}