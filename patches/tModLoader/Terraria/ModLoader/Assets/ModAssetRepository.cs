using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ReLogic.Content;
using ReLogic.Content.Sources;

namespace Terraria.ModLoader.Assets
{
	//This could really use optimizations, perhaps through busting open the ReLogic dll and making _assets & _sources protected instead of private.
	//TODO: Add ReLogic dll patching, and make Request<T> and SetSources virtual?
	public class ModAssetRepository : AssetRepository
	{
		public ModAssetRepository(AssetReaderCollection readers, IEnumerable<IContentSource> sources = null) : base(readers, sources) {}

	}
}
