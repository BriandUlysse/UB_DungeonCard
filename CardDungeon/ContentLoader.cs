using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon
{
    public class ContentLoader
    {
        private static ContentManager contentManager;

        private static Dictionary<String, Texture2D> textures;
        private static Dictionary<String, SpriteFont> fonts;

        public static void init(ContentManager _contentManager)
        {
            contentManager = _contentManager;
            textures = new Dictionary<String, Texture2D>();
            fonts = new Dictionary<String, SpriteFont>();
        }

        public static Texture2D getTexture(String textureName)
        {
            Texture2D res;
            if (!textures.TryGetValue(textureName, out res))
            {
                res = contentManager.Load<Texture2D>("graphics/"+textureName);
                textures.Add(textureName, res);
            }
            
            return res;
        }

        public static SpriteFont getFont(String font)
        {
            SpriteFont res;
            if (!fonts.TryGetValue(font, out res))
            {
                res = contentManager.Load<SpriteFont>("font/" + font);
                fonts.Add(font, res);
            }

            return res;
        }
    }
}
