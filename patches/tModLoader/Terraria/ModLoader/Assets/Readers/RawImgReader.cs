using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Content.Readers;
using Terraria.ModLoader.IO;

namespace Terraria.ModLoader.Assets
{
	public class RawImgReader : IAssetReader
	{
		private readonly GraphicsDevice _graphicsDevice;

		public RawImgReader(GraphicsDevice graphicsDevice) {
			_graphicsDevice = graphicsDevice;
		}

		public async ValueTask<T> FromStream<T>(Stream stream, MainThreadCreationContext mainThreadCtx) where T : class {
			if (typeof(T) != typeof(Texture2D))
				throw AssetLoadException.FromInvalidReader<RawImgReader, T>();

			Tuple<int, int, byte[]> rawData;
			using (var r = new BinaryReader(stream))
				rawData = ImageIO.ReadRaw(r);

			await mainThreadCtx;

			Debug.Assert(mainThreadCtx.IsCompleted);
			var tex = new Texture2D(_graphicsDevice, rawData.Item1, rawData.Item2);
			tex.SetData(rawData.Item3);
			return tex as T;
		}
	}
}
