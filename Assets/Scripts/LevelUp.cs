using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class LevelUp : MonoBehaviour, IPointerClickHandler
{
    public GameObject ui;
    public TextMeshProUGUI boxText;
    public ISkill skill;
    public bool isMono = false;
    public string prefabSkill;


    public void Start()
    {
        boxText = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!string.IsNullOrEmpty(prefabSkill))
        {
            var obj = Resources.Load($"Prefabs/{prefabSkill}") as GameObject;
            var skill = obj.GetComponent<ISkill>();
            skill.LearnSkill();
        }
        else
        {
            skill.LearnSkill();
        }

        Time.timeScale = 1;
        Destroy(ui);
    }
}
