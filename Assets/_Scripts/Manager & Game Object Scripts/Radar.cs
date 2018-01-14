using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarObject 
{
    // keeps track of image icon
    public Image icon { get; set;  }

    // keeps track of game object owner
    public GameObject owner { get; set;  }
}

public class Radar : MonoBehaviour {

    public Transform playerPosition;
    float mapScale = 3.0f;

    public static List<RadarObject> radObjects = new List<RadarObject>();


    public static void RegisterRadarObject(GameObject o, Image i)
    {
        // instantiate image
        Image image = Instantiate(i, i.transform.parent);

        //MyApples.transform.parent = gameItems.transform;

        // adds radar object into array
        radObjects.Add(new RadarObject() { owner = o, icon = image });
    }

    public static void RemoveRadarObject(GameObject o)
    {
        List<RadarObject> newList = new List<RadarObject>();

        for (int i = 0; i < radObjects.Count; i++)
        {
            // looks for the owner
            if(radObjects[i].owner == o)
            {
                // when found it gets destroyed
                Destroy(radObjects[i].icon);
                continue;
            }else {
                newList.Add(radObjects[i]);
            }
        }

        // removes objects from list 
        radObjects.RemoveRange(0, radObjects.Count);

        // adds them into new list
        radObjects.AddRange(newList);
    }

    void DrawRadarDots() 
    {
        // loops through radar object list
        foreach(RadarObject ro in radObjects)
        {
            // gets owners position and gets difference between players position
            Vector3 radarPos = (ro.owner.transform.position - playerPosition.position);

            float distanceToObject = Vector3.Distance(playerPosition.position, ro.owner.transform.position) * mapScale;
            if(distanceToObject > 100f) {

                distanceToObject = 100f;
            }

            // calculates the angle
            float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - playerPosition.eulerAngles.y;

            // calculates the position on a circle of the radar object (polar equations) 
            radarPos.x = distanceToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
            radarPos.z = distanceToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);

            // make icon child of the panel
            ro.icon.transform.SetParent(this.transform);

            // set position based on radar position 
            ro.icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0) + this.transform.position;

        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DrawRadarDots();
	}
}
