using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear_enemy_movement : MonoBehaviour {
    
 public float speed;
    public float distance;
 

    private bool MovingRight = true;

    public Transform groundDetection;


    void Update(){

        transform.Translate(Vector2.right * speed * Time.deltaTime);
       

        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if(groundinfo.collider == null)
     
        {
         //   Debug.Log("oi moron something's broken go fix it"); 
            if (MovingRight == true)
            {
                transform.eulerAngles = new Vector3 (0, -180, 0);
                MovingRight = false;
            }
            else
            { transform.eulerAngles = new Vector3 (0, 0, 0);
                MovingRight = true;
            }
        }
	}
}
