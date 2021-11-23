using System;
using UnityEngine;

public abstract class Spell
{
    // Object to initialize
    public abstract GameObject SpellObject { get; set; }

    // Spell variables
    public abstract float ManaCost { get; set; }
    public abstract float Damage { get; set; }
    public abstract float Range { get; set; }
    public abstract float AreaOfEffect { get; set; }

    // Methods
    public abstract void CastSpell(Vector3 position, GameObject target);
    public abstract void ChargeSpell();
}