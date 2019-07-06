using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManagerMultiplayer : MonoBehaviour {

    public static GameManagerMultiplayer instance = null;

    [SerializeField]
    private GameObject mazePrefab;

    private bool init = false;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Check for the server to be active and if the initialisation not have been don untiel now 
        if(NetworkServer.active && !init)
        {
            // Instantiate the maze prefab on the server 
            GameObject GOToSpawm = Instantiate(mazePrefab, GameObject.Find("ImageTarget").transform);
            // Trigger the spawn on all clients that are connected and will connect
            NetworkServer.Spawn(GOToSpawm);

            // Get all Renderer from all child objects
            var rendererComponents = GOToSpawm.GetComponentsInChildren<Renderer>(true);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Initialisation done
            init = true;
        }
    }	
}
