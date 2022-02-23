using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTheRacerGB : MonoBehaviour
{
    Vector3 kartPosition;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        kartPosition = GameObject.Find("Kart").transform.position;
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        kartPosition = GameObject.Find("Kart").transform.position;
        pos = this.transform.position;

        //get x and z
        float kX = kartPosition.x;
        float kY = kartPosition.z;
        float gX = pos.x;
        float gY = pos.z;

        //find hypotenuse
        float tX = kX;
        float tY = gY;

        float a = tX - gX;
        float o = tY - kY;

        float h = Mathf.Sqrt((a * a) + (o * o));

        float x = Mathf.Acos((a / h)) * Mathf.Rad2Deg;
        //Debug.Log(x);

        if (kY < gY)
        {
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 90 + x, this.transform.rotation.z);
        }
        else {
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 90 - x, this.transform.rotation.z);
        }
    }
}
