using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ID;
using AdditionalBuffs.Projectiles;

namespace AdditionalBuffs.Buffs
{
    internal class Unstable : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("DOOM");
            Description.SetDefault("DOOM");
            Main.debuff[Type] = true;
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
    }
}