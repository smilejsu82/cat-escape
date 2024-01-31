using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClimbCloudGameDirector : MonoBehaviour
{
    [SerializeField] private Text velocityText;
    [SerializeField] private Text isJumpingText;

    public void UpdateVelocityText(Vector2 velocity)
    {
        float velocityX = Mathf.Abs(velocity.x);
        this.velocityText.text = velocityX.ToString();
    }

    public void UpdateIsJumpingText(Vector2 velocity)
    {
        bool isJumping = (Mathf.Abs(velocity.y) == 0) ? false : true;
        this.isJumpingText.text = isJumping.ToString();
    }
}
