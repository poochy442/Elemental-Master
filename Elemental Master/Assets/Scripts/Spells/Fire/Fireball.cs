using System;
using UnityEngine;

public class Fireball : Spell
{
    public override GameObject SpellObject { get; set; }
    public override float ManaCost { get; set; }
    public override float Damage { get; set; }
    public override float Range { get; set; }
    public override float AreaOfEffect { get; set; }

    public override void CastSpell(Vector3 position, GameObject target)
    {
        throw new NotImplementedException();
    }

    public override void ChargeSpell()
    {
        // Check if already casting
        if (Player.isCasting)
            return;

        if (Player.CastSpell(ManaCost))
        {
            // Start animation
        } else
        {
            // Not enough mana
            Debug.Log("Not enough mana");
        }
    }
}