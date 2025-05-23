using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveUI : MonoBehaviour
{
    public Button button;
    public Canvas canvas;
    public GameObject checker;
    private void Awake()
    {
        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        DisableCanvas();
        StartCoroutine(LockCursorDelayed());
        checker.SetActive(false);
    }

    void DisableCanvas()
    {
        canvas.enabled = false;
    }
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    IEnumerator LockCursorDelayed()
{
    yield return new WaitForSeconds(1);
    LockCursor();
}
}
