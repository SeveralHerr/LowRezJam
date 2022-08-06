using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffZigZagSkill : Skill
{
    public override string ShortName => "+Puff+";

    public override void LearnSkill()
    {
        Player.Instance.GetComponent<PuffballSpawner>().HasZigZag = true;
    }
}
