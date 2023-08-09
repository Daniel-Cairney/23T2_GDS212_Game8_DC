using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public GameObject canvasPrefab; // Assign the Canvas prefab in the Inspector
    public AudioSource audioSource; // Assign the AudioSource in the Inspector
   // public GameObject objectToDestroy; // Assign the GameObject to destroy in the Inspector

    private Canvas interactionCanvas;
    private bool canvasActive = false;
    private bool canvasVisible = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !canvasActive)
        {
            Debug.Log("TriggerEnter");
            interactionCanvas = Instantiate(canvasPrefab, transform.position, Quaternion.identity).GetComponent<Canvas>();
            canvasActive = true;
            canvasVisible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && canvasActive)
        {
            if (interactionCanvas != null)
            {
                Destroy(interactionCanvas.gameObject);
                canvasActive = false;
                canvasVisible = false;
            }
        }
    }

    private void Update()
    {
        if (canvasVisible && Input.GetKeyDown(KeyCode.E))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }

            //if (objectToDestroy != null)
            //{
              //  Destroy(objectToDestroy);
            //}
        }
    }
}
