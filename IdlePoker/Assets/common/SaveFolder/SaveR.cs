﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class SaveR
{
    public string ascendTime;
    /* ここからアセンドでリセットする変数をpublicで宣言していく */
    /* NOTE : インスペクターに表示させたくない変数は[NonSerialized]をつける */
    /* NOTE : サイズの大きい配列は[NonSeriarized]をつける */
    public double chip;
}