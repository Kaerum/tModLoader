using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ReLogic.Content
{
	public struct MainThreadCreationContext : INotifyCompletion
	{
		internal AssetRepository.ContinuationScheduler ContinuationScheduler { private get; init; }

		private Stream stream;

		public MainThreadCreationContext WithStream(Stream stream) {
			this.stream = stream;
			return this;
		}

		public MainThreadCreationContext GetAwaiter() => this;

		public void OnCompleted(Action action) {
			ContinuationScheduler.OnCompleted(action);
		}

		public bool IsCompleted => AssetRepository.IsMainThread;

		public Stream GetResult() => stream;
	}
}
