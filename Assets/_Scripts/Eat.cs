using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour {

    public void EatFood()
    {
        int itemClickedOn = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text);

        if (itemClickedOn > 0)
        {
            int tcount = itemClickedOn - 1;
            this.transform.Find("Text").GetComponent<Text>().text = "" + tcount;
            FindObjectOfType<Slider>().value += 10;
            //healthSlider.value += 5;
        } else {
            Destroy(this.gameObject);
        }
    } 
}
