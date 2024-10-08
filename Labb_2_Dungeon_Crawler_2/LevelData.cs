public class LevelData
{
	private List<LevelElement> _elements;

    public List<LevelElement> Elements
	{
		get { return _elements; }
	}

	// Constructor för att initalisera level element listan
	public LevelData()
	{
		_elements = new List<LevelElement>();
	}


	public void Load(string fileName)
	{
		// Skapa filväg för att lokalisera levelfilen
        string filePath = Path.Combine("Levels", fileName);

		try
		{
			// Använd Streamreader för att läsa innehåll i levelfilen
			using (StreamReader reader = new StreamReader(filePath))
			{
				int character;
				int positionX = 0; // Håller reda på horisontell position i leveln
				int positionY = 0; // Håller reda på vertikal position i leveln

				// Läs iconer från filen tills slutet
				while((character = reader.Read()) != -1)
				{
					char c = (char)character; // Casta integer icons to char type

					LevelElement element = null; // Variabel som håller level elementet som skapas

					// Bestäm vilken typ av level element som ska skapas baserat på läsning av icon
					switch (c)
					{
						case '#':
                            element = new Wall(positionX, positionY); // Skapa wall element
							break;
						case 'r':
							element = new Rat(positionX, positionY); // Skapa rat element
							break;
						case 's':
							element = new Snake(positionX, positionY); // Skapa snake element
							break;
						case '@':
							element = new Player(positionX, positionY); // Skapa player element
							break;
						default:
							element = null; // Ignorera oigenkännbara characters
							break;
                    }

					// Lägg till element till listan om det är giltligt 
					if (element != null)
					{
						_elements.Add(element);
					}

					// Öka x positionen till nästa character
					positionX++;

					// Om en ny rad charachter stöts på, återställ x position och öka y position
					if (c == '\n')
					{
						positionY++;
						positionX = 0; // Återställ till start på ny rad
					}
                }
			}
		}
		catch (IOException e)
		{
            // Hantera potentiella fil I/O errors
            Console.WriteLine("An error occured while loading the level");
            Console.WriteLine(e.Message);
        }

    }
}