using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEditor.Rendering.LookDev;

public class KeyBoardhandlerScript : MonoBehaviour
{
    [SerializeField] string key;
    [SerializeField] bool is_delete_key;
    [SerializeField] bool is_Shift_key;
    [SerializeField] bool shift_is_pressed;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject lower_case_letters;
    [SerializeField] GameObject upper_case_letters;
    GameObject game_manager;
    InputAction shift_upper;

    private void Start()
    {
       shift_upper  = InputSystem.actions.FindAction("Sprint");
       game_manager = GameObject.FindWithTag("GameManager");
    }
    public void Key_pressed()
   {
        string temp;
        if (is_delete_key == false)
        {
            inputField.text += key;
        }
        if(is_delete_key == true)
        {
            temp = inputField.text;
            inputField.text = temp.Remove(temp.Length - 1);
        }
        if (is_Shift_key == true)
        {
            shift_is_pressed = !shift_is_pressed;
        }
   }
    private void Update()
    {
        if (is_Shift_key)
        {
            if (shift_upper.IsPressed())
            {
                shift_is_pressed = true;
            }           
            if (shift_is_pressed == true)
            {
                upper_case_letters.SetActive(true);
                lower_case_letters.SetActive(false);
            }
            else
            {
                upper_case_letters.SetActive(false);
                lower_case_letters.SetActive(true);
            }           
        }

        if (this.GetComponent<Animator>().GetBool("Selected"))
        {
           game_manager.GetComponent<AudioSource>().Play();
        }

        if (this.GetComponent<Animator>().GetBool("Highlighted"))
        {
            game_manager.GetComponent<AudioSource>().Play();
        }
    }
}
