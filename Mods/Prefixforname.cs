using TMPro;
using UnityEngine;
using Photon.Pun;

public static class NameTagUtils
{
    public static void MenuNameTags()
    {
        string mintName = $"[Mint] {PhotonNetwork.NickName}";



        GameObject outerTextObj = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/NameTagAnchor/NameTagCanvas/Text Outer");
        if (outerTextObj != null)
        {
            TextMeshPro outerTMP = outerTextObj.GetComponent<TextMeshPro>();
            if (outerTMP != null)
            {
                outerTMP.text = mintName;
            }
        }

        GameObject innerTextObj = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/NameTagAnchor/NameTagCanvas/Text Inner");
        if (innerTextObj != null)
        {
            TextMeshPro innerTMP = innerTextObj.GetComponent<TextMeshPro>();
            if (innerTMP != null)
            {
                innerTMP.text = mintName;
            }
        }
    }
}
