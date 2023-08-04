using MoreMountains.InventoryEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcUpgrader : MonoBehaviour
{
    public InventoryItem[] List;
    public Button[] buttons;
    public GameObject withItem;
    public GameObject NoItem;
    Inventory playerInventory;
    public int money;
    public GameObject player;
    public GameObject canvas;
    private bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        playerInventory = Inventory.FindInventory("MainInventory", "Player1");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(isOpen && Input.GetKeyDown("e")){
            CloseShop();
        }
    }

    void CloseShop()
    {
       if (canvas.gameObject.activeInHierarchy)
        {
                withItem.SetActive(true);
                NoItem.SetActive(false);
                foreach (Button button in buttons) {
                    if (button.gameObject.activeInHierarchy) { 
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
        if (!canvas.gameObject.activeInHierarchy) {
            canvas.gameObject.SetActive(true);
            isOpen = true;
            TopDownEngineEvent.Trigger(TopDownEngineEventTypes.TogglePause, player.GetComponent<Character>());
            int count = 0;
            foreach (InventoryItem item in List){
                 if (CheckPlayerInventory(item.ItemID, 3))
                {
                    Display(item, count);
                    count++;
                }
                if (count == 0) DisplayAlternativo();
            }
        }
    }

    bool CheckPlayerInventory(string ID, int amount)
    {
        if (playerInventory.GetQuantity(ID) < amount) return false;
        else return true;

    }

    void Display(InventoryItem item, int local)
    {
        int custo = 0;

        if (item.dropDown == InventoryItem.Rarity.C) custo = 100;
        else if (item.dropDown == InventoryItem.Rarity.U) custo = 200;
        else if (item.dropDown == InventoryItem.Rarity.R) custo = 300;
        else if (item.dropDown == InventoryItem.Rarity.E) custo = 400;

        buttons[local].GetComponentInChildren<Text>().text = $"3x {item.ItemID} + {custo} -> {item.NextRarity.ItemID}";
        if (player.GetComponent<CharacterInventory>().Money >= custo)buttons[local].onClick.AddListener(delegate { UpgradeItem(item); });
        buttons[local].gameObject.SetActive(true);
    }

    void DisplayAlternativo()
    {
        withItem.SetActive(false);
        NoItem.SetActive(true);
    }

    void UpgradeItem(InventoryItem oldItem)
    {
        playerInventory.RemoveItemByID(oldItem.ItemID, 3);
        playerInventory.AddItem(oldItem.NextRarity, 1);
    }
}
