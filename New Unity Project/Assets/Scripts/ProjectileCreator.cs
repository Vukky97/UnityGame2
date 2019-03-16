#pragma warning disable 649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCreator : MonoBehaviour
{
    //REFERENCES
    //a tervrajz, ebbol lesz legyartva a lovedek
    //649-es warning kodu warning uzenet elrejtese (A valtozo nincs assignolva, mert nem latja a VS a unity editoros assignt
    //vagy null ertekadassal, vagy pragma warningos sorral (lasd ennek a scriptnek a felso sorat)
    [SerializeField] GameObject projectilePrefab = null;
    [SerializeField] float timeFrequencyOfProjectile = 0.5f;
    [SerializeField] AreaShower areaShower;
    [SerializeField] Vector2 projectileDirectionNormalized = Vector2.left;
    [SerializeField] float speedOfProjectile = 0.1f;

    // a static objektumok nincsenek serializalva Unity-ben
    // ide gyujtjuk a nem lathato objektumokat es vesszuk elo oket amikor letrehoznank egy uj lovedeket
    public static List<GameObject> projectilePool = new List<GameObject>();

    //STATE
    float startTime;
    float currentTime;
    Vector3 positionOfNewProjectile;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time - startTime;
        if (currentTime > timeFrequencyOfProjectile)
        {
            //dobunk egy projectile-t
            positionOfNewProjectile = new Vector3(transform.position.x,
                Random.Range(transform.position.y - new Vector3(0, areaShower.height * areaShower.heightMultiplier).y,
                transform.position.y - new Vector3(0, areaShower.height * -areaShower.heightMultiplier).y), 0);

            //erdekesseg: ez a sor csak PC-s buildben fog lefutni, ezert szurke, mert editorban bele sincs forditva a jatekba
#if UNITY_STANDALONE_PC
            Debug.Log("projectile was created at " + Time.time + " seconds");
#endif

            //ez editor alatt lefordul, ezert a VS is jelzi a kulcsszavakat
#if UNITY_EDITOR
            Debug.Log("projectile was created at " + Time.time + " seconds");
#endif
            // az allando peldanyositas koltseges -> optimalizaljunk
            // mikor vegyunk ki a listabol elemet es mikor hozzuk letre

            if (projectilePool.Count == 0)
            {
                //ez peldanyosit egy gameobjectet a jatekterbe
                GameObject projectile = Instantiate(projectilePrefab, positionOfNewProjectile, Quaternion.identity);
                ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
                if (projectileController == null) { Debug.LogWarning("projectile prefab doesn't have ProjectileController script attached to it"); return; }

                projectileController.direction = new Vector2(speedOfProjectile, 0) * projectileDirectionNormalized;
            }
            else
            {
                projectilePool[0].transform.position = positionOfNewProjectile;
                projectilePool.RemoveAt(0);
            }

            startTime = Time.time;
        }
    }
}
