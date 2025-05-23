using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Button button;
    public Canvas canvas;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        canvas.enabled = !canvas.enabled;
        CursorLockMode cursorLockMode = CursorLockMode.Locked;
        Cursor.lockState = cursorLockMode;
    }
}
