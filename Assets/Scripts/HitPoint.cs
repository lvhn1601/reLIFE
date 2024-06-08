using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitPoint : MonoBehaviour
{
    public int maxHP = 10;
    private int curHP;
    private bool ded;
    // Start is called before the first frame update
    public UnityEvent<GameObject> OnHit, Ded;
    void Start()
    {
        curHP=maxHP;
        ded=false;
    }

    // Update is called once per frame
    public void hurt(int amount, GameObject sender)
    {
        if (ded)
        {
            return;
        }
        if(sender.layer == gameObject.layer) {
            return;

        }
       
            curHP-=(int)amount;
       
        if(curHP<0) { 
            OnHit?.Invoke(sender);
        }
        else
        {
            Ded?.Invoke(sender);
            ded= true;
            Destroy(gameObject);
        }
    }
    
}
