using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployClouds : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(CloudWave());

    }

    private void spwanCloud() {
        GameObject a = Instantiate(cloudPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
    
        
    }

    IEnumerator CloudWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            spwanCloud();
        }
    }
}
