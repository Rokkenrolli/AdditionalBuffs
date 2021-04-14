using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AdditionalBuffs.Buffs;

namespace AdditionalBuffs.Items.Weapons
{
    class BlessedStone : ModItem
    {
		public override string Texture => "Terraria/Item_" + ItemID.LargeAmethyst;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blessed Stone");
			Tooltip.SetDefault("Gods smile upon you");
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
			item.rare = ItemRarityID.Pink;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.Tink, 2); 
		}
		public override void OnConsumeMana(Player player, int manaConsumed)
		{
			int bufftime = 300;
			Blessing buff = (Blessing)mod.GetBuff("Blessing");
			buff.AddBlessing(player, bufftime, 1);


		}


	}
}

