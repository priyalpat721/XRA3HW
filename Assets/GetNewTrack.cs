using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetNewTrack : MonoBehaviour
{

    public int load;
    public AudioClip clip;

    OVRCameraRig player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<OVRCameraRig>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((gameObject.tag == "LeftController") || (gameObject.tag == "RightController"))
        {
            if (clip != null)
            {
                player.GetComponent<AssignAudioByScene>().ChangeMusicOnSceneChange(clip);
                LoadScene();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((gameObject.tag == "LeftController") || (gameObject.tag == "RightController"))
        {
            if (clip != null)
            {
                player.GetComponent<AssignAudioByScene>().ChangeMusicOnSceneChange(clip);
                LoadScene();
            }

        }
    }

    public void LoadScene()
    {
        player.GetComponent<AssignAudioByScene>().ChangeMusicOnSceneChange(clip);

        SceneManager.LoadScene(load);
    }
}
