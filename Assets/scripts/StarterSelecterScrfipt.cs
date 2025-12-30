using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class StarterSelecterScrfipt : MonoBehaviour
{
    // opaning delay vars
    InputAction InteractAction;
    float Delay = 0f;
    float Delay1 = 0f;
    float alpha = 0f;
    bool turning_off;
    bool fade_delay;
    [SerializeField] float offset;
    [SerializeField] GameObject blackscreen;
    Image blackscreenimage;
    Color blackscreeencolour;
    int pokemon_chosen;    
    
    //main picking pokemon vars
    [SerializeField] GameObject pick_your_pokemon_screen_stuff;
    GameObject hitbox;
    GameObject Player;
    [SerializeField] GameObject[] Pokemon;
    [SerializeField] bool Pokemon_match; // left in for testing
    [SerializeField] bool turn_thing_on; // left in for testing
    [SerializeField] GameObject game_manager;
    int ID;
    [SerializeField] int Pokemon_list_position = 0;
    GameObject our_starter_pokemon;
    [SerializeField] GameObject first_button_selected;
    bool Has_pressed_the_interact_button_once;
    [SerializeField] AudioSource button_sound_effect;
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject are_you_sure_text;
    private void Start()
    {
        InteractAction = InputSystem.actions.FindAction("Interact");
        blackscreenimage = blackscreen.GetComponent<Image>();
        blackscreeencolour.a = alpha;
    }
    private void Update()
    {
        opaning_delay(); // handles the opaning fade of the game and opens the starter selections            
        if (turn_thing_on == true)
        {
            Chose_LeftMost_sarter();                      
            turn_thing_on = false;            
        }
        Sound_manager(); // holds all sounds and code related to sounds
        if (buttons[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Chose pokemon"))
        {
            are_you_sure_text.SetActive(true);
        }
    }

    void Sound_manager()
    {
        if (buttons[0].GetComponent<Animator>().GetBool("Selected"))
        {
            button_sound_effect.Play();
        }
        if (buttons[1].GetComponent<Animator>().GetBool("Selected"))
        {
            button_sound_effect.Play();
        }
        if (buttons[2].GetComponent<Animator>().GetBool("Selected"))
        {
            button_sound_effect.Play();
        }

        if (buttons[0].GetComponent<Animator>().GetBool("Highlighted"))
        {
            button_sound_effect.Play();
        }
        if (buttons[1].GetComponent<Animator>().GetBool("Highlighted"))
        {
            button_sound_effect.Play();
        }
        if (buttons[2].GetComponent<Animator>().GetBool("Highlighted"))
        {
            button_sound_effect.Play();
        }
    }
    void opaning_delay()
    {
        if (blackscreen.activeInHierarchy == true)
        {
            if (Delay <= 0f)
            {
                if (turning_off == false)
                {
                    alpha = alpha + 0.01f;
                    blackscreeencolour.a = alpha;
                    blackscreenimage.color = blackscreeencolour;
                }
                else
                {
                    alpha = alpha - 0.01f;
                    blackscreeencolour.a = alpha;
                    blackscreenimage.color = blackscreeencolour;
                }

                if (blackscreenimage.color.a >= 1f)
                {
                    Delay = 1f;
                    fade_delay = true;
                }
                if (blackscreenimage.color.a == 0f)
                {
                    //turning_off = true;
                }
                Delay = offset;
            }
            else
            {
                Delay = Delay - 2f * Time.deltaTime;
            }

            if (fade_delay == true)
            {
                if (Delay1 <= 0f)
                {
                    turning_off = true;
                    pick_your_pokemon_screen_stuff.SetActive(true);                    
                }
                else
                {
                    Delay1 = Delay1 - 1f * Time.deltaTime;
                }
            }
        }
    }

    public void Chose_LeftMost_sarter()
    {
        pokemon_chosen = 0;
        are_you_sure_left();
    }

    void are_you_sure_left()
    {
        buttons[0].GetComponent<Button>().interactable = false;
        buttons[1].GetComponent<Button>().interactable = false;
        buttons[2].GetComponent<Button>().interactable = false;
        buttons[0].GetComponent<Animator>().SetBool("ChosePokemon", true);
        buttons[1].GetComponent<Animator>().SetBool("MoveDown", true);
        buttons[2].GetComponent<Animator>().SetBool("MoveDown", true);

    }
    void assine_starter()
    {
        // sets up all our infomation
        ID = Random.RandomRange(0, 99999);  
        while (Pokemon[pokemon_chosen].gameObject != game_manager.GetComponent<EveryPokemon>().Pokemon_list[Pokemon_list_position])
        {
            Pokemon_list_position = Pokemon_list_position + 1;
        }        
         if (Pokemon[pokemon_chosen].gameObject == game_manager.GetComponent<EveryPokemon>().Pokemon_list[Pokemon_list_position])
        {
            Pokemon_match = true;
        }
        our_starter_pokemon = Instantiate(Pokemon[pokemon_chosen], new Vector3(1000, 1000, 1000), new Quaternion());
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Levle = 5;
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Pokemon_ID = ID.ToString();
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Genarate_ivs_and_evs();
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Pokemon_list_position = Pokemon_list_position;
        // saves all our infomation
        our_starter_pokemon.GetComponent<PokemonStatsScript>().write_levles();
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Write_ID();
        our_starter_pokemon.GetComponent<PokemonStatsScript>().write_evs_ivs_1();
        Player.GetComponent<PlayerPokemonPartyScript>().Pokemon_list_nuber = Pokemon_list_position;
        Player.GetComponent<PlayerPokemonPartyScript>().set_slot_one();
        Player.GetComponent<PlayerPokemonPartyScript>().Load_slot_one();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag==("Player"))
        {
            if (Has_pressed_the_interact_button_once == false)
            {
                if (InteractAction.IsPressed())
                {
                    blackscreen.SetActive(true);
                    hitbox = other.gameObject;
                    Player = hitbox.GetComponent<HitBotVarHolderscript>().Player;
                    Player.GetComponent<PlayerMovmentScript>().Can_move = false;
                    first_button_selected.GetComponent<Button>().Select();
                    Has_pressed_the_interact_button_once = true;
                    //  party_lengh = Player.GetComponent<PlayerPokemonPartyScript>().pokemon.Length; defunked code
                }
            }
        }
    }
}
