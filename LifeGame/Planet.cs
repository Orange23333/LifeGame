using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
	public class Planet
	{
		public int Width { get; private set; }
		public int Height { get; private set; }

		public float[,] Earth { get; private set; }

		public List<ILifeRule> Rules { get; } = new List<ILifeRule>();

		public void SetPixel(int x, int y, float value)
		{
			Earth[x, y] = value;
		}

		public void Fill(float value)
		{
			int x, y;
			for(x = 0; x < Width; x++)
			{
				for(y=0;y< Height; y++)
				{
					Earth[x, y] = value;
				}
			}
		}

		public void Iterate()
		{
			int x, y;

			float[,] newEarth = new float[Width, Height];

			for (y = 0; y < Height; y++)
			{
				for (x = 0; x < Width; x++)
				{
					foreach (var rule in Rules)
					{
						newEarth[x,y] = rule.Iterate(Earth, x, y);
					}
				}
			}

			Earth=newEarth;
		}

		public Planet(int width, int height)
		{
			this.Width = width;
			this.Height = height;
			this.Earth = new float[Width, Height];
			Fill(0.0F);
		}
	}
}
