using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isDragged = false;
    private int iterator = 0;
    public Rigidbody2D playerRigidBody2D;
    public Rigidbody2D hook;
    public SpringJoint2D spring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragged)
        {
            playerRigidBody2D.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (iterator == 1)
        {
            if (returnsToDefault())
            {
                spring.enabled = false;
                iterator = 0;
            }
        }
        
        
    }

    private void OnMouseDown()
    {
        isDragged = true;
        playerRigidBody2D.isKinematic = true;
        iterator = 1;
    }

    private void OnMouseUp()
    {   
        isDragged = false;
        playerRigidBody2D.isKinematic = false;
    }

    private bool returnsToDefault()
    {
        if(playerRigidBody2D.position.x > hook.position.x)
        {
            Debug.Log("Player: " + playerRigidBody2D.position.x);
            Debug.Log("Hook: " + hook.position.x);
            return true;
        }
        return false;
    }

}
