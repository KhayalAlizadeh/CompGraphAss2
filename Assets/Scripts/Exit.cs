using UnityEngine;

public class Exit : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Level Completed!");
    }
}
