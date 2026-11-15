using UnityEngine;

public class ResetNPC : MonoBehaviour
{
    public NPCAI nPCAI;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("NPC"))
        {
            nPCAI.OrderType = Random.Range(1,3);
            nPCAI.Target.position = nPCAI.ArrivingLocation.position;
            Debug.Log("NPC Detected");
        }
    }
}
