using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class ShowMoney : MonoBehaviour
{
    public static UnityEvent<string, object> OnValueChanged = new UnityEvent<string, object>();

    [SerializeField] private string valueName = "";
    private Text displayText;
    private Player player;
    private void Awake()
    {
        displayText = GetComponent<Text>();
        player = GameObject.FindObjectOfType<Player>();
        StartCoroutine(UpdateMoneyDisplay());
    }
    private IEnumerator UpdateMoneyDisplay()
    {
        while (true)
        {
            displayText.text = player.money.ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void ValueChanged(string valueName, object value)
    {
        if (valueName == "Money")
        {
            displayText.text = value.ToString();
        }
    }
}
