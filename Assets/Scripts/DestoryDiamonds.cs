using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoryDiamonds : MonoBehaviour
{
    public GameObject small;
    public GameObject medium;
    public GameObject large;
    public string correctHand;
    public string wrongHand;
    public OVRInput.Controller correctController;
    public OVRInput.Controller wrongController;
    public AudioClip yay;
    public AudioClip naw;


    GameObject size;

    OVRCameraRig player;

    GameObject scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<OVRCameraRig>();
        DontDestroyOnLoad(player);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == correctHand)
        {
            ApplyDamageToDiamond(correctController);
        }
        else if (collision.gameObject.tag == wrongHand)
        {
            DamageToWrongDiamond(wrongController);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == correctHand)
        {
            ApplyDamageToDiamond(correctController);
        }
        else if (other.gameObject.tag == wrongHand)
        {
            DamageToWrongDiamond(wrongController);
        }
    }

    public void ApplyDamageToDiamond(OVRInput.Controller controller)
    {
        Vector3 force = OVRInput.GetLocalControllerVelocity(controller);
        float magnitude = force.magnitude;
        bool destoryObj = false;

        scoreBoard = GameObject.FindGameObjectWithTag("Scorable");
        GameObject score = scoreBoard.transform.GetChild(0).gameObject;
        TMP_Text scoreText = score.GetComponent<TMP_Text>();

        size = small;
        if (magnitude > 0.5 && magnitude <= 1)
        {
            destoryObj = true;
            size = small;
        }
        else if (magnitude > 1 && magnitude <= 2)
        {
            destoryObj = true;
            size = medium;
        }
        else if (magnitude > 2)
        {
            destoryObj = true;
            size = large;
        }

        if (destoryObj)
        {
            int scoreNum = 50;
            scoreNum += (int) Math.Round((magnitude * 10f), 0);
            int scoreNumbers = int.Parse(scoreText.text);
            scoreNumbers += scoreNum;
            scoreText.text = new string(scoreNumbers.ToString());
            gameObject.SetActive(false);
            GameObject brokenPieces =  Instantiate(size, gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody[] rigidbodies = brokenPieces.GetComponentsInChildren<Rigidbody>();
            foreach(Rigidbody rigid in rigidbodies)
            {
                rigid.AddExplosionForce(300, brokenPieces.transform.position, 20);
            }
            AudioSource.PlayClipAtPoint(yay, gameObject.transform.position);
            Destroy(gameObject);
            Destroy(brokenPieces, 1f);
        } 
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(gameObject, 0.5f);
        }
    }

    public void DamageToWrongDiamond(OVRInput.Controller controller)
    {
        Vector3 force = OVRInput.GetLocalControllerVelocity(controller);
        float magnitude = force.magnitude;

        scoreBoard = GameObject.FindGameObjectWithTag("Scorable");
        GameObject score = scoreBoard.transform.GetChild(0).gameObject;
        TMP_Text scoreText = score.GetComponent<TMP_Text>();

        int scoreNum = 50;
        scoreNum += (int)Math.Round((magnitude * 10f), 0);
        int scoreNumbers = int.Parse(scoreText.text);
        scoreNumbers -= scoreNum;
        scoreText.text = new string(scoreNumbers.ToString());
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * 350f + transform.up * 100f);
        AudioSource.PlayClipAtPoint(naw, gameObject.transform.position);
        Destroy(gameObject, 3f);
    }
}