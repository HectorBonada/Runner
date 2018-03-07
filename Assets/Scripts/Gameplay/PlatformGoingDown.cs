using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGoingDown : MonoBehaviour {

    public Rigidbody2D rb;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.isKinematic = false;
        }
        else if(other.gameObject.tag == "KillBox")
        {
            this.gameObject.SetActive(false);
        }
    }
}
