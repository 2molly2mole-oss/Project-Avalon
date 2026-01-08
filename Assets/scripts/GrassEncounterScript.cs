using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassEncounterScript : MonoBehaviour
{
    int Encounter_rate;
    bool Has_encountered;
    [SerializeField] GameObject[] Encouter_pool;
    BattleHandlerScript BHS;
    [SerializeField] int Minimun_levle_range;
    [SerializeField] int Maximum_levle_range;
    float levle;
    GameObject Player;

    private void Update()
    {
        if(Has_encountered == true)
        {
            string temp;
            BHS.Reset_opaning();
            BHS.Enemy_pokemon = Encouter_pool[Random.Range(0, Encouter_pool.Length)];
            levle = Random.Range(Minimun_levle_range, Maximum_levle_range);
            levle = Mathf.Round(levle);
            BHS.Enemy_Pokemon_Levle = levle;
            BHS.Battle_Opaning();
            Debug.Log("PlayerFound");
            Has_encountered = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Encounter_rate = Random.Range(0, 100);
        if(Encounter_rate <= 35)
        {
            BHS=other.gameObject.GetComponent<BattleHandlerScript>();
            Has_encountered = true;
            Player = other.gameObject;
        }
    }
}
