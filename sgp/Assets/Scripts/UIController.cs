using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider[] item_progress;
    HealthController health_controller;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < item_progress.Length; i++)
        {
            item_progress[i].value = 0;
        }

        health_controller = GetComponent<HealthController>();

        OnTapItem(Constants.ItemTypes.Coffee);
    }


    public void OnTapItem(Constants.ItemTypes item_type)
    {
        if (item_type.Equals(Constants.ItemTypes.Coffee))
            {
            item_progress[0].value += 0.1f;
        } 
        else if (item_type.Equals(Constants.ItemTypes.Glass))
            {
            item_progress[1].value += 0.1f;

        }

        health_controller.UpdateHealth(0.1f);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
