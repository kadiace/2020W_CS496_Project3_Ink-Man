using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkBar : MonoBehaviour
{
    public InkCartridge inkCartridge;

    [HideInInspector]
    public PlayerController playerController;

    public Image meterImage;

    float maxInkCapacity;
    // Start is called before the first frame update
    void Start()
    {
        maxInkCapacity = playerController.maxInkCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            meterImage.fillAmount = inkCartridge.value / maxInkCapacity;
        }
    }
}
