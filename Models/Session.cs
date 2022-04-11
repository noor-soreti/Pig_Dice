using System;
using Newtonsoft.Json;

namespace Pig.Models
{
	public static class SessionExtensions
	{
		public static void SetObject<T>(this ISession session, string key, T value)
        {
			session.SetString(key, JsonConvert.SerializeObject(value));

        }

		public static T GetObject<T>(this ISession session, string key)
        {
			var JsonString = session.GetString(key);
            if (string.IsNullOrEmpty(JsonString))
            {
				return default(T); 
            } else
            {
				return JsonConvert.DeserializeObject<T>(JsonString);
            }
        }
	}

	public class GameSession
	{
        private const string GameKey = "pigGame";

        private ISession session;

        public GameSession(ISession sess) => session = sess;

        public Game GetGame() => session.GetObject<Game>(GameKey) ?? new Game();

        public void SetGame(Game game) => session.SetObject(GameKey, game); 

    }
}

