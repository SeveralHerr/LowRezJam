using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffPiercingSkill : Skill
{
    public override string ShortName => "Puff++";

    public override void LearnSkill()
    {
        Player.Instance.GetComponent<PuffballSpawner>().HasPuffPiercingSkill = true;
    }
}
