using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToLobby : MonoBehaviour
{
    public int load;
    public AudioClip clip;

    OVRCameraRig player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftController")
        {
            LoadScene();
        }
        else if (collision.gameObject.tag == "RightController")
        {
            LoadScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "LeftController")
        {
            LoadScene();
        }
        else if (other.gameObject.tag == "RightController")
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        player = FindObjectOfType<OVRCameraRig>();
        Destroy(player);
        SceneManager.LoadScene(load);
    }
}
