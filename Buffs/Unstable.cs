using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using AdditionalBuffs.Projectiles;

namespace AdditionalBuffs.Buffs
{
    internal class Unstable : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Unsable");
            Description.SetDefault("Explosion on death");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public void UnstableExplosion(Player player, float fraction)
        {
            int damage = (int)(player.statLifeMax2 * fraction);
            Projectile projectile = Projectile.NewProjectileDirect(player.Center, Vector2.Zero, ModContent.ProjectileType<InstantExplosion>(), damage, 1, player.whoAmI);
        }

        public void UnstableExplosion(NPC npc, float fraction)
        {
            int damage = (int)(npc.lifeMax * fraction);
            Projectile projectile = Projectile.NewProjectileDirect(npc.Center, Vector2.Zero, ModContent.ProjectileType<InstantExplosion>(), damage, 1, npc.whoAmI);
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            UnstableNPC gNPC = npc.GetGlobalNPC<UnstableNPC>();
            gNPC.Unstable = true;
            if (npc.buffTime[buffIndex] <= 0)
            {
                ReApply(npc, 3600, buffIndex);
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MPlayer>().Unstable = true;
        }
    }
}