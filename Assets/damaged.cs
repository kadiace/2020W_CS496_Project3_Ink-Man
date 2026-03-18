using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damaged : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.CompareTag("line"))
        {
            Destroy(collision.gameObject);
            Animator anim = GetComponentInParent<Animator>();
            anim.SetTrigger("isDamaged");
            anim.SetInteger("life", anim.GetInteger("life")-1);
            Debug.Log(anim.GetInteger("life"));
            
        }
        //else if ()
        //{

        //}
    }
}
