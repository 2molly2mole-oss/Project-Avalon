using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonHandlerScript : MonoBehaviour
{
    int[] move_learnt_by_levle_up_levle;
    GameObject[] move_leart_by_levle;
    int Moves_assined;

    private void Awake()
    {
        while(Moves_assined != move_learnt_by_levle_up_levle.Length)
        {
            Moves_assined = Moves_assined + 1;           
        }
    }
}
