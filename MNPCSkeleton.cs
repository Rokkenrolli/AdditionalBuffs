using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using AdditionalBuffs.Buffs;

namespace AdditionalBuffs
{
    public class MNPCSkeleton : ModNPC
    {
        private bool Unstable = false;

        public override bool CheckDead()
        {
            if (Unstable)
            {
                ModContent.GetInstance<Unstable>().UnstableExplosion(npc, 0.1f);
            }
            return base.CheckDead();
        }
    }
}