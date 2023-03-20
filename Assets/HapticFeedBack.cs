using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticFeedBack : MonoBehaviour
{
    public AudioClip feedbackClip;
    public void ApplyHapticsFeedBack(OVRInput.Controller controller, AudioClip hapticsSFX)
    {
        OVRHapticsClip hapticsClip = new OVRHapticsClip();

        if (controller == OVRInput.Controller.LTouch)
        {
            OVRHaptics.LeftChannel.Preempt(hapticsClip);
            AudioSource.PlayClipAtPoint(hapticsSFX, gameObject.transform.position);
        }
        else
        {
            OVRHaptics.RightChannel.Preempt(hapticsClip);
            AudioSource.PlayClipAtPoint(hapticsSFX, gameObject.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "LeftController")
        {
            ApplyHapticsFeedBack(OVRInput.Controller.LHand, feedbackClip);

        }
        else
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
        else
        {
            ApplyHapticsFeedBack(OVRInput.Controller.RHand, feedbackClip);

        }
    }
}
