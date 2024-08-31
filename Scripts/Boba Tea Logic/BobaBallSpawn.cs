using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaBallSpawn : MonoBehaviour
{
    private float randomNumber;
    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        SetGravity();
        SetLocalTransform();
    }
    private void SetGravity()
    {
        rigidbody2D.gravityScale = Getnumber();
    }
    private void SetLocalTransform()
    {
        transform.localScale = new Vector3(Getnumber(), Getnumber(), 1);
    }
    private float Getnumber()
    {
        //Get a random nubmer.
        randomNumber = Random.Range(.7f, 1.3f);
        return randomNumber;
    }
}
