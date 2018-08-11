using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

 public float speed;
 

    private bool MovingRight = true;

    public transform WallDetection;

    void update() {

        transform.translate(vector2.right * speed * time.deltatime);

        RaycastHit2D WallInfo = Physics2D.Raycast(WallDetection.position, Vector2.right, 2f);
        if(WallInfo.collider == true)
        {
            if (MovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                MovingRight = false;
            }
            else
            { transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }
        }
	}
}
