using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    public Vector2 velocity;
    private float mass = .5f, g = -9.8f, Ka = -0.2f;
    private void Start()
    {
        
    }
    void Update()
    {
        transform.position += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;
        velocity+= new Vector2(Ka*velocity.x, mass*g+ Ka * velocity.y) * Time.deltaTime;
    }

}
