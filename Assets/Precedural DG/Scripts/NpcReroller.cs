using MoreMountains.InventoryEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcReroller : MonoBehaviour
{
    public InventoryItem[] List;
    public Button[] buttons;
    public GameObject withItem;
    public GameObject NoItem;
    Inventory playerInventory;
    Inventory WeaponInventory1;
    Inventory WeaponInventory2;
    Inventory HelmetInventory;
    Inventory ChestInventory;
    Inventory BootsInventory;
    public int money;
    public GameObject player;
    public GameObject canvas;
    private bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        playerInventory = Inventory.FindInventory("MainInventory", "Player1");
        WeaponInventory1 = Inventory.FindInventory("Ranged Weapon Inventory", "Player1");
        WeaponInventory2 = Inventory.FindInventory("Ranged Weapon Inventory 2", "Player1");
        HelmetInventory = Inventory.FindInventory("Helmet Inventory", "Player1");
        ChestInventory = Inventory.FindInventory("Armor Inventory", "Player1");
        BootsInventory = Inventory.FindInventory("Boots Inventory", "Player1");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isOpen && Input.GetKeyDown("e"))
        {
            CloseShop();
        }
    }

    void CloseShop()
    {
        if (canvas.gameObject.activeInHierarchy)
        {
            withItem.SetActive(true);
            NoItem.SetActive(false);
            foreach (Button button in buttons)
            {
                if (button.gameObject.activeInHierarchy)
                {
                    button.GetComponentInChildren<Text>().text = $"";
                    button.onClick.RemoveAllListeners();
                    button.gameObject.SetActive(false);
                }
            }

            canvas.gameObject.SetActive(false);
            if (!canvas.gameObject.activeInHierarchy)
                TopDownEngineEvent.Trigger(TopDownEngineEventTypes.TogglePause, player.GetComponent<Character>());
            isOpen = false;

        }
    }

    public void Main()
    {
        if (!isOpen)
        {
            StartCoroutine(OpenShop());
        }
        else if (isOpen)
        {
            CloseShop();
        }
    }

    public IEnumerator OpenShop()
    {
        yield return new WaitUntil(() => Input.GetKeyUp("e"));
        if (!canvas.gameObject.activeInHierarchy)
        {
            canvas.gameObject.SetActive(true);
            isOpen = true;
            TopDownEngineEvent.Trigger(TopDownEngineEventTypes.TogglePause, player.GetComponent<Character>());
            int count = 0;
            if (HelmetInventory.Content[0] != null)
            Display(HelmetInventory.Content[0], 0, HelmetInventory);
            else DisplayVazio(0);
            if(ChestInventory.Content[0] != null)
            Display(ChestInventory.Content[0], 1, ChestInventory);
            else DisplayVazio(1);
            if (BootsInventory.Content[0] != null)
            Display(BootsInventory.Content[0], 2, BootsInventory);
            else DisplayVazio(2);
            if (WeaponInventory1.Content[0] != null)
            Display(WeaponInventory1.Content[0], 3, WeaponInventory1);
            else DisplayVazio(3);
            if (WeaponInventory2.Content[0] != null)
            Display(WeaponInventory2.Content[0], 4, WeaponInventory2);
            else DisplayVazio(4);
        }
    }

  

    void Display(InventoryItem item, int local, Inventory inventory)
    {
        int custo = 0;

        if (item.dropDown == InventoryItem.Rarity.C) custo = 100;
        else if (item.dropDown == InventoryItem.Rarity.U) custo = 200;
        else if (item.dropDown == InventoryItem.Rarity.R) custo = 300;
        else if (item.dropDown == InventoryItem.Rarity.E) custo = 400;
        else if (item.dropDown == InventoryItem.Rarity.L) custo = 500;

        buttons[local].GetComponentInChildren<Text>().text = $"3x {item.ItemID} + {custo} -> {item.NextRarity.ItemID}";
        if (player.GetComponent<CharacterInventory>().Money >= custo) buttons[local].onClick.AddListener(delegate { RerollItem(inventory, item); });
        buttons[local].gameObject.SetActive(true);
    }

    void DisplayVazio(int local)
    {
        buttons[local].GetComponentInChildren<Text>().text = "Sem Item Equipado";
        buttons[local].gameObject.SetActive(true);
    }

    void RerollItem(Inventory inventory,InventoryItem oldItem)
    {
        oldItem.UnEquip("Player1");
       // oldItem.

    }
}
