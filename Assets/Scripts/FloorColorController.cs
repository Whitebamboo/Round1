using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destination;
    public Material floorMat;
    public float ratio;
    public float realRatio;
    public float originX;
    public float hueShift;
    void Start()
    {
        originX = this.transform.position.x;
        destination = GameObject.FindGameObjectWithTag("Destination");
        floorMat.SetFloat("_Hue", -0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        ratio = Mathf.Abs(transform.position.x - originX) / Mathf.Abs(destination.transform.position.x - originX);
        realRatio = hueShift * ratio;
        float newHue = -0.1f + realRatio;
        floorMat.SetFloat("_Hue", newHue);

    }
}
