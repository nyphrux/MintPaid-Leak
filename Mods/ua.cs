using GorillaNetworking;
using System;
using System.Collections.Generic;
using System.Text;

namespace AetherTemp.Mods
{
    internal class ua
    {
        public static void UnlockAll()
        {
            foreach (CosmeticsController.CosmeticItem cosmeticItem in CosmeticsController.instance.allCosmetics)
            {
                CosmeticsController.instance.ProcessExternalUnlock(cosmeticItem.itemName, false, false);
            }//old metho doesint workk now
            CosmeticsController.instance.UpdateMyCosmetics();
            CosmeticsController.instance.UpdateWardrobeModelsAndButtons();
            Action onCosmeticsUpdated = CosmeticsController.instance.OnCosmeticsUpdated;
            bool flag = onCosmeticsUpdated != null;
            bool flag2 = flag;
            if (flag2)
            {
                onCosmeticsUpdated.Invoke();
            }
        }

    }
}
