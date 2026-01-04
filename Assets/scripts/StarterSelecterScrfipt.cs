using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class StarterSelecterScrfipt : MonoBehaviour
{
    // opaning delay vars
    InputAction InteractAction;
    bool Fade_screen;
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
    [SerializeField] bool turn_thing_on; // left in for testing
    [SerializeField] GameObject game_manager;
    [SerializeField] int ID;// left in for testing
    [SerializeField] int Pokemon_list_position = 0;
    GameObject our_starter_pokemon;
    [SerializeField] GameObject first_button_selected;
    bool Has_pressed_the_interact_button_once;
    [SerializeField] AudioSource button_sound_effect;
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject are_you_sure_text;
    [SerializeField] GameObject want_to_name_your_pokemon_stuff;
    [SerializeField] GameObject name_your_pokemon_stuff;
    [SerializeField] GameObject second_fake_button_needed;
    [SerializeField] TMP_InputField name_box;
    [SerializeField] GameObject[] Pokeballs;
    string Pokemon_name;
    bool All_done;
    bool set_screen_to_fade;
    [SerializeField] GameObject[] moves_leftmostpokemon_can_learn;
    private void Start()
    {
        InteractAction = InputSystem.actions.FindAction("Interact");
        blackscreenimage = blackscreen.GetComponent<Image>();
        blackscreeencolour.a = alpha;
    }
    private void Update()
    {
        opaning_delay(); // handles the opaning fade of the game and opens the starter selections
        closing_delay();
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
        if (All_done == false)
        {
            if (Fade_screen == true)
            {
                if (set_screen_to_fade == false)
                {
                    game_manager.GetComponent<FadeScreenHandlerScript>().Start_delay();
                    set_screen_to_fade = true;
                }
                Fade_screen = false;
            }
            if (game_manager.GetComponent<FadeScreenHandlerScript>().Screen_is_hid == true)
            {
                pick_your_pokemon_screen_stuff.SetActive(true);
            }
        }
    }
    void closing_delay()
    {
        if (All_done == true)
        {
            if (Fade_screen == true)
            {
                if (set_screen_to_fade == false)
                {
                    game_manager.GetComponent<FadeScreenHandlerScript>().Start_delay();
                    set_screen_to_fade = true;                   
                }
            }
            if (game_manager.GetComponent<FadeScreenHandlerScript>().Screen_is_hid == true)
            {
                Destroy(pick_your_pokemon_screen_stuff);
                Destroy(this.gameObject.GetComponent<StarterSelecterScrfipt>());
                All_done = false;
                Debug.Log("test");
                Player.GetComponent<PlayerMovmentScript>().Can_move = true;
            }
        }
    }

    public void Chose_LeftMost_sarter()
    {
        pokemon_chosen = 0;
        are_you_sure_left();
        Pokeballs[0].SetActive(false);
    }

    void are_you_sure_left()
    {
        buttons[0].GetComponent<Button>().interactable = false;
        buttons[1].GetComponent<Button>().interactable = false;
        buttons[2].GetComponent<Button>().interactable = false;
        buttons[0].GetComponent<Animator>().SetBool("ChosePokemon", true);
        buttons[1].GetComponent<Animator>().SetBool("MoveDown", true);
        buttons[2].GetComponent<Animator>().SetBool("MoveDown", true);
        second_fake_button_needed.GetComponent<Button>().Select();
        are_you_sure_text.SetActive(false);
    }

    public void Want_to_Name_you_pokemon()
    {
        want_to_name_your_pokemon_stuff.SetActive(true);
    }

    public void Name_you_pokemon()
    {        
        get_name_from_Pokemon();
        name_your_pokemon_stuff.SetActive(true);
    }
    void get_name_from_Pokemon()
    {
        name_box.text = Pokemon[pokemon_chosen].name.ToString();
    }

    public void save_pokemon_name()
    {
        Pokemon_name = name_box.text;
        assine_starter();
    }
    void assine_starter()
    {
        // sets up all our infomation
        ID = Random.RandomRange(0, 99999);  
        while (Pokemon[pokemon_chosen].gameObject != game_manager.GetComponent<EveryPokemon>().Pokemon_list[Pokemon_list_position])
        {
            Pokemon_list_position = Pokemon_list_position + 1;
        }   
        
        our_starter_pokemon = Instantiate(Pokemon[pokemon_chosen], new Vector3(1000, 1000, 1000), new Quaternion());
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Levle = 5;
        our_starter_pokemon.GetComponent<PokemonStatsScript>().name = Pokemon_name;
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Pokemon_ID = ID.ToString();
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Genarate_ivs_and_evs();
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Pokemon_list_position = Pokemon_list_position;
        // saves all our infomation
        our_starter_pokemon.GetComponent<PokemonStatsScript>().write_levles();
        our_starter_pokemon.GetComponent<PokemonStatsScript>().Write_ID();
        our_starter_pokemon.GetComponent<PokemonStatsScript>().write_evs_ivs_1();
        our_starter_pokemon.GetComponent<PokemonStatsScript>().write_Name();
        Player.GetComponent<PlayerPokemonPartyScript>().Pokemon_list_nuber = Pokemon_list_position;
        Player.GetComponent<PlayerPokemonPartyScript>().Pokemon_ID = ID.ToString();
        Player.GetComponent<PlayerPokemonPartyScript>().set_slot_one();
        Player.GetComponent<PlayerPokemonPartyScript>().Load_slot_one();        
        turning_off = false;
        Fade_screen = true;
        set_screen_to_fade = false;
        All_done = true;       
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag==("Player"))
        {
            if (Has_pressed_the_interact_button_once == false)
            {
                if (InteractAction.IsPressed())
                {           
                    Fade_screen = true;                    
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
