using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRadarObject : MonoBehaviour {

    public Image image;

    void Start()
    {
        Radar.RegisterRadarObject(this.gameObject, image);
    }

    public void OnDestroy()
    {
        Radar.RemoveRadarObject(this.gameObject);
    }
}
