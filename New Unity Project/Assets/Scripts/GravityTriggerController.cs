using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTriggerController : MonoBehaviour
{
    [SerializeField] bool downWards;
    public const string compatibleGameObjectName = "Player";
    public const string compatibleGameObjectTag = "Players";

    [SerializeField] LayerMask compatibleLayers;

    //amikor beert az o colliderebe egy masik collider, akkor 
    //valamilyen muveletet vegzunk a colliderrel, vagy az ahhoz tartozo komponensekkel
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.layer + " " + (compatibleLayers.value(1 << compatibleLayers)));
        #region comments
        //tobb modszerrel detektalhatjuk a beerkezo objektumot
        //modszer1:
        //string osszehasonlitas, koltseges muvelet
        /*
        if (collision.gameObject.name == compatibleGameObjectName)
        {
            //TODO: valamit csinalunk vele
        }
        //modszer2:
        //ugyanugy string osszehasonlitas :(
        if (collision.gameObject.tag == compatibleGameObjectTag)
        {

        }
        */
        #endregion
        //if (compatibleLayers.value == (compatibleLayers.value == (collision.gameObject.layer | (1 << compatibleLayers.value))
        if(collision.gameObject.name == compatibleGameObjectName)
        {


            Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rigidbody2D == null) { return; }

            downWards = !downWards;

            //ha downwards igaz, 1-et ad vissza a gravityScale-nek, kulonben -1-et
            rigidbody2D.gravityScale = downWards ? 1 : -1;
        }
    }
}
