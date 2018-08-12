using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHaser_enemy : MonoBehaviour {

    
    public Transform player;
    
    public float walkingDistance = 10.0f;
    
    public float smoothTime = 10.0f;
    
    private Vector3 smoothVelocity = Vector3.zero;
    
    void Update()
    {
        
        transform.LookAt(player);
       
        float distance = Vector3.Distance(transform.position, player.position);
       
        if (distance < walkingDistance)
        {
            
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
        }
    }
}
