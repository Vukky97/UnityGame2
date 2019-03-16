using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AreaShower : MonoBehaviour
{
    //executeIneditmode attributumu scriptek editorban futnak, nem a jatekido alatt
    //a start minden scriptmodositasnal lefut
    //az update pedig minden szerkeszteskor lefut

    //csuszka megjelenitese editorban, 0-1 tartomannyal
    [Range(0, 1)]
    public float height;
    //ha az editorban meg nem adtam erteket, de ide irok erteket, akkor ez fog kikerulni
    //egyebkent az editorban levo ertek felulbiralja ezt az erteket
    public float heightMultiplier = 10;

    //editoros rajzolashoz van:
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //itt a 0 lokalis 0, nem vilagkoordinata-rendszerbeli 0
        //mit jelent ez? az objektumhoz kepest 0 eltolast
        Gizmos.DrawLine(transform.position - new Vector3(0, height * heightMultiplier), transform.position - new Vector3(0, height * -heightMultiplier));
    }
}
