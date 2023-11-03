/* Created by: Han Bi
 * Used for displaying UI when user hovers over a interactive object
 * Singleton design pattern since there should only be one tooltip on screen at any given time
 */
using System.Collections.Generic;
using UnityEngine;

public class ToolTipController : MonoBehaviour
{
    public static ToolTipController Instance;

    [SerializeField]
    RectTransform skillTooltip;

    [SerializeField]
    RectTransform playerSkillTooltip;

    [SerializeField]
    RectTransform nodeTooltip;

    [SerializeField]
    RectTransform gearTooltip;

    private List<RectTransform> toolTips;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {

        toolTips = new List<RectTransform>
        {
            skillTooltip,
            playerSkillTooltip,
            nodeTooltip,
            gearTooltip
        };

        CloseTooltips();
    }

    public void ShowSkillToolTip(SkillTreeNode node)
    {
        CloseTooltips();
        skillTooltip.gameObject.SetActive(true);
        skillTooltip.GetComponent<SkillToolTip>().DisplayDetails(node);
    }


    public void CloseTooltips()
    {
        foreach(RectTransform t in toolTips) {            
            t.gameObject.SetActive(false);
        }
    }

    public void ShowPlayerSkillTooltip(SkillTreeNode node)
    {
        CloseTooltips();
        playerSkillTooltip.GetComponent<SkillToolTip>().DisplayDetails(node);
        playerSkillTooltip.gameObject.SetActive(true);
    }




}
