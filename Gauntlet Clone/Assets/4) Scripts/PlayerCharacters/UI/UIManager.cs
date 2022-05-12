using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [Header("Player Panel Components")]
    public Image Background;
    public GameObject[] PlayerStatus = new GameObject[4];
    public GameObject[] PlayerCredit = new GameObject[4];
    public Adventurer[] Adventurers = new Adventurer[4];
    public PlayerData[] PlayerData = new PlayerData[4];
    public TMP_Text CreditCount;

    public int Credits = 4;

    [Header("Background Variants")]
    private Color _standardBackground;
    [SerializeField] private Color _clearBackground;

    // Start is called before the first frame update
    void Start()
    {
        //Saving Background Starting Color.
        _standardBackground = Background.color;

        //Blanking out each Player Status Area.
        foreach (GameObject item in PlayerStatus)
        {
            item.SetActive(false);
        }

        //Ensuring all player data is up to date.
        for (int i = 0; i < 4; i++)
        {
            UpdatePlayerData(i);
        }

        //Updating Credit Counter.
        UpdateCredits();
    }

    public void AddPlayer(Adventurer NewAdventurer)
    {
        for (int i = 0; i < 4; i++)
        {
            if (Adventurers[i] == null)
            {
                Adventurers[i] = NewAdventurer;
                PlayerStatus[i].SetActive(true);
                PlayerCredit[i].SetActive(false);
                UpdatePlayerData(i);
                i = 99;
            }
        }
    }

    public void RemovePlayer(int Neku)
    {
        //Disconnecting Player from UI.
        PlayerStatus[Neku].SetActive(false);
        PlayerCredit[Neku].SetActive(true);
    }

    public void UpdatePlayerData(int PlayerNumber)
    {
        Debug.Log(PlayerNumber);
        //Ensuring player data isn't updated.
        if (Adventurers[PlayerNumber] == null) return;

        //Updating Health and Score Numbers.
        PlayerData[PlayerNumber].Health.text = "Health: " + Adventurers[PlayerNumber].Health.ToString("0000000");
        PlayerData[PlayerNumber].Score.text = "Score: " + Adventurers[PlayerNumber].Score.ToString("0000000");

        //Displaying Number of Keys
        int temp = Adventurers[PlayerNumber].Keys;
        foreach (GameObject key in PlayerData[PlayerNumber].Keys)
        {
            if (temp > 0)
                key.SetActive(true);
            else
                key.SetActive(false);

            temp--;
        }

        //Displaying Number of Potions
        temp = Adventurers[PlayerNumber].MagicPotions;
        foreach (GameObject mp in PlayerData[PlayerNumber].Potions)
        {
            if (temp > 0)
                mp.SetActive(true);
            else
                mp.SetActive(false);

            temp--;
        }
    }

    public void UpdateCredits()
    {
        CreditCount.text = "Credits: " + Credits.ToString("00");
    }

    public void HideBackground()
    {
        Background.color = _clearBackground;
    }

    public void ShowBackground()
    {
        Background.color = _standardBackground;
    }
}
