using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ha kiment a colliderbe akor a ool vissza tudja majd ot helyezni
        ProjectileCreator.projectilePool.Add(collision.gameObject);

        ProjectileController projectileController = collision.gameObject.GetComponent<ProjectileController>();
        Animator[] animators = projectileController.GetAnimators();

        foreach(Animator animator in animators)
        {
            animator.SetBool(projectileController.aliveanimatorKey, true);
        }
    }
}
