using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class ROLE : BASE {
    public virtual void GetChip() { Debug.Log("コストを設定してあげてね"); }
    public virtual Hand role { get; }
    //画面の役を表示するテキスト
    public virtual string RoleText { get => role.ToString(); }
}

public class NULL_ROLL : ROLE
{

}
