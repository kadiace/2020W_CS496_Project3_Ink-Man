using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    float deltaY = 2.7f;
    GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.FindGameObjectWithTag("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(21.7f, deltaY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (deltaY > 2.4f)
        {
            deltaY -= 0.1f;
            if (deltaY <= 2.5f)
            {
                wall.SetActive(false);
            }
        }
    }
}
