using UnityEngine;
using Aryzon;

public class StartAryzon : MonoBehaviour {

    private void Start()
    {
        // On Awake start the Aryzon Mode
        GetComponent<AryzonTracking>().StartAryzonMode();    
    }
}
