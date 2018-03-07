using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            scoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
        }
    }
}