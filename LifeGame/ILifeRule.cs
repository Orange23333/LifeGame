using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
	public interface ILifeRule
	{
		float Iterate(float[,] earth, int x, int y);
	}
}
