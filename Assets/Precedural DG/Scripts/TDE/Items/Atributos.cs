using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Atributos : MonoBehaviour
{
    private int basePower = 100;
    private int baseDest = 100;
    private int baseHP = 100;
    private float baseCritChance;
    private float baseCritDamage;

    public static int power = 100;
    public static int Dest = 100;
    public static int HP = 100;
    public static float CritChance;
    public static float CritDamage;


    void Awake() {
      //  DontDestroyOnLoad(this.gameObject);
    }

    public void Start() {
        power = basePower;
        Dest = baseDest;
        HP = baseHP;
        CritChance = baseCritChance;
        CritDamage = baseCritDamage;
    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            Debug.Log("Power=" + power);
            Debug.Log("Dest=" + Dest);
            Debug.Log("HP=" + HP);
            Debug.Log("CritChance=" + CritChance);
            Debug.Log("CritDamage=" + CritDamage);
        }
        }
    }
