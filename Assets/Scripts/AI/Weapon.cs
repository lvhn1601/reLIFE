using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer character, weap;
    public Vector2 targetPos { get; set; }
    public Animator animator;
    public Transform circle;
    public float range;
    public int damage;
    // Update is called once per frame
    void Update()
    {
        Vector2 dir=(targetPos-(Vector2)transform.position).normalized;
        transform.right=dir;
        Vector2 scale=transform.localScale;
            if(dir.x < 0)
        {
            scale.y = -1;

        }else if(dir.x > 0)
        {
            scale.y=1;
        }
        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weap.sortingOrder = character.sortingOrder - 1;
        }
        else
        {
            weap.sortingOrder = character.sortingOrder + 1;
        }
        }
    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
    public void DetectCollider()
    {
        foreach (Collider2D coll in Physics2D.OverlapCircleAll(circle.position, range))
        {
            HitPoint hp;
            if (hp = coll.gameObject.GetComponent<HitPoint>())
            {
                hp.hurt(damage, transform.parent.gameObject);
            }

        }
    }
}

