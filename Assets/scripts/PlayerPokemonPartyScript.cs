using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;
public class PlayerPokemonPartyScript : MonoBehaviour
{
    public GameObject[] pokemon;
    [SerializeField] GameObject Pokemon_list;    
    string data_path;
    public string Pokemon_ID;
    public int Pokemon_list_nuber; 
    [SerializeField] string Show_what_your_saved_as;
    public void set_slot_one()
    {
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "pokemon1" + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, Pokemon_ID.ToString());
        }
    }

   public void Load_slot_one()
    {
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "ID" + ".txt";
        Show_what_your_saved_as = File.ReadAllText(Application.dataPath + data_path); // for testing
        Pokemon_list_nuber = int.Parse(File.ReadAllText(Application.dataPath + data_path));
        pokemon[0] = Pokemon_list.GetComponent<EveryPokemon>().Pokemon_list[Pokemon_list_nuber];
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "pokemon1" + ".txt";        
    }
}
