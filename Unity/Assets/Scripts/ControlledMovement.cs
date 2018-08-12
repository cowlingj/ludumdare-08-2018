using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class ControlledMovement : Movement {

  public float inputThreshold = 0.01f;
  public int jumpsBeforeLanding = 1;
  
  private int jumps = 0;
  private bool isJumping = false;

  void FixedUpdate() {

    float x = CrossPlatformInputManager.GetAxis("Horizontal");
    float y = CrossPlatformInputManager.GetAxis("Vertical");

    if (Math.Abs(x) > inputThreshold) {
      move(x, 0);
    }

    if (y <= inputThreshold) {
      isJumping = false;
    }

    if (jumps < jumpsBeforeLanding && !isJumping && y > inputThreshold) {
      Debug.Log("jump: " + jumps);
      isJumping = true;
      jumps++;
      jump(()=>{
          return CrossPlatformInputManager.GetAxis("Vertical") > inputThreshold;
        }, ()=>{
          land(()=>{
            //Debug.Log("landed");
            isJumping = false;
            jumps = 0;
          });
        });
    }

  }

}