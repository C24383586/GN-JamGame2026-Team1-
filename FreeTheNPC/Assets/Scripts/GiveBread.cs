using UnityEngine;

public class GiveBread : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement.item1Held = true;
            playerMovement.item2Held = false;
        }
    }
}
