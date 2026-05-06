using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
            isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
            isGrounded = false;
    }
}
