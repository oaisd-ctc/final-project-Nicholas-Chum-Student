using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject playerUIoverlay;
    [SerializeField] private GameObject playerUIplant;
    [SerializeField] private GameObject playerUIshop;

    public GameObject GetPlayerUIoverlay() => playerUIoverlay;
    public GameObject GetPlayerUIplant() => playerUIplant;
    public GameObject GetPlayerUIshop() => playerUIshop;
}
