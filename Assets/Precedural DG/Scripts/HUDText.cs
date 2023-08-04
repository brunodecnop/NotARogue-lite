using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.TopDownEngine;
using TMPro;

public class HUDText : MonoBehaviour
{
    public TMP_Text counterText;
    private int counter;
    private int counterf;
    private GameManager counterfAUX;
    private Health counterAUX;
    // Start is called before the first frame update
    void Start()
    {
        counterfAUX = GameObject.Find("GameManager").GetComponent<GameManager>();
        counterAUX = GameObject.Find("Koala").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        counterf = counterfAUX.Floor;
        counter = counterAUX.CurrentHealth;
        counterText.SetText("HP: " + counter.ToString() + "   Floor: " + counterf.ToString());
    }
}
