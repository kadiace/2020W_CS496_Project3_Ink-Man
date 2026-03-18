using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public Rigidbody2D triggerBody;
    public GameObject onTriggerEnter;


    void OnTriggerEnter2D(Collider2D other)
    {
        //do not trigger if there's no trigger target object
        if (triggerBody == null) return;

        //only trigger if the triggerBody matches
        var hitRb = other.attachedRigidbody;
        if (hitRb == triggerBody)
        {
            GameObject Bullet = Instantiate(onTriggerEnter, new Vector3(40, -12, 0), Quaternion.identity);
        }
    }

}
