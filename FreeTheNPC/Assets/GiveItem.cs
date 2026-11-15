using UnityEngine;

public class GiveItem : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement.pickedUp.SetActive(true);
        }
    }
}
