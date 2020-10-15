using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class MissionInfo : BASE {

    int missionClearNum { get => main.S.MissionClearNum; set => main.S.MissionClearNum = value; }
    List<MISSION> missions = new List<MISSION>();
    MISSION currentMission;
    public TextMeshProUGUI MissionNameText,ProgressText,MissionClearNumText;
    public Slider ProgressSlider;
    public Button claimButton;
	// Use this for initialization
	void Awake () {
        claimButton.onClick.AddListener(() => Clear());
        missions.Add(new GoldGain(10000));
        missions.Add(new GoldGain(1000000));
        missions.Add(new GoldGain(100000000));
    }

	// Use this for initialization
	void Start () {
        if (missionClearNum >= missions.Count)
        {
            currentMission = new AllCleared();
        }
        else
        {
            currentMission = missions[missionClearNum];
        }
	}

    void Clear()    
    {
        missionClearNum += 1;
        if(missionClearNum > missions.Count)
        {
            //例外処理
        }
        else
        {
            currentMission = missions[missionClearNum];
        }
    }
	
	// Update is called once per frame
	void Update () {
        MissionClearNumText.text = missionClearNum + " / " + missions.Count; 
        currentMission.UpdateMission(MissionNameText,ProgressSlider,ProgressText);
        if (currentMission.MissionCondition())
        {
            claimButton.interactable = true;
        }
        else
        {
            claimButton.interactable = false;
        }
	}
}
