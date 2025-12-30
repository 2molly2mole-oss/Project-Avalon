using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandlerScript : MonoBehaviour
{
    // bools
    public bool Battle_Time;
    bool Gubbins_on;
    [SerializeField] bool Spawned_in_pokemon; // dose not need to be a seriaslixed field

    // gameobjects
    public GameObject Enemy_pokemon;
    [SerializeField] GameObject Battle_canvus;
   // [SerializeField] GameObject Checker_cube; defunked code
    [SerializeField] GameObject Battle_canvus_gubbins;
    [SerializeField] GameObject Opaning_animation;
    public GameObject Player;

    // transfrom
    [SerializeField] Transform Enemy_Spawn_Condition; 

    // floats
    [SerializeField] float Delay = 1f; // dose not need to be a seriaslixed field
    float Enemy_Pokemon_hp;
    float Enemy_Pokemon_Attack;
    float Enemy_Pokemon_Defense;
    float Enemy_Pokemon_spatk;
    float Enemy_Pokemon_spdef;
    float Enemy_Pokemon_speed;

    //ints
    public int Enemy_Pokemon_levle;

    public void Battle_Opaning()
    {
        Battle_canvus.SetActive(true);
        if (Spawned_in_pokemon == false)
        {
            // spawns in enemy pokemon and assines its stats
            Instantiate(Enemy_pokemon, new Vector3(Enemy_Spawn_Condition.position.x, Enemy_Spawn_Condition.position.y, Enemy_Spawn_Condition.position.z), new Quaternion());
            Enemy_Pokemon_hp = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[0];
            Enemy_Pokemon_Attack = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[1];
            Enemy_Pokemon_Defense = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[2];
            Enemy_Pokemon_spatk = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[3];
            Enemy_Pokemon_spdef = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[4];
            Enemy_Pokemon_speed = Enemy_pokemon.GetComponent<PokemonStatsScript>().PokemonStats[5];
            Spawned_in_pokemon = true;
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