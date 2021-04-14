using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ID;

namespace AdditionalBuffs.Buffs
{
    public class Doom : ModBuff
    {
        private readonly string[] buffTips = { "You feel weak", "Chill resonates through your body", "Don't look back", "RUN", "DOOOM" };

        public override void SetDefaults()
        {
            DisplayName.SetDefault("DOOM");
            Description.SetDefault("DOOM");
            Main.debuff[Type] = true;
        }

        private readonly int baseDamage = 10;
        private readonly int baseExecuteThreshold = 30;

        public void AddDoom(Player player, int bufftime, int stacksPerHit)
        {
            MPlayer p = player.GetModPlayer<MPlayer>();
            if (!player.HasBuff(Type))
            {
                player.AddBuff(Type, bufftime);
            }
            else
            {
                p.DoomStack += stacksPerHit;
            }
            /**
             * this for some reason does not work
            Color color = new Color(255, 0, 25);
            string message = buffTips[Math.Min(p.DoomStack, buffTips.Length - 1)];
            if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue(message), color);
            else NetMessage.BroadcastChatMessage(NetworkText.FromKey(message + "(" + player.name + ")"), color);
            */
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MPlayer p = player.GetModPlayer<MPlayer>();
            if (p.DoomStack >= 4)
            {
                player.Hurt(PlayerDeathReason.ByCustomReason("Max stacked DOOM"), 999999, 0);
                p.ResetDoom();
            }
            if (player.buffTime[buffIndex] <= 0)
            {
                int stacks = p.DoomStack + 1;
                int damage = player.statLife < baseExecuteThreshold * stacks ? 999999 : baseDamage * stacks;
                player.Hurt(PlayerDeathReason.ByCustomReason("DOOOMED (" + stacks.ToString() + ") stacks of DOOM"), damage, 0);
                p.ResetDoom();
            }
        }
    }
}