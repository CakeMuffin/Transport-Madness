using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Game Data/Dialogue")]
public class Dialogue : ScriptableObject
{
    public Sprite bossAvatar;
    [TextArea(3, 4)] public string bodyText;
    public bool inteactable;
}
