using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Noise");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
