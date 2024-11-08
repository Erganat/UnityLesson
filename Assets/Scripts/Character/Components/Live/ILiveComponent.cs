using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ILiveComponent : ICharacterComponent
{

    public event Action<Character> OnCharacterDeath;

    public float  MaxHealth {  get; } 

    public float Health { get; }

    public void SetDamage(float damage);
    
}
