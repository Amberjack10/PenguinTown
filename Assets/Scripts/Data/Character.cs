using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Penguin,
    Dwarf
}

[Serializable]
public class Character
{
    public CharacterType CharacterType;
    public Sprite CharacterSprite;
    public RuntimeAnimatorController CharacterAnimatorController;
}
