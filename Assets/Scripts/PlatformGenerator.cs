using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generatorPoint;
    public float distBetweenPlat;

    private float platformWidth;
	// Use this for initialization
	void Start ()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.x < generatorPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distBetweenPlat, transform.position.y, transform.position.z);

            Instantiate(platform, transform.position, transform.rotation);
        }
	}
}
