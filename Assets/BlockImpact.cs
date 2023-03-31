using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockImpact : MonoBehaviour
{
    GameObject scoreBoard;
    public AudioClip oops;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "LeftController")
        {
            ApplyDamage();
        }
        else if (other.gameObject.tag == "RightController")
        {
            ApplyDamage();
        }
    }

    public void ApplyDamage()
    {
        scoreBoard = GameObject.FindGameObjectWithTag("Scorable");
        GameObject score = scoreBoard.transform.GetChild(0).gameObject;
        TMP_Text scoreText = score.GetComponent<TMP_Text>();
        int scoreNum = -100;
        int scoreNumbers = int.Parse(scoreText.text);
        scoreNumbers += scoreNum;
        scoreText.text = new string(scoreNumbers.ToString());
        AudioSource.PlayClipAtPoint(oops, gameObject.transform.position);
        Destroy(gameObject, 0.1f);
    }
}
