using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generatorPoint;
    public float distBetweenPlat;

    private float platformWidth;

    public float distBetweenMin;
    public float distBetweenMax;

    private int platformOption;
    public GameObject[] platforms;
    private float[] platformsWidth;

    //public ObjectPooling theObjectPool;
    
        
    // Use this for initialization
    void Start ()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        platformsWidth = new float[platforms.Length];
        for (int i = 0; i < platforms.Length; i++) 
        {
            platformsWidth[i] = platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.x < generatorPoint.position.x)
        {
            distBetweenPlat = Random.Range(distBetweenMin, distBetweenMax);

            platformOption = Random.Range(0, platforms.Length);

            transform.position = new Vector3(transform.position.x + platformsWidth[platformOption] + distBetweenPlat, transform.position.y, transform.position.z);

            Instantiate(/*platform*/ platforms[platformOption], transform.position, transform.rotation);


            /*GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);*/
        }
	}
}
