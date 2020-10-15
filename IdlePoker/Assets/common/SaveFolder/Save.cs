﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public string lastTime;
    public string birthDate;
    public bool isContinuePlay;
    public double allTime;

    public float SEVolume;
    public float BGMVolume;

    public long ascendPoint;
    public int MissionClearNum;
    /* libraryここまで */
    /* ここから永久に保存したい変数をpublicで宣言していく */
    /* 初期化はSave */

}