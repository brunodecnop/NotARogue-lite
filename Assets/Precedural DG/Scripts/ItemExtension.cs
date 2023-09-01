using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class ItemExtension : InventoryWeapon
{
	public Health vida;

	/*
	/// the possible auto equip modes
	public enum AutoEquipModes { NoAutoEquip, AutoEquip, AutoEquipIfEmptyHanded }

	[Header("Weapon")]
	[MMInformation("Here you need to bind the weapon you want to equip when picking that item.", MMInformationAttribute.InformationType.Info, false)]
	/// the weapon to equip
	[Tooltip("the weapon to equip")]
	public Weapon EquippableWeapon;
	/// how to equip this weapon when picked : not equip it, automatically equip it, or only equip it if no weapon is currently equipped
	[Tooltip("how to equip this weapon when picked : not equip it, automatically equip it, or only equip it if no weapon is currently equipped")]
	public AutoEquipModes AutoEquipMode = AutoEquipModes.NoAutoEquip;
	/// the ID of the CharacterHandleWeapon you want this weapon to be equipped to
	[Tooltip("the ID of the CharacterHandleWeapon you want this weapon to be equipped to")]
	public int HandleWeaponID = 1;
	public int SecondaryHandleWeaponID = 2;
	public int UsedHandleWeaponID;

	*/

	/// <summary>
	/// When we grab the weapon, we equip it
	/// </summary>
	public override bool Equip(string playerID)
	{
		EquipWeapon(EquippableWeapon, playerID);



		TrocaAtributo(this);
		return true;


	}

	/// <summary>
	/// When dropping or unequipping a weapon, we remove it
	/// </summary>
	public override bool UnEquip(string playerID)
	{
		// if this is a currently equipped weapon, we unequip it
		if (this.TargetEquippedInventory(playerID) == null)
		{
			return false;
		}

		if (this.TargetEquippedInventory(playerID).InventoryContains(this.ItemID).Count > 0)
		{
			EquipNullWeapon(playerID);
			//DestrocaAtributo();

		}
		DestrocaAtributo(this);
		return true;
	}

	/// <summary>
	/// Grabs the CharacterHandleWeapon component and sets the weapon
	/// </summary>
	/// <param name="newWeapon">New weapon.</param>
	protected override void EquipWeapon(Weapon newWeapon, string playerID)
	{
		if (EquippableWeapon == null)
		{
			return;
		}
		if (TargetInventory(playerID).Owner == null)
		{
			return;
		}

		Character character = TargetInventory(playerID).Owner.GetComponentInParent<Character>();

		if (character == null)
		{
			return;
		}

		// we equip the weapon to the chosen CharacterHandleWeapon
		CharacterHandleWeapon targetHandleWeapon = null;
		CharacterHandleWeapon[] handleWeapons = character.GetComponentsInChildren<CharacterHandleWeapon>();
		foreach (CharacterHandleWeapon handleWeapon in handleWeapons)
		{
			if (handleWeapon.HandleWeaponID == HandleWeaponID)
			{
				if (handleWeapon.CurrentWeapon == null) targetHandleWeapon = handleWeapon;
				else
				{
					foreach (CharacterHandleWeapon handleWeapon2 in handleWeapons)
					{
						if (handleWeapon2.HandleWeaponID == SecondaryHandleWeaponID)
						{
							targetHandleWeapon = handleWeapon2;
						}
					}
				}
			}
		}

		if (targetHandleWeapon != null)
		{
			targetHandleWeapon.ChangeWeapon(newWeapon, this.ItemID);
			UsedHandleWeaponID = targetHandleWeapon.HandleWeaponID;

		}
	}

	protected override void EquipNullWeapon(string playerID)
	{
		if (EquippableWeapon == null)
		{
			return;
		}
		if (TargetInventory(playerID).Owner == null)
		{
			return;
		}

		Character character = TargetInventory(playerID).Owner.GetComponentInParent<Character>();

		if (character == null)
		{
			return;
		}

		// we equip the weapon to the chosen CharacterHandleWeapon
		CharacterHandleWeapon targetHandleWeapon = null;
		CharacterHandleWeapon[] handleWeapons = character.GetComponentsInChildren<CharacterHandleWeapon>();
		foreach (CharacterHandleWeapon handleWeapon in handleWeapons)
		{
			if (handleWeapon.HandleWeaponID == UsedHandleWeaponID)
			{
				targetHandleWeapon = handleWeapon;

			}
		}

		if (targetHandleWeapon != null)
		{
			targetHandleWeapon.ChangeWeapon(null, this.ItemID);
		}
	}
	public void Awake()
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