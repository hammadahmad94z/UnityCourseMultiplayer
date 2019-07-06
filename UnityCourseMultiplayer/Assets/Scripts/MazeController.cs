using UnityEngine;
using UnityEngine.Networking;

public class MazeController : NetworkBehaviour {

    private bool isParentSet = false;
    private Rigidbody playerRb = null;

	// Use this for initialization
	void Update () {
        // Check if the parent is not set yet and we are a remote client (not the server and a client)
        if (!isParentSet && !isServer && isClient)
        {
            // Find the ImageTarget we will set it as the parent of the maze
            GameObject parent = GameObject.FindGameObjectWithTag("ImageTarget");
            if (parent == null)
                return;

            // Set the parent
            transform.SetParent(parent.transform);
            // Set some transform values
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            
            // Toggle the flag
            isParentSet = true;
        }
	}

    // Used by the MultiplayerCustomTrackableEventHandler to show the maze
    internal void Show()
    {
        // Get all renderer of all childs
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);

        // Go throu all renderer
        foreach (var component in rendererComponents)
        {
            // if we are the server we wont show the walls
            if (isServer && component.gameObject.CompareTag("Wall"))
                continue;

            // enable rendering for all other renderer
            component.enabled = true;
        }

        // Get the rigitdbody of the player object
        if (playerRb == null)
            playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

        // If we are the server enable the gravity to controll the player
        // The client will see the movement trough the NetworkTransform and NetworkTransformChild component
        if (isServer)
            playerRb.useGravity = true;
    }

    // Used by the MultiplayerCustomTrackableEventHandler to disable the gravity of the player
    // Hinding the maze is done by the MultiplayerCustomTrackableEventHandler script
    internal void Hide()
    {
        if (playerRb == null)
            playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

        if (isServer)
            playerRb.useGravity = false;
    }
}
