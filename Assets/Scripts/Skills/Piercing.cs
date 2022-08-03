using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piercing : MonoBehaviour, ISkill
{
    public void LearnSkill()
    {
        Player.Instance.HasPiercing = true;
    }
}

public class PiercingSkill :  ISkill
{
    public void LearnSkill()
    {
        Player.Instance.HasPiercing = true;
    }
}
