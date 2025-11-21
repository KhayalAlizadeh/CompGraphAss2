using UnityEngine;

public class Exit : MonoBehaviour {
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        audioSource.Play();
        Debug.Log("Level Completed!");
    }
}
