using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModifierAreas : MonoBehaviour
{
    public Areas area;

   public enum Areas
    {
        gravity,
        flip,
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player.instance.gameObject)
        {
            if (area == Areas.flip)
                FlipPlayer();
            else if (area == Areas.gravity)
                ChangeGravity();
        }
    }


    public void FlipPlayer()
    {
        if(Player.instance.movementModified == true)
        {
            Player.instance.gravity = 15f;
            Player.instance.transform.Rotate(new Vector3(0, 0, -180));
            Player.instance.movementModified = false;
        }else
        {
            Player.instance.transform.Rotate(new Vector3(0, 0, 180));
            Player.instance.gravity = -15f;
            Player.instance.movementModified = true;
        }
    }

    public void ChangeGravity()
    {
        if (Player.instance.movementModified)
        {
            Player.instance.gravity = 15f;
            Player.instance.movementModified = false;
        }
        else
        {
            Player.instance.gravity = 2f;
            Player.instance.movementModified = true;
        }
    }
}
