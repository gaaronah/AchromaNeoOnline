using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetherCard : CharacterCard
{
    public override void LevelUp()
    {
        if (color != 'C')
        {
            color = 'C';
        }
        base.LevelUp();
    }

    public override void ActivateSkill()
    {
        base.ActivateSkill();
    }
}
