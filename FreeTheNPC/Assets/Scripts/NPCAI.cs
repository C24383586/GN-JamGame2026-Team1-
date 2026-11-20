using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCAI : MonoBehaviour
{
    public int OrderType;
    public PlayerMovement playerMovement;
    public RightItemGiven rightItemGiven;
    public WrongItemGiven wrongItemGiven;
    public DialogueManager dialogueManager;
    public BreadOrder breadOrder;
    public CroissantOrder croissantOrder;
    public Transform Target;
    public Transform ArrivingLocation;
    public Transform LeavingLocation;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OrderType = Random.Range(1,3);
    }

    // Update is called once per frame
    void Update()
    {
        speed = 5;
        float step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        if (transform.position.z >= 30)
        {
            Target.position = ArrivingLocation.position;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Debug.Log("Player Detected!");
            if (playerMovement.item1Held == true && playerMovement.item2Held == false && OrderType == 1)
            {
                rightItemGiven.TriggerDialogue();
                Target.position = LeavingLocation.position;
                // dialogueManager.textBox.SetActive(true);
                // dialogueManager.animator.SetBool("isOpen", true);
            }
            else if (playerMovement.item1Held == true && playerMovement.item2Held == false && OrderType == 2)
            {
                wrongItemGiven.TriggerDialogue();
                Target.position = LeavingLocation.position;
                // dialogueManager.textBox.SetActive(true);
                // dialogueManager.animator.SetBool("isOpen", true);
            }
            else if (playerMovement.item1Held == false && playerMovement.item2Held == true && OrderType == 1)
            {
                wrongItemGiven.TriggerDialogue();
                Target.position = LeavingLocation.position;
                // dialogueManager.textBox.SetActive(true);
                // dialogueManager.animator.SetBool("isOpen", true);
            }
            else if (playerMovement.item1Held == false && playerMovement.item2Held == true && OrderType == 2)
            {
                rightItemGiven.TriggerDialogue();
                Target.position = LeavingLocation.position;
                //dialogueManager.textBox.SetActive(true);
                //dialogueManager.animator.SetBool("isOpen", true);
            }

            if (playerMovement.item1Held == false && playerMovement.item2Held == false && OrderType == 1)
            {
                breadOrder.TriggerDialogue();
                //dialogueManager.textBox.SetActive(true);
                //dialogueManager.animator.SetBool("isOpen", true);
                Debug.Log("This is working 1!");
            }
            else if (playerMovement.item1Held == false && playerMovement.item2Held == false && OrderType == 2)
            {
                croissantOrder.TriggerDialogue();
                //dialogueManager.textBox.SetActive(true);
                //dialogueManager.animator.SetBool("isOpen", true);
                Debug.Log("This is working 2!");
            }
        }
    }
}
