using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Model;
using Platformer.Core;

public class Stone : MonoBehaviour
{
    int count = 4;
    public Sprite stone2;
    public Sprite stone3;
    public Sprite stone4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("line"))
        {
            Destroy(collision.gameObject);
            count--;
        }
        switch (count)
        {
            case 0:
                Destroy(gameObject);
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = stone4;
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = stone3;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = stone2;
                break;
        }
    }
}
