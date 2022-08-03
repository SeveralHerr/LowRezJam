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

    public void Start()
    {
        boxText = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        skill.LearnSkill();
        Time.timeScale = 1;
        Destroy(ui);
    }
}
