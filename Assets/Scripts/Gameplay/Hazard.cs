using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

	public PlayerBehaviour player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerBehaviour> ();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log ("PlayerDebeMorir");
			player.isDead = true;
		}

	}
}
