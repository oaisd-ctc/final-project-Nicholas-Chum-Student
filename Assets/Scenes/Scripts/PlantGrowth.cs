using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlantGrowth : MonoBehaviour
{
    bool isFinal = false;
    public GameObject T1Crop;
    public GameObject T2Crop;
    public GameObject Crop;
    public float growthTime = 1f;
    public GameObject plantedCrop;
    private float timer = 0f;
    void Start()
    {
        plantedCrop = Instantiate(T1Crop, transform.position, Quaternion.identity);
        StartCoroutine(Grow());
    }

    void Update()
    {
        if (plantedCrop == T1Crop)
        {
            timer += Time.deltaTime;
            if (timer >= growthTime)
            {
                Destroy(plantedCrop);
                Vector3 newPosition = plantedCrop.transform.position + new Vector3(0, 0.5f, 0);
                plantedCrop = Instantiate(T2Crop, newPosition, Quaternion.identity);
                timer = 0f;
            }
        }
        else if (plantedCrop == T2Crop)
        {
            timer += Time.deltaTime;
            if (timer >= growthTime)
            {
                Destroy(plantedCrop);
                Vector3 newPosition = plantedCrop.transform.position + new Vector3(0, 0.5f, 0);
                plantedCrop = Instantiate(Crop, newPosition, Quaternion.identity);
                Debug.Log("Planted crop is Crop");
                timer = 0f;
            }
        }
        else if (isFinal == true)
    {
        Destroy(this.gameObject);
    }
    }
    IEnumerator Grow()
    {
        yield return new WaitForSeconds(growthTime);
        Destroy(plantedCrop);
        Vector3 newPosition = plantedCrop.transform.position + new Vector3(0, 0.5f, 0);
        plantedCrop = Instantiate(T2Crop, newPosition, Quaternion.identity);
        yield return new WaitForSeconds(growthTime);
        Destroy(plantedCrop);
        newPosition = plantedCrop.transform.position + new Vector3(0, 0.5f, 0);
        plantedCrop = Instantiate(Crop, newPosition, Quaternion.identity);
        isFinal = true;
    }
}
