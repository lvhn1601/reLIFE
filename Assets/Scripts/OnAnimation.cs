using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    public UnityEvent OnAttack;
    // Start is called before the first frame update
  
    public void EventAttack()
    {
        OnAttack?.Invoke();
    }
}
