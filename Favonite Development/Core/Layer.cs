using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Favonite_Development.Core
{
    public class Layer
    {
        #region TileMapClass
        public class TileMap
        {
            [XmlElement("Row")]
            public List<string> Row;
            public TileMap()
            {
                Row = new List<string>();
            }

        }

        #endregion

        public TileMap Tile;
        private List<Tile> tiles;
        public Layer() { }

        public void LoadContent(Vector2 tileDimentions) { 
        
        foreach(string row in Tile.Row)
            {
                string[] split = row.Split(']');
                foreach (string s in split) { 
                    if(s != string.Empty)
                    {
                        string str = s.Replace("[", string.Empty);
                        int value1 = int.Parse(str.Substring(0,str.IndexOf(':')));
                        int value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                    }
                }

            }
                
        }

        public void UnloadContent() { }

        public void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch spriteBatch) { }
    }
}
