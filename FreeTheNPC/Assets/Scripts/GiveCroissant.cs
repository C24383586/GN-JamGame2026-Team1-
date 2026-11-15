using UnityEngine;

public class GiveCroissant : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement.item1Held = false;
            playerMovement.item2Held = true;
        }
    }
}
