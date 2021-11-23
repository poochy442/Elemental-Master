using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float Health { get; set; }
    public static float Mana { get; set; }
    public static bool isCasting { get; set; }

    public static bool CastSpell(float Manacost)
    {
        if (Mana >= Manacost)
        {
            Mana -= Manacost;
            isCasting = true;
            return true;
        }
        else
            return false;
    }
}
