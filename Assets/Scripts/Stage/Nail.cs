using UnityEngine;
using Platformer.Model;
using Platformer.Core;

public class Nail : MonoBehaviour
{
    bool isPlayerPassed = false;
    Transform playerTransform;
    float deltaY = 0f;
    float xPosition;
    float yPosition;
    PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerPassed)
        {
            if (playerTransform.position.x > -9f)
            {
                isPlayerPassed = true;
            }
        }
        else
        {
            if (deltaY < 1.5f)
            {
                deltaY += 0.1f;
                transform.position = new Vector3(xPosition, yPosition + deltaY, 0);
            }
        }
    }
}