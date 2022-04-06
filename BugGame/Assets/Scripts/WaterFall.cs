using UnityEngine;
using System.Collections;

public class WaterFall : MonoBehaviour
{
    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;

    void Update()
    {
        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;
        GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (OffsetX, OffsetY);
    }
}
