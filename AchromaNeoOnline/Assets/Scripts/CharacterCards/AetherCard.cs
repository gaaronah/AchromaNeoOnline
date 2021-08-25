using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetherCard : CharacterCard
{
    override public void LevelUp()
    {
        if (color != 'C')
        {
            color = 'C';
        }
        if (level < 3)
        {
            level++;
            LoadCard();
        }
    }
}
