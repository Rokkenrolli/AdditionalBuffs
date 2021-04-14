using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AdditionalBuffs.Buffs;

namespace AdditionalBuffs.Projectiles
{
    internal class UnstableExplosion : ModProjectile
    {
        private int explosionRadius = 10;

        public override void SetDefaults()
        {
            // while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
            projectile.width = explosionRadius;
            projectile.height = explosionRadius;
            projectile.friendly = true;
            projectile.penetrate = -1;

            // 5 second fuse.
            projectile.timeLeft = 5;

            // These 2 help the projectile hitbox be centered on the projectile sprite.
            drawOffsetX = 5;
            drawOriginOffsetY = 5;
        }

        public override void AI()
        {
            if (projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;
                //projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                //projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 250;
                projectile.height = 250;
                projectile.Center = projectile.position;
                //projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                //projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.knockBack = 2f;
            }
            else
            {
                // Smoke and fuse dust spawn.
                if (Main.rand.NextBool())
                {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                    Main.dust[dustIndex].position = projectile.Center + new Vector2(0f, (float)(-(float)projectile.height / 2)).RotatedBy((double)projectile.rotation, default(Vector2)) * 1.1f;
                    dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                    Main.dust[dustIndex].position = projectile.Center + new Vector2(0f, (float)(-(float)projectile.height / 2 - 6)).RotatedBy((double)projectile.rotation, default(Vector2)) * 1.1f;
                }
            }
            return;
        }

        public override void Kill(int timeLeft)
        {
            // Play explosion sound
            Main.PlaySound(SoundID.Item15, projectile.position);
            // Smoke Dust spawn
            for (int i = 0; i < 50; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }
            // Fire Dust spawn
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 3f;
            }
        }
    }
}