using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    protected int health;
    protected int coins;

    public virtual void Attack()
    {
        Debug.Log("Sunail....." + this.gameObject.name);
    }
}
