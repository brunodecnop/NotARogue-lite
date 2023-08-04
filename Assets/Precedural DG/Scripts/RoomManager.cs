using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;

public class RoomManager : MonoBehaviour
{
    
    public Sprite newSprite;
    public Sprite originalSprite;
    public RoomInstance roominstance;
    public static GameObject bossRoom;
    public bool SalaVisitada;
    public Loot lv1;
    public Loot lv2;
    public Loot lv3;
    public Loot lv4;
    public Loot lv5;
    public Loot lvBoss;

    void Awake() {
       roominstance = this.GetComponent<RoomInstance>();

       
    }

    void Start() {
        if (roominstance.type == 2) { bossRoom = gameObject;}
    }

    void OnTriggerEnter2D(Collider2D col) {
        

        if (!SalaVisitada) {
            if (roominstance.type == 0) {
                TrancarPortas();
                SpawnarMobs();
            }
            else if (roominstance.type == 2) {
                TrancarPortas();
                SpawnarBoss();
            }
        }
    }

    void TrancarPortas() {


        

        bool doorTop = roominstance.doorTop;
        bool doorBot = roominstance.doorBot;
        bool doorRight = roominstance.doorRight;
        bool doorLeft = roominstance.doorLeft;

        if (doorTop) {
            GameObject DoorU = this.transform.Find("DoorT(Clone)").gameObject;
            DoorU.GetComponent<Collider2D>().isTrigger = false;
            SpriteRenderer SRu = DoorU.GetComponent<SpriteRenderer>();
            SRu.sprite = newSprite;
        }

        if (doorBot) {
            GameObject DoorD = this.transform.Find("DoorB(Clone)").gameObject;
            DoorD.GetComponent<Collider2D>().isTrigger = false;
            SpriteRenderer SRd = DoorD.GetComponent<SpriteRenderer>();
            SRd.sprite = newSprite;
        }

        if (doorRight) {
            GameObject DoorR = this.transform.Find("DoorR(Clone)").gameObject;
            DoorR.GetComponent<Collider2D>().isTrigger = false;
            SpriteRenderer SRr = DoorR.GetComponent<SpriteRenderer>();
            SRr.sprite = newSprite;
        }

        if (doorLeft) {
            GameObject DoorL = this.transform.Find("DoorL(Clone)").gameObject;
            DoorL.GetComponent<Collider2D>().isTrigger = false;
            SpriteRenderer SRl = DoorL.GetComponent<SpriteRenderer>();
            SRl.sprite = newSprite;
        }
        SalaVisitada = true;
    }

    void SpawnarBoss() {
        lvBoss.SpawnLoot();
    }
    
    void SpawnarMobs() {
        int dif = 10 + Random.Range(1, 11);
        SpawnerRecursivo(dif);
        Debug.Log(dif);

    }

    void SpawnerRecursivo(int x) {
        int y = 5;
        if (x < 5) y = x;
        int sp = Random.Range(1, y + 1);
        if (sp == 1) lv1.SpawnLoot();
        else if (sp == 2) lv2.SpawnLoot();
        else if (sp == 3) lv3.SpawnLoot();
        else if (sp == 4) lv4.SpawnLoot();
        else if (sp == 5) lv5.SpawnLoot();
        x = x - sp;
        if (x > 0) SpawnerRecursivo(x);
    }

    public void DestrancarPortas() {


        

        bool doorTop = roominstance.doorTop;
        bool doorBot = roominstance.doorBot;
        bool doorRight = roominstance.doorRight;
        bool doorLeft = roominstance.doorLeft;

       

        if (doorTop) {
         
            GameObject DoorU = this.transform.Find("DoorT(Clone)").gameObject;
            DoorU.GetComponent<Collider2D>().isTrigger = true;
            SpriteRenderer SRu = DoorU.GetComponent<SpriteRenderer>();
            SRu.sprite = originalSprite;
        }

        if (doorBot) {
          
            GameObject DoorD = this.transform.Find("DoorB(Clone)").gameObject;
            DoorD.GetComponent<Collider2D>().isTrigger = true;
            SpriteRenderer SRd = DoorD.GetComponent<SpriteRenderer>();
            SRd.sprite = originalSprite;
        }

        if (doorRight) {
         
            GameObject DoorR = this.transform.Find("DoorR(Clone)").gameObject;
            DoorR.GetComponent<Collider2D>().isTrigger = true;
            SpriteRenderer SRr = DoorR.GetComponent<SpriteRenderer>();
            SRr.sprite = originalSprite;
        }

        if (doorLeft) {
         
            GameObject DoorL = this.transform.Find("DoorL(Clone)").gameObject;
            DoorL.GetComponent<Collider2D>().isTrigger = true;
            SpriteRenderer SRl = DoorL.GetComponent<SpriteRenderer>();
            SRl.sprite = originalSprite;
        }

    }
    
}
