using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    public Vector2 velocity;
    private float mass = .5f, g = -9.8f, Ka = -0.2f;

    void Update()
    {
        transform.position += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;
        velocity+= new Vector2(Ka*velocity.x, mass*g+ Ka * velocity.y) * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Target"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if (col.CompareTag("Obstacle"))
        {
            velocity = -velocity;
        }
        if (col.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
