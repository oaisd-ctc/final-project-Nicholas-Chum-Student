using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public string targetName = "Farmland(Clone)";

    void Start()
    {
        StartCoroutine(CheckObjectNamePeriodically());
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    void CheckObjectName()
    {
        GameObject[] allObjects = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];

        int count = 0;
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == targetName)
            {
                count++;
            }
        }

        if (count == 2)
        {
            Invoke("LoadNextScene", 0.1f);
        }
        else
        {
            Debug.Log("No or only one object found with the name: " + targetName);
        }
    }
    private IEnumerator CheckObjectNamePeriodically()
    {
        while (true)
        {
            CheckObjectName();
            yield return new WaitForSeconds(0.1f);
        }
    }
}