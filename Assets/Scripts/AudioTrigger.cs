using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource; 

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed && audioSource != null)
        {
            Debug.Log("enter");
            if (audioSource != null)
            {
                audioSource.Play(); 
                hasPlayed = true;
                Destroy(gameObject, audioSource.clip.length);
            }
        }
    }
}

