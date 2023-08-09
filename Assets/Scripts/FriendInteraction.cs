using UnityEngine;

public class FriendInteraction : MonoBehaviour
{
    public GameObject canvasPrefab; 
    public AudioSource audioSource; 
    public GameObject objectToDestroy;
    public GameObject objectToDestroy2;

    private Canvas interactionCanvas;
    private bool canvasActive = false;
    private bool canvasVisible = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !canvasActive)
        {
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

            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
                Destroy(objectToDestroy2);
            }
        }
    }
}
