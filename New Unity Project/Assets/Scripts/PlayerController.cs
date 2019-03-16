using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// ez egy behuzott rigidbody2d komponens
    /// ami publikus, mas osztalyok szamara lathato
    /// a publikus = editorbol is lathato
    /// </summary>
    //public Rigidbody2D rgbdy;

    //megjobb megoldas, ha privat marad a privatnak szant mezo, de editor fele lathato lesz
    [SerializeField] Rigidbody2D rgbd = null;

    protected float _torqueSpeed = 50f;

    // a kek nevu metodusok beepitett metodusok
    //ezeket hivogatja a Unity
    //a scriptek metodusainak hivasi lancat megtalaljatok itt:
    //
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (rgbd == null) { Debug.LogWarning("nincs behuzva a player komponensbe a rigidbody"); return; }


        if (rgbd.gravityScale < 0)
        {
            _torqueSpeed = -50f;
        }
        else
        {
            _torqueSpeed = 50f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //we are goint to the left side
            //movement left:
            //rgbd.AddForce(Vector2.left, ForceMode2D.Impulse);

            //porgetes:
            rgbd.AddTorque(_torqueSpeed, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //movement right:
            //rgbd.AddForce(Vector2.right, ForceMode2D.Impulse);

            //porgetes:
            rgbd.AddTorque(-_torqueSpeed, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rgbd.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            rgbd.gravityScale *= -1;
        }
    }
}
