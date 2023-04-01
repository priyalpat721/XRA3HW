using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAfterThisPoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 30)
        {
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.layer == 31)
        {
            Destroy(collision.gameObject);
        }
    }
}
