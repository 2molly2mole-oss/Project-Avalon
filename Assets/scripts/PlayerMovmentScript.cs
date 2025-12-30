using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovmentScript : MonoBehaviour
{
    InputAction moveFowardAction;
    InputAction moveLeftAction;
    InputAction moveRightAction;
    InputAction moveDownAction;
    InputAction moveSprintAction;
    //  [SerializeField] float Delay = 1f; defunked
    public bool Can_move;
    [SerializeField] GameObject Player;
    
    float Player_offset = -0.48f;
    private void Start()
    {
        moveFowardAction = InputSystem.actions.FindAction("MoveFoward");
        moveLeftAction = InputSystem.actions.FindAction("MoveLeft");
        moveRightAction = InputSystem.actions.FindAction("MoveRight");
        moveDownAction = InputSystem.actions.FindAction("MoveDown");
        moveSprintAction = InputSystem.actions.FindAction("Sprint");
    }
    private void Update()
    {
        if (Can_move == true)
        {
            Movment_handler();
        }
    }

    void Movment_handler()
    {
        if (moveFowardAction.IsPressed())
        {
            Player.GetComponent<Animator>().SetBool("MoveFoward", true);         
        }
        else
        {
            Player.GetComponent<Animator>().SetBool("MoveFoward", false);
        }

        if (moveLeftAction.IsPressed())
        {
            Player.GetComponent<Animator>().SetBool("MoveLeft", true);           
        }
        else
        {
            Player.GetComponent<Animator>().SetBool("MoveLeft", false);
        }

        if (moveRightAction.IsPressed())
        {
            Player.GetComponent<Animator>().SetBool("MoveRight", true);            
        }
        else
        {
            Player.GetComponent<Animator>().SetBool("MoveRight", false);
        }

        if (moveDownAction.IsPressed())
        {
            Player.GetComponent<Animator>().SetBool("MoveDown", true);           
        }
        else
        {
            Player.GetComponent<Animator>().SetBool("MoveDown", false);
        }

        if(moveSprintAction.IsPressed())
        {
            Player.GetComponent<Animator>().speed = 4;
        }
        else
        {
            Player.GetComponent<Animator>().speed = 2;
        }

        if (Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Defult state"))
        {
            int x;
            int y;
            float z;

            x = Mathf.RoundToInt(Player.transform.position.x);
            y = Mathf.RoundToInt(Player.transform.position.y);
            z = Mathf.RoundToInt(Player.transform.position.z);
            z = z + Player_offset;
            Player.transform.position = new Vector3(x, y, z);
        }

     
    }
    void defunked_code()
    {
        // Vector2 moveValue = moveFowardAction.ReadValue<Vector2>(); DEFUNKED CODE
        /* 
         * if (moveFowardAction.IsPressed() & moveLeftAction.IsPressed())
        {
            Player.GetComponent<Animator>().SetBool("MoveFoward", false);
            Player.GetComponent<Animator>().SetBool("MoveLeft", false);
            Player.GetComponent<Animator>().SetBool("MoveFowardLeft", true);          
        }
        else
        {
            Player.GetComponent<Animator>().SetBool("MoveFowardLeft", false);
        }
        */
        /*  if (!moveFowardAction.IsPressed() & !moveLeftAction.IsPressed() & !moveRightAction.IsPressed() & !moveDownAction.IsPressed())
       {
           if (checker_cube.activeInHierarchy)
           {
               if (Delay <= 0f)
               {
                   int x;
                   int y;
                   float z;

                   x = Mathf.RoundToInt(Player.transform.position.x);
                   y = Mathf.RoundToInt(Player.transform.position.y);
                   z = Mathf.RoundToInt(Player.transform.position.z);
                   z = z + -0.192f;
                   Player.transform.position = new Vector3(x, y, z);
                   checker_cube.SetActive(false);

               }
               else
               {
                   Delay = Delay - 0.8f * Time.deltaTime;
               }
           }
       }

       if (checker_cube.activeInHierarchy)
       {
           if (Delay <= 0f)
           {
               int x;
               int y;
               float z;

               x = Mathf.RoundToInt(Player.transform.position.x);
               y = Mathf.RoundToInt(Player.transform.position.y);
               z = Mathf.RoundToInt(Player.transform.position.z);
               z = z + -0.192f;
               Player.transform.position = new Vector3(x, y, z);
               checker_cube.SetActive(false);

           }
           else
           {
               Delay = Delay - 0.8f * Time.deltaTime;
           }
       }
     */
    }
}
