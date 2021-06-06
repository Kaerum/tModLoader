using System;
using System.IO;
using System.Linq;
using ReLogic.Content.Sources;
using Terraria.ModLoader.Core;

namespace Terraria.ModLoader.Assets
{
	public class TModContentSource : ContentSource
	{
		private readonly TmodFile file;

		public TModContentSource(TmodFile file) {
			this.file = file ?? throw new ArgumentNullException(nameof(file));
			SetAssetNames(file.Select(fileEntry => fileEntry.Name));
		}

		public override Stream OpenStream(string assetName) => file.GetStream(assetName, newFileStream: true); //todo, might be sloww
	}
}
