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
    bool Enemy_gose_first;
    bool Has_no_effect;
    // gameobjects
    public GameObject Enemy_pokemon;
    [SerializeField] GameObject Battle_canvus;
   // [SerializeField] GameObject Checker_cube; defunked code
    [SerializeField] GameObject Battle_canvus_gubbins;
    [SerializeField] GameObject Opaning_animation;
    public GameObject Player;
    public GameObject Player_pokemon;
    GameObject Player_pokemon_moves_1;
     GameObject Player_pokemon_moves_2;
     GameObject Player_pokemon_moves_3;
     GameObject Player_pokemon_moves_4;
    GameObject Enemy_pokemon_moves_1;
    GameObject Enemy_pokemon_moves_2;
    GameObject Enemy_pokemon_moves_3;
    GameObject Enemy_pokemon_moves_4;
    [SerializeField] GameObject[] Pokemon_Moves_buttons;
    [SerializeField] GameObject[] Pokemon_Moves_buttons_text;
    [SerializeField] GameObject Fake_button_for_battle;

    // transfrom
    [SerializeField] Transform Enemy_Spawn_Condition;
    [SerializeField] Transform Player_Spawn_Condition;

    // floats
    [SerializeField] float Delay = 1f; // dose not need to be a seriaslixed field
    float crit_chanse;
    float Effective;
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
    float stab;
    // player pokemon stats
    string data_path;
    float player_pokemon_ID;    
    float Player_Pokemon_hp;
    float Player_Pokemon_Attack;
    float Player_Pokemon_Defense;
    float Player_Pokemon_spatk;
    float Player_Pokemon_spdef;
    float Player_Pokemon_speed;
    float Player_Pokemon_Levle;
    [SerializeField] float[] Player_Pokemon_iv;
    float Player_Pokemon_Move_power;
    float Player_Pokemon_Move_Accursy;

    //strings
    string Move_type;
    string type_1;
    string type_2;

    //misc    


    public void Battle_Opaning()
    {
        Battle_canvus.SetActive(true);
        if (Spawned_in_pokemon == false)
        {
            string temp;
            // spawns in enemy pokemon and assines its stats
            Enemy_pokemon = Instantiate(Enemy_pokemon, new Vector3(Enemy_Spawn_Condition.position.x, Enemy_Spawn_Condition.position.y, Enemy_Spawn_Condition.position.z), new Quaternion());
            Enemy_pokemon_moves_1 = Enemy_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[1];
            
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
                Player_pokemon_moves_1 = Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[0];
            }
            if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[1] != null)
            {
                Player_pokemon_moves_2 = Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[1];
            }
            if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[2] != null)
            {
                Player_pokemon_moves_3= Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[2];
            }
            if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[3] != null)
            {
                Player_pokemon_moves_4 = Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[3];
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
        if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[0] == null)
        {
            Debug.Log("moves are null");
            Pokemon_Moves_buttons[0].GetComponent<Button>().interactable = false;
        }
        else
        {
            Pokemon_Moves_buttons_text[0].GetComponent<TMP_Text>().text = Player_pokemon_moves_1.name;
            Debug.Log("moves isnt null");
        }

        if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[1] == null)
        {
            Debug.Log("moves are null");
            Pokemon_Moves_buttons[1].GetComponent<Button>().interactable = false;
        }
        else
        {
            Pokemon_Moves_buttons_text[1].GetComponent<TMP_Text>().text = Player_pokemon_moves_2.name;
            Debug.Log("moves isnt null");
        }

        if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[2] == null)
        {
            Debug.Log("moves are null");
            Pokemon_Moves_buttons[2].GetComponent<Button>().interactable = false;
        }
        else
        {
            Pokemon_Moves_buttons_text[2].GetComponent<TMP_Text>().text = Player_pokemon_moves_3.name;
            Debug.Log("moves isnt null");
        }
        if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[3] == null)
        {
            Debug.Log("moves are null");
            Pokemon_Moves_buttons[3].GetComponent<Button>().interactable = false;
        }
        else
        {
            Pokemon_Moves_buttons_text[3].GetComponent<TMP_Text>().text = Player_pokemon_moves_4.name;
            Debug.Log("moves isnt null");
        }
    }

    public void Used_move_1()
    {
        if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[0].GetComponent<PokemonMoveStatsScript>().IS_Attacking_move == true)
        {
            Player_Pokemon_Move_power = Player_pokemon_moves_1.GetComponent<PokemonMoveStatsScript>().Power;
            Player_Pokemon_Move_Accursy = Player_pokemon_moves_1.GetComponent<PokemonMoveStatsScript>().Accuracy;

            Caculate_who_gose_first();
        }
    }

    void Caculate_who_gose_first()
    {
        if(Player_Pokemon_speed != Enemy_Pokemon_speed)
        {
            if(Player_Pokemon_speed >= Enemy_Pokemon_speed)
            {
                Player_gose_first = true;
                Enemy_gose_first = false;
                Player_pokemon_faster();
            }
            else
            {
                Player_gose_first = false;
                Enemy_gose_first = true;
                Enemy_pokemon_faster();
            }
        }
        else
        {
            if (Random.Range(0, 2) == 1)
            {
                Player_gose_first = true;
                Enemy_gose_first = false;
                Player_pokemon_faster();
            }
            else
            {
                Enemy_gose_first = true;
                Player_gose_first = false;
                Enemy_pokemon_faster();
            }
        }
    }

    void Player_pokemon_faster()
    {
        crit_chanse = (Player_Pokemon_speed / 2f);
        if(Random.Range(0, 256) <= crit_chanse)
        {
            crit_chanse = 2f;
        }
        else
        {
            crit_chanse = 1f;
        }
            float damage;
        damage = (((2f * Player_Pokemon_Levle * crit_chanse) /5f) + 2f); // first bracket of formular
        if (Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[0].GetComponent<PokemonMoveStatsScript>().Is_physical)
        {
            damage = damage * Player_Pokemon_Move_power * (Player_Pokemon_Attack / Enemy_Pokemon_Defense);
        }
        else
        {
            damage = damage * Player_Pokemon_Move_power * (Player_Pokemon_spatk / Enemy_Pokemon_spdef);
        }
        damage = (damage / 50f) +2; // second bracket of formular
        Move_type = Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[0].GetComponent<PokemonMoveStatsScript>().Type;
        type_1 = Enemy_pokemon.GetComponent<PokemonHandlerScript>().type_1;
        type_2 = Enemy_pokemon.GetComponent<PokemonHandlerScript>().type_2;
        Is_move_effective();
        stab = 1f;
        if(Move_type == type_1)
        {
            stab = 1.5f;
        }
        if(Move_type == type_2)
        {
            stab = 1.5f;
        }
        damage = damage * stab * Effective;
        damage = damage * (Random.Range(217f, 226f) / 225);
        damage = Mathf.Round(damage);
        Enemy_Pokemon_hp = Enemy_Pokemon_hp - damage;

        if(Player_gose_first == true)
        {
            Enemy_pokemon_faster();
            Player_gose_first = false;
        }
    }
    void Is_move_effective()
    {
        Effective = 1f;

        if(Move_type == "Normal")
        {
            if(type_1 == "Rock") // negative
            {
                if(Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if(Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Rock") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ghost")
            {
                Effective = 0f;
            }
            if (type_2 == "Ghost")
            {
                Effective = 0f;
            }
        }    
        if(Move_type == "Fire")
        {
            if (type_1 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Water") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Water") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Ice")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Ice")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Bug")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Bug")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Rock") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Rock") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Dragon") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Dragon") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Steel")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Steel")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
        }
        if(Move_type == "Water")
        {
            if (type_1 == "Fire")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Fire")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Water") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Water") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Grass") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Grass") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ground")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Ground")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Dragon") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Dragon") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
        }
        if(Move_type == "Electric")
        {
            if (type_1 == "Water")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Water")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Electric") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Electric") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Grass") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Grass") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Flying")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Flying")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Dragon") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Dragon") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ground")
            {
                Effective = 0f;
            }
            if (type_2 == "Ground")
            {
                Effective = 0f;
            }
        }
        if(Move_type == "Grass")
        {
            if (type_1 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Water")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Water")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Grass") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Grass") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ground")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Ground")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Flying") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Flying") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Bug") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Bug") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Dragon") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Dragon") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
        }
        if(Move_type == "Ice")
        {
            if (type_1 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Water") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Water") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Ice") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Ice") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ground")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Ground")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Flying")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Flying")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Dragon")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Dragon")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
        }
        if(Move_type == "Fighting")
        {
            if (type_1 == "Normal")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Normal")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Ice")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Ice")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Flying") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Flying") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Psychic") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Psychic") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Bug") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Bug") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Dark")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Dark")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Steel")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Steel")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Fairy") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fairy") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ghost")
            {
                Effective = 0f;
            }
            if (type_2 == "Ghost")
            {
                Effective = 0f;
            }
        }
        if(Move_type == "Poison")
        {
            if (type_1 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ground") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Ground") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Rock") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Rock") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ghost") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Ghost") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Fairy")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Fairy")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Steel")
            {
                Effective = 0f;
            }
            if (type_2 == "Steel")
            {
                Effective = 0f;
            }
        }
        if(Move_type == "Ground")
        {
            if (type_1 == "Fire")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Fire")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Electric")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Electric")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Grass") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Grass") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Poison")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Poison")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Bug") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Bug") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Steel")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Steel")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Flying")
            {
                Effective = 0f;
            }
            if (type_2 == "Flying")
            {
                Effective = 0f;
            }
        }
        if(Move_type == "Flying")
        {
            if (type_1 == "Electric") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Electric") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Fighting")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Fighting")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Bug")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Bug")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Rock") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Rock") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
        }
        if(Move_type == "Psychic")
        {
            if (type_1 == "Fighting")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Fighting")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Poison")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Poison")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Psychic") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Psychic") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Dark")
            {
                Effective = 0f;
            }
            if (type_2 == "Dark")
            {
                Effective = 0f;
            }
        }
        if(Move_type == "Bug")
        {
            if (type_1 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Grass")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Fighting") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fighting") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Flying") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Flying") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Psychic")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Psychic")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Ghost") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Ghost") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Dark")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Dark")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Fairy") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fairy") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
        }
        if(Move_type == "Rock")
        {
            if (type_1 == "Fire")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Fire")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Ice")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Ice")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Fighting") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fighting") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ground") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Ground") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Flying")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Flying")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Bug")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Bug")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
        }
        if(Move_type == "Ghost")
        {
            if (type_1 == "Psychic")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Psychic")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Ghost")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Ghost")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Dark") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Dark") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Normal")
            {
                Effective = 0f;
            }
            if (type_2 == "Normal")
            {
                Effective = 0f;
            }
        }
        if(Move_type == "Dragon")
        {
            if (type_1 == "Dragon")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Dragon")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ghost")
            {
                Effective = 0f;
            }
            if (type_2 == "Ghost")
            {
                Effective = 0f;
            }
        }
        if(Move_type == "Dark")
        {
            if (type_1 == "Fighting") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fighting") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Psychic")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Psychic")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Ghost")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Ghost")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Dark") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Dark") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Fairy") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fairy") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
        }
        if(Move_type == "Steel")
        {
            if (type_1 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Water") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Water") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Electric") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Electric") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Ice")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Ice")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Rock")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Fairy")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Fairy")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
        }
        if(Move_type == "Fairy")
        {
            if (type_1 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Fire") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Fighting")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Fighting")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Poison") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_1 == "Dragon")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Dragon")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Dark")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_2 == "Dark")
            {
                if (Effective == 0.5f)
                {
                    Effective = 1f;
                }
                if (Effective == 1f)
                {
                    Effective = 2f;
                }
                if (Effective == 2f)
                {
                    Effective = 4f;
                }
            }
            if (type_1 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
            if (type_2 == "Steel") // negative
            {
                if (Effective == 0.5f)
                {
                    Effective = 0.25f;
                }
                if (Effective == 1f)
                {
                    Effective = 0.5f;
                }
                if (Effective == 1.25f)
                {
                    Effective = 1f;
                }
                if (Effective == 1.5f)
                {
                    Effective = 1.25f;
                }
            }
        }
        if(Effective == 0f)
        {
            Has_no_effect = true;
        }
        else
        {
            Has_no_effect = false;
        }
    }

    void Enemy_pokemon_faster()
    {
        crit_chanse = (Enemy_Pokemon_speed / 2f);
        if (Random.Range(0, 256) <= crit_chanse)
        {
            crit_chanse = 2f;
        }
        else
        {
            crit_chanse = 1f;
        }
        float damage;
        damage = (((2f * Enemy_Pokemon_Levle * crit_chanse) / 5f) + 2f); // first bracket of formular
        if (Enemy_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[0].GetComponent<PokemonMoveStatsScript>().Is_physical)
        {
            damage = damage * Enemy_Pokemon_Move_power * (Player_Pokemon_Attack / Enemy_Pokemon_Defense);
        }
        else
        {
            damage = damage * Player_Pokemon_Move_power * (Player_Pokemon_spatk / Enemy_Pokemon_spdef);
        }
        damage = (damage / 50f) + 2; // second bracket of formular
        Move_type = Player_pokemon.GetComponent<PokemonHandlerScript>().Current_known_moves[0].GetComponent<PokemonMoveStatsScript>().Type;
        type_1 = Enemy_pokemon.GetComponent<PokemonHandlerScript>().type_1;
        type_2 = Enemy_pokemon.GetComponent<PokemonHandlerScript>().type_2;
        Is_move_effective();
        stab = 1f;
        if (Move_type == type_1)
        {
            stab = 1.5f;
        }
        if (Move_type == type_2)
        {
            stab = 1.5f;
        }
        damage = damage * stab * Effective;
        damage = damage * (Random.Range(217f, 226f) / 225);
        damage = Mathf.Round(damage);
        Enemy_Pokemon_hp = Enemy_Pokemon_hp - damage;

        if (Player_gose_first == true)
        {
            Enemy_pokemon_faster();
            Player_gose_first = false;
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