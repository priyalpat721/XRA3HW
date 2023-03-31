using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class ChangeLevelsDiamonds : MonoBehaviour
{
    public GameObject medium;

    public int load;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftController")
        {
            ApplyDamageToDiamond(OVRInput.Controller.LTouch);
        }
        else if (collision.gameObject.tag == "RightController")
        {
            ApplyDamageToDiamond(OVRInput.Controller.RTouch);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "LeftController")
        {
            ApplyDamageToDiamond(OVRInput.Controller.LTouch);
        }
        else if (other.gameObject.tag == "RightController")
        {
            ApplyDamageToDiamond(OVRInput.Controller.RTouch);
        }
    }

    public async void ApplyDamageToDiamond(OVRInput.Controller controller)
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
            LoadScene();
        }
    }

    public void LoadScene()
    {
        if (FindObjectOfType<OVRCameraRig>() != null)
        {
            SceneManager.LoadSceneAsync(load);
        }
    }
}