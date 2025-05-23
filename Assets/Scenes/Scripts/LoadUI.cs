using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadUI : MonoBehaviour
{
    public string targetName = "Farmland(Clone)";
    public Canvas uiCanvas;

    void Start()
    {
        StartCoroutine(CheckObjectNamePeriodically());
    }

    void LoadUserInterface()
    {
        uiCanvas.gameObject.SetActive(true);
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

        Debug.Log("Found " + count + " objects with the name: " + targetName);
        if (count == 100)
        {
            LoadUserInterface();
            Cursor.lockState = CursorLockMode.None;
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