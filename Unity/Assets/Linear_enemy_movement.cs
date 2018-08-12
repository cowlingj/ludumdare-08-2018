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
       

        RaycastHit2D wallinfoleft = Physics2D.Raycast(groundDetection.position, Vector2.left, 0.5f);
        RaycastHit2D wallinforight = Physics2D.Raycast(groundDetection.position, Vector2.right, 0.5f);
        if (wallinfoleft.collider == null)
     
        {
          
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
        if (wallinfoleft.collider == null)
     
        {
          
            if (MovingRight == false)
            {
                transform.eulerAngles = new Vector3 (0, -180, 0);
                MovingRight = false;
            }
            else
            { transform.eulerAngles = new Vector3 (0, 0, 0);
                MovingRight = true;
            }
        }

        if (wallinforight.collider == null)

        {

            if (MovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                MovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                MovingRight = true;
            }
        }
    }
}
