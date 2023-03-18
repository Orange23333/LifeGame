using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
	public static class ConwayLifeRules
	{
		public static readonly Point[] Neighbours =
		{
			new Point(-1, 1),
			new Point(0,1),
			new Point(1,1),
			new Point(1,0),
			new Point(1,-1),
			new Point(0,-1),
			new Point(-1,-1),
			new Point(-1,0),
		};

		public delegate void ViewNeighbour(float neighbour);

		public static void ViewEachNeighbour(float[,] earth, int x, int y, ViewNeighbour viewNeighbourMethod)
		{
			int width = earth.GetLength(0);
			int height = earth.GetLength(1);
			Rectangle earthRectangle = new Rectangle(0, 0, width, height);
			Point selfPoint= new Point(x, y);

            foreach (var neighbour in Neighbours)
            {
				Point realNeighbour = new Point(neighbour.X + selfPoint.X, neighbour.Y + selfPoint.Y);
				if (earthRectangle.Contains(realNeighbour)){
					viewNeighbourMethod.Invoke(earth[realNeighbour.X, realNeighbour.Y]);
				}
            }
        }

		public static int CountNeighbour(float[,] earth, int x, int y)
		{
			int count = 0;
			void _Count(float neighbour)
			{
				if(neighbour > 0.5)
				{
					count++;
				}
			}
			ViewEachNeighbour(earth, x, y, _Count);
			return count;
		}

		public static readonly float ActivationThreshold = 0.5F;
		public static readonly float ActiveValue = 1.0F;
		public static readonly float DeactivaValue = 0.0F;

		public static float Activate(float value)
		{
			return Activate(IsActive(value));
		}

		public static float Activate(bool active)
		{
			return active ? ActiveValue : DeactivaValue;
		}

		public static bool IsActive(float value)
		{
			return value >= ActivationThreshold;
		}

		public class ConwayLifeRule : ILifeRule
		{
			public float Iterate(float[,] earth, int x,int y)
			{
				int neighbourCount = CountNeighbour(earth, x, y);
				if (IsActive(earth[x, y])){
					return Activate(2 == neighbourCount || neighbourCount == 3);
				}
				else
				{
					return Activate(neighbourCount == 3);
				}
			}
		}
	}
}
