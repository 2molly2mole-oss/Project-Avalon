using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using System.IO;

public class PokemonStatsScript : MonoBehaviour
{
    public float Levle;
    public float[] PokemonStats; //stats are (hp 0) (attack 1) (defense 2) (spattack 3) (spdefence 4) (speed 5)
   // public float Iv;
    public float[] iv;
    int all_writtenl;
    [SerializeField] bool test;    
    string data_path;
    string Iv;
    public string Pokemon_ID;
    public string Name;
    public int Pokemon_list_position;
    string temp;
    

    public void Genarate_ivs_and_evs()
    {
        iv[0] = Random.Range(0f, 32f);
        iv[1] = Random.Range(0f, 32f);
        iv[2] = Random.Range(0f, 32f);
        iv[3] = Random.Range(0f, 32f);
        iv[4] = Random.Range(0f, 32f);
        iv[5] = Random.Range(0f, 32f);
    }

    public void Load_all_stats ()
    {
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "Levle" + ".txt";
        temp = File.ReadAllText(Application.dataPath + data_path);
        Levle = float.Parse(temp);
    }

    public void write_levles()
    {
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "Levle" + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, Levle.ToString());
        }        
    }
    public void write_Name()
    {
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "Name" + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, name);
        }
    }
    public void Write_ID()
    {
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "ID" + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, Pokemon_list_position.ToString());
        }
    }
    public void write_evs_ivs_1()
    {
        Iv = "1";
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "Iv" + Iv + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, iv[0].ToString());
        }      
        write_evs_ivs_2();
    }
   void write_evs_ivs_2()
    {
        Iv = "2";
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "Iv" + Iv + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, iv[1].ToString());            
        }      
        write_evs_ivs_3();
    }
    void write_evs_ivs_3()
    {
        Iv = "3";
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "Iv" + Iv + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, iv[2].ToString());
        }
        all_writtenl = all_writtenl + 1;
        write_evs_ivs_4();
    }
    void write_evs_ivs_4()
    {
        Iv = "4";
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "Iv" + Iv + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, iv[3].ToString());
        }
        all_writtenl = all_writtenl + 1;
        write_evs_ivs_5();
    }
    void write_evs_ivs_5()
    {
        Iv = "5";
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "Iv" + Iv + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, iv[4].ToString());
        }
        all_writtenl = all_writtenl + 1;
        write_evs_ivs_6();
    }
    void write_evs_ivs_6()
    {
        Iv = "6";
        data_path = "/Pokemon/SavedPokemonData" + "/" + Pokemon_ID + "Iv" + Iv + ".txt";
        if (!File.Exists(data_path))
        {
            File.WriteAllText(Application.dataPath + data_path, iv[5].ToString());
        }        
    }

    private void Update()
    { // left in for testing
        if (test == true)
        {           
            test = false;            
            write_levles();
        }
    }    
}
