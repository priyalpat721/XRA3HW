using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject passed;
    public GameObject failed;
    public TMP_Text score;
    public GameObject[] spawnpoints;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetChild(0).transform.gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        int scoreNum = int.Parse(score.text);
        if (!audioSource.isPlaying)
        {
            if (scoreNum <= 0f)
            {
                foreach (GameObject spawn in spawnpoints)
                {
                    spawn.SetActive(false);
                }
                failed.SetActive(true);
            }
            else
            {
                foreach (GameObject spawn in spawnpoints)
                {
                    spawn.SetActive(false);
                }
                passed.SetActive(true);
                string currentScene = SceneManager.GetActiveScene().name;
                int highestScore = PlayerPrefs.GetInt(currentScene);
                if (highestScore < scoreNum)
                {
                    PlayerPrefs.SetInt(currentScene, scoreNum);
                }
            }
        }
        else
        {
            if (scoreNum < 0f)
            {
                foreach (GameObject spawn in spawnpoints)
                {
                    spawn.SetActive(false);
                }
                audioSource.Stop();
                failed.SetActive(true);
            }
        }
    }
}
