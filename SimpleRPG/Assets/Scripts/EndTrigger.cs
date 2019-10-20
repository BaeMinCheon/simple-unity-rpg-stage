using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndTrigger : MonoBehaviour
{
    public UnityEvent m_TriggerEvent;

    private void OnCollisionEnter2D(Collision2D Collider)
    {
        if(Collider.gameObject.tag.Equals("Player"))
        {
            this.m_TriggerEvent.Invoke();
        }
    }
}
