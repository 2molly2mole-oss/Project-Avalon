using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class BattleHandlerScript : MonoBehaviour
{
    // bools
    public bool Battle_Time;
    bool Gubbins_on;
    [SerializeField] bool Spawned_in_pokemon; // dose not need to be a seriaslixed field
    bool Player_gose_first;

    // gameobjects
    public GameObject Enemy_pokemon;
    [SerializeField] GameObject Battle_canvus;
   // [SerializeField] GameObject Checker_cube; defunked code
    [SerializeField] GameObject Battle_canvus_gubbins;
    [SerializeField] GameObject Opaning_animation;
    public GameObject Player;
    [SerializeField] GameObject[] Player_pokemon_moves;
    GameObject[] Enemy_pokemon_moves;
    [SerializeField] GameObject[] Pokemon_Moves_buttons;
    [SerializeField] GameObject[] Pokemon_Moves_buttons_text;
    [SerializeField] GameObject Fake_button_for_battle;

    // transfrom
    [SerializeField] Transform Enemy_Spawn_Condition;
    [SerializeField] Transform Player_Spawn_Condition;

    // floats
    [SerializeField] float Delay = 1f; // dose not need to be a seriaslixed field
    // enemy pokemon stats
    float Enemy_Pokemon_hp;
    float Enemy_Pokemon_Attack;
    float Enemy_Pokemon_Defense;
    float Enemy_Pokemon_spatk;
    float Enemy_Pokemon_spdef;
    float Enemy_Pokemon_speed;
    public float Enemy_Pokemon_Levle;
    [SerializeField] float[] Enemy_Pokemon_iv;
    float Enemy_Pokemon_Move_power;
    float Enemy_Pokemon_Move_Accursy;
    // player pokemon stats
    string data_path;
    float player_pokemon_ID;
    GameObject Player_pokemon;
    float Player_Pokemon_hp;
    float Player_Pokemon_Attack;
    float Player_Pokemon_Defense;
    float Player_Pokemon_spatk;
    float Player_Pokemon_spdef;
    float Player_Pokemon_speed;
    float Player_Pokemon_Levle;
    [SerializeField] float[] Player_Pokemon_iv;

    //misc    


    public void Battle_Opaning()
    {
        Battle_canvus.SetActive(true);
        if (Spawned_in_pokemon == false)
        {
            string temp;
            // spawns in enemy pokemon and assines its stats
            Enemy_pokemon = Instantiate(Enemy_pokemon, new Vector3(Enemy_Spawn_Condition.position.x, Enemy_Spawn_Condition.position.y, Enemy_Spawn_Condition.position.z), new Quaternion());
            Enemy_pokemon_moves = Enemy_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves;
            Enemy_Pokemon_hp = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[0];
            Enemy_Pokemon_Attack = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[1];
            Enemy_Pokemon_Defense = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[2];
            Enemy_Pokemon_spatk = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[3];
            Enemy_Pokemon_spdef = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[4];
            Enemy_Pokemon_speed = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[5];
            Enemy_Pokemon_iv[0] = Random.Range(0f, 32f);
            Enemy_Pokemon_iv[0] = Mathf.Round(Enemy_Pokemon_iv[0]);
            Enemy_Pokemon_iv[1] = Random.Range(0f, 32f);
            Enemy_Pokemon_iv[1] = Mathf.Round(Enemy_Pokemon_iv[1]);
            Enemy_Pokemon_iv[2] = Random.Range(0f, 32f);
            Enemy_Pokemon_iv[2] = Mathf.Round(Enemy_Pokemon_iv[2]);
            Enemy_Pokemon_iv[3] = Random.Range(0f, 32f);
            Enemy_Pokemon_iv[3] = Mathf.Round(Enemy_Pokemon_iv[3]);
            Enemy_Pokemon_iv[4] = Random.Range(0f, 32f);
            Enemy_Pokemon_iv[4] = Mathf.Round(Enemy_Pokemon_iv[4]);
            Enemy_Pokemon_iv[5] = Random.Range(0f, 32f);
            Enemy_Pokemon_iv[5] = Mathf.Round(Enemy_Pokemon_iv[5]);
            // spawn in player pokemon stats
            Player.GetComponent<PlayerPokemonPartyScript>().Load_slot_one();
            Player_pokemon = Player.GetComponent<PlayerPokemonPartyScript>().pokemon[0];            
            Player_pokemon = Instantiate(Player_pokemon, new Vector3(Player_Spawn_Condition.position.x, Player_Spawn_Condition.position.y, Player_Spawn_Condition.position.z), new Quaternion());
            if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[0] != null)
            {
                Player_pokemon_moves[0] = Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[0];
            }
            if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[1] != null)
            {
                Player_pokemon_moves[1] = Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[1];
            }
            if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[2] != null)
            {
                Player_pokemon_moves[2] = Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[2];
            }
            if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[3] != null)
            {
                Player_pokemon_moves[3] = Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[3];
            }
            Player_Pokemon_hp = Player_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[0];
            Player_Pokemon_Attack = Player_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[1];
            Player_Pokemon_Defense = Player_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[2];
            Player_Pokemon_spatk = Player_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[3];
            Player_Pokemon_spdef = Player_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[4];
            Player_Pokemon_speed = Player_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[5];            
            player_pokemon_ID = float.Parse(Player.GetComponent<PlayerPokemonPartyScript>().Pokemon_ID);
            data_path = "/Pokemon/SavedPokemonData" + "/" + player_pokemon_ID.ToString() + "Iv1" + ".txt";
            temp = File.ReadAllText(Application.dataPath + data_path);
            Player_Pokemon_iv[0] = float.Parse(temp);
            data_path = "/Pokemon/SavedPokemonData" + "/" + player_pokemon_ID.ToString() + "Iv2" + ".txt";
            temp = File.ReadAllText(Application.dataPath + data_path);
            Player_Pokemon_iv[1] = float.Parse(temp);
            data_path = "/Pokemon/SavedPokemonData" + "/" + player_pokemon_ID.ToString() + "Iv3" + ".txt";
            temp = File.ReadAllText(Application.dataPath + data_path);
            Player_Pokemon_iv[2] = float.Parse(temp);
            data_path = "/Pokemon/SavedPokemonData" + "/" + player_pokemon_ID.ToString() + "Iv4" + ".txt";
            temp = File.ReadAllText(Application.dataPath + data_path);
            Player_Pokemon_iv[3] = float.Parse(temp);
            Spawned_in_pokemon = true;
            data_path = "/Pokemon/SavedPokemonData" + "/" + player_pokemon_ID.ToString() + "Iv5" + ".txt";
            temp = File.ReadAllText(Application.dataPath + data_path);
            Player_Pokemon_iv[4] = float.Parse(temp);
            data_path = "/Pokemon/SavedPokemonData" + "/" + player_pokemon_ID.ToString() + "Iv6" + ".txt";
            temp = File.ReadAllText(Application.dataPath + data_path);
            Player_Pokemon_iv[5] = float.Parse(temp);
            Set_up_pokemon_moves();
        }
    }
    void Set_up_pokemon_moves()
    {
        Fake_button_for_battle.GetComponent<Button>().Select();
        if (Player_pokemon_moves[0].GetComponent<PokemonHandlerScript>().Current_known_moves[0] = null)
        {
            Debug.Log("moves are null");
        }
        else
        {
            Pokemon_Moves_buttons_text[0].GetComponent<TMP_Text>().text = Player_pokemon_moves[0].name;
        }
    }

    public void Used_move_1()
    {

    }

    void Caculate_who_gose_first()
    {
        if(Player_Pokemon_speed != Enemy_Pokemon_speed)
        {
            if(Player_Pokemon_speed >= Enemy_Pokemon_speed)
            {

            }
        }
        else
        {
            if (Random.Range(0, 2) == 1)
            {
                Player_gose_first = true;
            }
        }
    }

    private void Update()
    {       
        if (Battle_canvus.activeInHierarchy)
        {
            if (Delay <= 0f)
            {
                if (Gubbins_on == false)
                {
                    Battle_canvus_gubbins.SetActive(true);
                    Gubbins_on = false;
                }
            }
            else
            {
                Delay = Delay - 0.7f * Time.deltaTime;
            }
        }        
    }

    public void Reset_opaning()
    {
        Gubbins_on = false ;
        Enemy_pokemon = null ;
        Spawned_in_pokemon=false ;
    }
}