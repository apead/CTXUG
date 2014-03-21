//
//  Copyright 2012, Xamarin Inc.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//

namespace SocialMediaAndroid
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Threading.Tasks;

    public abstract class ImageDownloader
	{
		readonly IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication ();

		readonly ThrottledHttp http;

		readonly TimeSpan cacheDuration;

		public ImageDownloader (int maxConcurrentDownloads = 2)
			: this (TimeSpan.FromDays (1))
		{
			this.http = new ThrottledHttp (maxConcurrentDownloads);
		}

		public ImageDownloader (TimeSpan cacheDuration)
		{
			this.cacheDuration = cacheDuration;

			if (!this.store.DirectoryExists ("ImageCache")) {
				this.store.CreateDirectory ("ImageCache");
			}
		}

		public bool HasLocallyCachedCopy (Uri uri)
		{
			var now = DateTime.UtcNow;

			var filename = Uri.EscapeDataString (uri.AbsoluteUri);

			var lastWriteTime = this.GetLastWriteTimeUtc (filename);

			return lastWriteTime.HasValue &&
				(now - lastWriteTime.Value) < this.cacheDuration;
		}

		public Task<object> GetImageAsync (Uri uri)
		{
			return Task.Factory.StartNew (() => {
				return this.GetImage (uri);
			});
		}

		public object GetImage (Uri uri)
		{
			var filename = Uri.EscapeDataString (uri.AbsoluteUri);

			if (this.HasLocallyCachedCopy (uri)) {
				using (var o = this.OpenStorage (filename, FileMode.Open)) {
					return this.LoadImage (o);
				}
			}
			else {
				using (var d = this.http.Get (uri)) {
					using (var o = this.OpenStorage (filename, FileMode.Create)) {
						d.CopyTo (o);
					}
				}
				using (var o = this.OpenStorage (filename, FileMode.Open)) {
					return this.LoadImage (o);
				}
			}
		}

		protected virtual DateTime? GetLastWriteTimeUtc (string fileName)
		{
			var path = Path.Combine ("ImageCache", fileName);
			if (this.store.FileExists (path)) {
				return this.store.GetLastWriteTime (path).UtcDateTime;
			} else {
				return null;
			}
		}

		protected virtual Stream OpenStorage (string fileName, FileMode mode)
		{
			return this.store.OpenFile (Path.Combine ("ImageCache", fileName), mode);
		}

		protected abstract object LoadImage (Stream stream);
	}
}

