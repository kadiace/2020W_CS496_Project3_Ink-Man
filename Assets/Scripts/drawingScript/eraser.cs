using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eraser : MonoBehaviour
{
    float Maxdistance;
    Vector3 mousePosition;
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            mousePosition = Input.mousePosition;
            mousePosition = Camera.ScreenToWorldPoint(mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, Maxdistance);
            Debug.DrawRay(mousePosition, transform.forward * 10, Color.red, Maxdistance);

            if (hit && hit.transform.gameObject.tag.Equals("line"))
            {
                Destroy(hit.transform.gameObject);
            }
            
        }
    }
}
