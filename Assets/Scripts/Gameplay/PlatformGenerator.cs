
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

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;

    private float heightChange;

    private CoinGenerator coinGenerator;
    public float randomCoinThreshold;

   // public ObjectPooling hazardGenerator;
   //public float randomHazardThreshold;

    // Use this for initialization
    void Start ()
    {
        platformWidth = platform.GetComponent<CompositeCollider2D>().bounds.size.x;

        platformsWidth = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++) 
        {
            platformsWidth[i] = theObjectPools[i].pooledObject.GetComponent<CompositeCollider2D>().bounds.size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        coinGenerator = FindObjectOfType<CoinGenerator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.x < generatorPoint.position.x)
        {
            distBetweenPlat = Random.Range(distBetweenMin, distBetweenMax);

            platformOption = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformsWidth[platformOption] /2) + distBetweenPlat, heightChange, transform.position.z);

            //Instantiate(/*platform*/ theObjectPools[platformOption], transform.position, transform.rotation);


            GameObject newPlatform = theObjectPools[platformOption].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f, 10f) < randomCoinThreshold)
            {
                coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z));
            }

            /*if (Random.Range(0f, 10f) < randomHazardThreshold)
            {
                GameObject newHazard = hazardGenerator.GetPooledObject();

                float hazardXPosition = Random.Range(-platformWidth/ 2f , platformWidth / 2f);
                Vector3 hazardSposition = new Vector3(hazardXPosition, 0.5f, 0f);

                newHazard.transform.position = transform.position + hazardSposition;
                newHazard.transform.rotation = transform.rotation;
                newHazard.SetActive(true);
            }*/

            transform.position = new Vector3(transform.position.x + (platformsWidth[platformOption] / 2), transform.position.y, transform.position.z);
        }
    }
}
