using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerBehaviour player;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScore;

    public GameObject textDie;
    public GameObject canvasGame;
    public GameObject canvasEnd;

    public bool playerDie;
    public bool pause;
    public GameObject textPause;

    public ParticleSystem dieEffect;
    // Use this for initialization
    void Start ()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;

        theScore = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
        textDie.SetActive(false);
        canvasGame.SetActive(true);
        canvasEnd.SetActive(false);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        platformGenerator.position = platformStartPoint;
        player.transform.position = playerStartPoint;
        theScore.scoreCount = 0;
    }
    public IEnumerator RestartGameCo()
    {
        theScore.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        Time.timeScale = 1;
        /*platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        platformGenerator.position = platformStartPoint;*/
        yield return new WaitForSecondsRealtime(1f);
        playerDie = false;
        player.gameObject.SetActive(true);
        theScore.scoreIncreasing = true;
    }

    public void PlayerDie()
    {
        textDie.SetActive(true);
        dieEffect.Play();
        //Time.timeScale = 0;
        StartCoroutine("YouDie");
        playerDie = true;
    }

    public IEnumerator YouDie()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        canvasGame.SetActive(false);
        canvasEnd.SetActive(true);
    }

    public void PauseGame()
    {
        if (playerDie == false)
        {
            pause = !pause;
            if (pause)
            {
                textPause.SetActive(true);
                Time.timeScale = 0;
            }
            if (!pause)
            {
                textPause.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
