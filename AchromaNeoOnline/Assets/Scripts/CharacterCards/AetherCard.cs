using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetherCard : CharacterCard
{
    public Sprite[] aether2Sprites = new Sprite[4];
    public char[] aether2Colors = new char[4];

    public override void LevelUp()
    {
        base.LevelUp();
        if (level == 3)
        {
            color = 'C';
        } else if (level == 2)
        {
            // Insert choose color phase
        }
    }

    public override void ActivateSkill()
    {
        base.ActivateSkill();
    }

    public void ChooseColor(int i)
    {
        characterImage.sprite = aether2Sprites[i];
        color = aether2Colors[i];
    }
}
