using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasingWelcomeMenu : MonoBehaviour
{
    public float currentTime;
    public float duration;
    public Vector2 iniPos;
    public Vector2 finalPos;

    // Update is called once per frame
    public void Start()
    {
        transform.localPosition = new Vector3(iniPos.x, iniPos.y, transform.localPosition.z);
    }

    void Update()
    {
        if (currentTime >= 0)
        {
            Vector2 value = new Vector2(Easing.QuartEaseOut(currentTime, iniPos.x, finalPos.x - iniPos.x, duration), Easing.QuartEaseOut(currentTime, iniPos.y, finalPos.y - iniPos.y, duration));
            transform.localPosition = new Vector3(value.x, value.y, transform.localPosition.z);
        }

        currentTime += Time.deltaTime;

        if (currentTime >= duration)
        {
            transform.localPosition = new Vector3(finalPos.x, finalPos.y, transform.localPosition.z);
        }
    }
}