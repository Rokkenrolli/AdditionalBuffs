
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AdditionalBuffs.Buffs;

namespace AdditionalBuffs.Items.Weapons
{
	public class BloodVision : ModItem
	{

		public override string Texture => "Terraria/Item_" + ItemID.SpellTome;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Vision");
			Tooltip.SetDefault("Gain spelunky wiht a cost.");
		}

		public override void SetDefaults()
		{
			item.magic = true;
			item.mana = 1;
			item.width = 26;
			item.height = 26;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.value = Item.sellPrice(silver: 50);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item9;
		}


        public override void OnConsumeMana(Player player, int manaConsumed)
        {
			int bufftime = 300;
			Doom buff = (Doom)mod.GetBuff("Doom");
			buff.AddDoom(player, bufftime, 1);
			if (!player.HasBuff(BuffID.Spelunker))
            {
				player.AddBuff(BuffID.Spelunker, bufftime);
            }
			

		}


    }
}