using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResetCurrentScene : MonoBehaviour
{
    Scene scene;
    public GameObject medium;

    private  void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LeftController"))
        {
            ResetScene(OVRInput.Controller.LTouch);
        }
        else if (collision.gameObject.CompareTag("RightController"))
        {
            ResetScene(OVRInput.Controller.RTouch);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("LeftController"))
        {
            ResetScene(OVRInput.Controller.LTouch);
        }
        else if (other.gameObject.CompareTag("RightController"))
        {
            ResetScene(OVRInput.Controller.RTouch);
        }
    }

    private async void ResetScene(OVRInput.Controller controller)
    {
        Vector3 force = OVRInput.GetLocalControllerVelocity(controller);
        float magnitude = force.magnitude;

        if (magnitude > 0)
        {
            gameObject.SetActive(false);
            GameObject brokenPieces = Instantiate(medium, gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody[] rigidbodies = brokenPieces.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rigid in rigidbodies)
            {
                rigid.AddExplosionForce(30 * magnitude, brokenPieces.transform.position, 20);
            }
            Destroy(gameObject);
            Destroy(brokenPieces, 1f);
            await Task.Delay(1500);
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(scene.name);
        }
    }
}
