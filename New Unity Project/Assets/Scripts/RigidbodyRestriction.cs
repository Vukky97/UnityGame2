using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyRestriction : MonoBehaviour
{
    Rigidbody2D rgbdy;
    [SerializeField] Vector2 maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //az ilyet mindig probaljuk a startba tenni (vagy olyanba, ami egyszer fut le)
        rgbdy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //fixedupdate a fizikai szimulaciokhoz
    void FixedUpdate()
    {
        if (rgbdy == null) { Debug.LogWarning("nincs behuzva a rigidbodyrestriction komponensbe a rigidbody"); return; }

        if (rgbdy.velocity.x > maxVelocity.x)
        {
            rgbdy.velocity = new Vector2(maxVelocity.x, rgbdy.velocity.y);
        }
        if (rgbdy.velocity.x < -maxVelocity.x)
        {
            rgbdy.velocity = new Vector2(-maxVelocity.x, rgbdy.velocity.y);
        }

        if (rgbdy.velocity.y > maxVelocity.y)
        {
            rgbdy.velocity = new Vector2(rgbdy.velocity.x, maxVelocity.y);
        }
        if (rgbdy.velocity.y < -maxVelocity.y)
        {
            rgbdy.velocity = new Vector2(rgbdy.velocity.x, -maxVelocity.y);
        }
    }
}
