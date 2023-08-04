using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAtt : MonoBehaviour
{

    public int DestrezaMin;
    public int DestrezaMax;
    public int Destreza;

    public float CritChanceMin;
    public float CritChanceMax;
    public float CritChance;

    public float CritDamageMin;
    public float CritDamageMax;
    public float CritDamage;

    void Start() {
        Destreza = Random.Range(DestrezaMin, DestrezaMax);
        CritChance = Random.Range(CritChanceMin, CritChanceMax);
        CritDamage = Random.Range(CritDamageMin, CritDamageMax);
    }
}
