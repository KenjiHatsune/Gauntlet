using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public TMP_Text Health;
    public TMP_Text Score;
    public GameObject[] Keys = new GameObject[6];
    public GameObject[] Potions = new GameObject[5];
}
