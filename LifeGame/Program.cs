namespace LifeGame
{
	internal class Program
	{
		static void PrintPlant(Planet plant)
		{
			int x, y;
			for (y = 0; y < plant.Height; y++)
			{
				for(x = 0; x < plant.Width; x++)
				{
					Console.Write(ConwayLifeRules.IsActive(plant.Earth[x, y]) ? "<>" : "  ");
				}
				Console.WriteLine();
			}
		}

		static void Main(string[] args)
		{
			Planet plant = new Planet(17, 17);
			plant.Rules.Add(new ConwayLifeRules.ConwayLifeRule());

			float[][] plantInit = new float[17][]
			{
				new float[17]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0 },
				new float[17]{ 0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 0 },
				new float[17]{ 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
				new float[17]{ 0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 0 },
				new float[17]{ 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				new float[17]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			};

			for(int y = 0; y < 17; y++)
			{
				for(int x=0; x < 17; x++)
				{
					plant.SetPixel(x, y, plantInit[y][x]);
				}
			}

			while (true)
			{
				Console.Clear();
				PrintPlant(plant);

				Thread.Sleep(200);
				//Console.ReadLine();

				plant.Iterate();
			}

			Console.ReadLine();
		}
	}
}