using UnityEngine;
using Platformer.Gameplay;
using Platformer.Core;
using Platformer.Mechanics;

public class Bullet : MonoBehaviour
{
    float deltaX = 0f;
    float xPosition;
    float yPosition;
    // Start is called before the first frame update
    void Start()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (deltaX > -17.5f)
        {
            deltaX -= 0.01f;
            transform.position = new Vector3(xPosition + deltaX, yPosition, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("line"))
        //{
        //    Destroy(collision.gameObject);
        //}
        if (collision.gameObject.GetComponent<PlayerController>() != null)
            Simulation.Schedule<PlayerDeath>(0);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
            Simulation.Schedule<PlayerDeath>(0);

        Destroy(gameObject);
    }
}
