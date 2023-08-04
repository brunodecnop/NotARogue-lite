using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class ItemExtension
{
	public Health vida;
	public void start()
    {
	 vida = GameObject.Find("Koala").GetComponent<Health>();
	}

	public void TrocaAtributo(InventoryItem item)
	{


		Atributos.power += item.Power;
		Atributos.Dest += item.Magic;
		Atributos.HP += item.HP;
		vida.IncreaseHealth(item.HP);
		Atributos.CritChance += item.CritChance;
		Atributos.CritDamage += item.CritDamage;

		Debug.Log("Power=" + Atributos.power);
		Debug.Log("Dest=" + Atributos.Dest);
		Debug.Log("HP=" + Atributos.HP);
		Debug.Log("CritChance=" + Atributos.CritChance);
		Debug.Log("CritDamage=" + Atributos.CritDamage);

	}

	public void DestrocaAtributo(InventoryItem item)
	{


		Atributos.power -= item.Power;
		Atributos.Dest -= item.Magic;
		Atributos.HP -= item.HP;
		vida.IncreaseHealth(-item.HP);
		Atributos.CritChance -= item.CritChance;
		Atributos.CritDamage -= item.CritDamage;

	}

	public void RandomizaAtributos(InventoryItem item)
	{
		item.Magic = Random.Range(item.DestrezaMin, item.DestrezaMax);
		item.CritChance = Random.Range(item.CritChanceMin, item.CritChanceMax);
		item.CritDamage = Random.Range(item.CritDamageMin, item.CritDamageMax);
		item.HP = Random.Range(item.HPMin, item.HPMax);
	}

}
