using System;
using SpotifyAPI.Web;

namespace Infrastructure.Data
{
	public class SpotifyClientBuilder
	{
		private readonly SpotifyClientConfig _spotifyClientConfig;

		public SpotifyClientBuilder(SpotifyClientConfig spotifyClientConfig)
		{
			_spotifyClientConfig = spotifyClientConfig;
		}

        public SpotifyClient BuildClient()
        {
            return new SpotifyClient(_spotifyClientConfig);
        }
    }
}

