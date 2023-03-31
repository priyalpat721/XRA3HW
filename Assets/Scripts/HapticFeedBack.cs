using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticFeedBack : MonoBehaviour
{
    public AudioClip feedbackClip;
    public void ApplyHapticsFeedBack(OVRInput.Controller controller, AudioClip hapticsSFX)
    {
        OVRHapticsClip hapticsClip = new OVRHapticsClip();
        OVRHaptics.LeftChannel.Preempt(hapticsClip);
        AudioSource.PlayClipAtPoint(hapticsSFX, gameObject.transform.position);
        OVRInput.SetControllerVibration(0.01f, 0.01f, controller);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "LeftController")
        {
            ApplyHapticsFeedBack(OVRInput.Controller.LHand, feedbackClip);

        }
        else if (gameObject.tag == "RightController")
        {
            ApplyHapticsFeedBack(OVRInput.Controller.RHand, feedbackClip);

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (gameObject.tag == "LeftController")
        {
            ApplyHapticsFeedBack(OVRInput.Controller.LHand, feedbackClip);

        }
        else if (gameObject.tag == "RightController")
        {
            ApplyHapticsFeedBack(OVRInput.Controller.RHand, feedbackClip);

        }
    }
}
