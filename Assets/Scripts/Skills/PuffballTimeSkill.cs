using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PuffballTimeSkill : Skill
{
    public override string ShortName => "Puff";
    private PuffballSkill PuffballSkill { get; set; }

    [Inject]
    private void Construct(PuffballSkill puffballSkill)
    {
        PuffballSkill = puffballSkill;
    }
    public override void LearnSkill()
    {
        PuffballSkill.TimeInterval /= 2;
    }
}
