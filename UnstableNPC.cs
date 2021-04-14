using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using AdditionalBuffs.Buffs;

namespace AdditionalBuffs
{
    public class UnstableNPC : GlobalNPC
    {
        public bool Unstable = false;
        public bool RenewUnstable = false;
        public override bool InstancePerEntity => true;

        public override bool CheckDead(NPC npc)
        {
            if (Unstable)
            {
                ModContent.GetInstance<Unstable>().UnstableExplosion(npc, 0.2f);
            }
            return base.CheckDead(npc);
        }
    }
}