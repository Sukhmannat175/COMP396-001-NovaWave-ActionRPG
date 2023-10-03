using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireballScriptableObject", menuName = "ScriptableObejcts/Skills/Fireball")]
public class FireballScriptableObject : ScriptableObject
{
    public int level;
    public enum Element
    {
        FIRE,
        ICE,
        ELECTRIC
    }

    public Element element;
    public float coolDown;
    public float duration;
    public float AOE;
    public int projectileSpeed;
}
