using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Favonite_Development.Core
{
    public class Map
    {   [XmlElement("Layer")]
        public List<Layer> layer;
        public Vector2 tileDimentions;

        public Map()
        {
            layer = new List<Layer>();
            tileDimentions = Vector2.Zero;
        }
        public void LoadContent()
        {
            foreach(Layer l in layer)
                l.LoadContent(tileDimentions);
            

        }

        public void UnloadContent() {
            foreach (Layer l in layer)
                l.UnloadContent();
                
                    
        }

        public void Update(GameTime gameTime) {
            foreach (Layer l in layer)
                l.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (Layer l in layer)
                l.Draw(spriteBatch);
        }
    }
}
