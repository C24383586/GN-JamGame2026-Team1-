using UnityEngine;

public class TakeItem : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement.pickedUp.SetActive(false);
        }
    }
}
