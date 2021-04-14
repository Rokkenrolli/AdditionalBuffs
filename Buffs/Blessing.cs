
using Terraria;
using Terraria.ModLoader;


namespace AdditionalBuffs.Buffs
{
    public class Blessing : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blessing");
            Description.SetDefault("Damage reduction and heal at the end");
            Main.debuff[Type] = false;
        }
        readonly int baseHeal = 30; 
        public void AddBlessing(Player player, int  bufftime, int stacksPerHit )
        {
            MPlayer p = player.GetModPlayer<MPlayer>();
            if (!player.HasBuff(Type))
            {
                player.AddBuff(Type, bufftime);
            }
            else
            {
                p.BlessingStack += stacksPerHit;
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MPlayer p = player.GetModPlayer<MPlayer>();
            int stacks = p.BlessingStack + 1;
            p.addDamageResistanceMult = stacks * 0.05;
            if (p.BlessingStack >= 4)
            {
                int amount = player.statLifeMax;
                
                player.HealEffect(amount);
                player.statLife += amount;
                player.ClearBuff(Type);
                p.ResetBlessing();
            }
            if (player.buffTime[buffIndex] <= 0)
            {
                
                int healAmount = baseHeal * stacks;
                player.HealEffect(healAmount);
                player.statLife += healAmount;
                
                p.ResetBlessing();
            }
        }
    }
}