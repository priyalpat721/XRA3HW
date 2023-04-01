using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitializeScoreBoard : MonoBehaviour
{
    public TMP_Text fatRat;
    public TMP_Text bills;
    public TMP_Text balearic;

    private int level1;
    private int level2;
    private int level3; 

    void Start()
    {
        level1 = PlayerPrefs.GetInt("Level1");
        level2 = PlayerPrefs.GetInt("Level2");
        level3 = PlayerPrefs.GetInt("Level3");

        fatRat.text = "The Fat Rat: " + level1;
        bills.text = "$100 Bills: " + level2;
        balearic.text = "Balearic Pumping: " + level3;
    }
}
