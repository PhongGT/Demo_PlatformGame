using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    protected float Health;
    public float MaxHealth = 100;
    public float Speed = 5f;
    public float AttackDmg= 10;
    public float AttackSpeed=0.75f;
    public float ThrowDmg= 5f;
    public float ThrowSpeed= 2f;
    public float Jump = 100f; 

    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
