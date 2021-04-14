using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using AdditionalBuffs.Buffs;

public class MPlayer : ModPlayer
{
    public int DoomStack = 0;
    public int BlessingStack = 0;
    public bool Unstable = false;
    public double baseDamageResistanceMult = 0.0; //equipable items should modify this
    public double addDamageResistanceMult = 0.0; //buffs and temporary items should modify this

    public void ResetDoom()
    {
        DoomStack = 0;
    }

    public void ResetBlessing()
    {
        BlessingStack = 0;
        addDamageResistanceMult = 0.0;
    }

    public override void OnRespawn(Player player)
    {
        DoomStack = 0;
        BlessingStack = 0;
        Unstable = false;
        addDamageResistanceMult = 0.0;
    }

    public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
    {
        damage = (int)(damage * (1 - baseDamageResistanceMult - addDamageResistanceMult));
        return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
    }

    public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
    {
        if (Unstable)
        {
            ModContent.GetInstance<Unstable>().UnstableExplosion(player, 0.1f);
        }
        base.Kill(damage, hitDirection, pvp, damageSource);
    }
}