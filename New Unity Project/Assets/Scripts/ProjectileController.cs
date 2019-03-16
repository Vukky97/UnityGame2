using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;
    [SerializeField] Animator[] animators = new Animator[0];

    const string destroyAnimatorKey = "destroy";
    public string aliveanimatorKey = "alive";

    public Animator[] GetAnimators()
    {
        return animators;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (direction != null)
        {
            transform.position += direction;
        }       
    }

    void StartAnimation()
    {
        if (animators==null || animators.Length == 0) { Debug.LogWarning("no animator selected on ProjectileController"); return; }

        foreach(Animator animator in animators)
        {
            //animator.SetTrigger(destroyAnimatorKey);
            animator.SetBool(aliveanimatorKey, false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartAnimation();
        }
    }

    // mivel mostmar object poolingozunk ezert ezt kiszedem?
    //azert neveztem el animationevent vegzodessel, hogy tudjam, ezt az
    //animator controller fogja hivni
    //public void DestroyAnimationEvent()
    //{
    //    Destroy(gameObject);
    //}



}
