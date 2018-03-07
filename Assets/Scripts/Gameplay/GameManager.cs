using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerBehaviour player;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;
	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }
    public IEnumerator RestartGameCo()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);
    }
}
