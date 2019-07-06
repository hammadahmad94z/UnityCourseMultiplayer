using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Constants.ItemTypes item_type;
    private UIController controller;

    // Start is called before the first frame update
    void Start()
    {
        //Find in heirarchy. Correct this.
        controller = GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTap()
    {
        controller.OnTapItem(item_type);
    }
}
