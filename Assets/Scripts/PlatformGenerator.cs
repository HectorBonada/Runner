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
    //public GameObject[] platforms;
    private float[] platformsWidth;
    
    public ObjectPooling[] theObjectPools;
    
        
    // Use this for initialization
    void Start ()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        platformsWidth = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++) 
        {
            platformsWidth[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.x < generatorPoint.position.x)
        {
            distBetweenPlat = Random.Range(distBetweenMin, distBetweenMax);

            platformOption = Random.Range(0, theObjectPools.Length);

            transform.position = new Vector3(transform.position.x + (platformsWidth[platformOption] /2) + distBetweenPlat, transform.position.y, transform.position.z);

            //Instantiate(/*platform*/ theObjectPools[platformOption], transform.position, transform.rotation);


            GameObject newPlatform = theObjectPools[platformOption].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            transform.position = new Vector3(transform.position.x + (platformsWidth[platformOption] / 2), transform.position.y, transform.position.z);
        }
    }
}
