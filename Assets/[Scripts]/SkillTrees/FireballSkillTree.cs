using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* FIREBALL NODES INDEX
 * 0 - Base Fireball Level
 * 1 - Cast Time
 * 2 - Cooldown
 * 3 - Radius
 * 4 - Projectile Speed
 * 5 - Double Cast
 */

public class FireballSkillTree : MonoBehaviour
{
    public int fireballLvl;
    
    public List<Stats> fireballStats = new List<Stats>();
    public List<Nodes> fireballNodes = new List<Nodes>();

    private SkillSO fireballSO;

    private void Start()
    {
        LoadFireball();
        UpdateFireball();
    }

    public void LoadFireball()
    {
        fireballLvl = fireballNodes[0].nodeLvl;
        fireballSO = Resources.Load<SkillSO>("Skills/Fireball/Fireball" + fireballLvl.ToString());
        fireballStats = fireballSO.stats;
    }

    public void UpdateFireball()
    {
        for (int i = 0; i < fireballStats.Count; i++)
        {
            for (int j = 0; j < fireballNodes.Count; j++)
            {
                for (int k = 0; k < fireballNodes[j].nodeStat.Count; k++)
                {
                    if (fireballStats[i].stat == fireballNodes[j].nodeStat[k].stat)
                    {
                        float valueInc = fireballStats[i].value * (fireballNodes[j].nodeLvl * fireballNodes[j].nodeStat[k].value);
                        fireballStats[i].value += valueInc;
                    }
                }
            }
        }
    }

    public void UpgradeNode(Nodes node)
    {
        node.nodeLvl += 1;
        if (node == fireballNodes[0])
        {
            LoadFireball();
        }

        UpdateFireball();
    }

    public void DegradeNode(Nodes node)
    {
        node.nodeLvl -= 1;
        if (node == fireballNodes[0])
        {
            LoadFireball();
        }
        UpdateFireball();
    }
}
