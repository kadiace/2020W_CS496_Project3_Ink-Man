using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlower : MonoBehaviour
{

    public bool timeToggle;

    public float defaultTimescale;
    public float slowTimescale;

    public float defaultFixedDeltaTime;

    public List<Color> colorList;
    public Renderer[] allRenderer;

    
    // Start is called before the first frame update
    void Start()
    {
        timeToggle = false;
        defaultTimescale = 1f;
        slowTimescale = 0.05f;
        defaultFixedDeltaTime = 0.02f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            

            if (!timeToggle)
            {
                allRenderer = FindObjectsOfType<Renderer>();
                foreach (Renderer renderer in allRenderer)
                {
                   
                    colorList.Add(renderer.material.GetColor("_Color"));
                    renderer.material.SetColor("_Color", Color.grey);
                }
            }
            else
            {
                for (var i = 0; i < allRenderer.Length; i++)
                {
                    if (allRenderer[i] != null)
                    {
                        allRenderer[i].material.SetColor("_Color", colorList[i]);
                    }
                    
                }
                colorList.Clear();
            }
                

            timeToggle = !timeToggle;
            Time.timeScale = timeToggle ? slowTimescale : defaultTimescale;
            Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;

            

            
        }
    }
}
