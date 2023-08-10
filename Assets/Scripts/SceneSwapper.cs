using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper: MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource fallingSound;
    public GameObject canvasPrefab; // Assign the Canvas prefab in the Inspector
    public string sceneToLoad; // Assign the scene name to load in the Inspector

    private bool hasPlayed = false;
    private bool canvasInstantiated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed && audioSource != null)
        {
            Debug.Log("enter");
            if (audioSource != null)
            {
                audioSource.Play();
                hasPlayed = true;
                Invoke(nameof(InstantiateCanvas), audioSource.clip.length);
            }
        }
    }

    private void InstantiateCanvas()
    {
        fallingSound.Play();
        if (!canvasInstantiated)
        {
            
            Instantiate(canvasPrefab, transform.position, Quaternion.identity);
            canvasInstantiated = true;
            Invoke(nameof(LoadScene), 5f);
            
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
