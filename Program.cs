using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;

namespace GridGenerator
{
    internal class Program
    {
        private static int square_height = 50,
            square_width = 50,
            squares_high = 10,
            squares_wide = 10,
            edge_thickness = 5;

        private static string fileName = "grid";

        #region Methods

        private static void DisplaySettings()
        {
            Console.WriteLine(
                $"Change Settings\n"+
                $"1. Square Height     {square_height}px\n" +
                $"2. Square Width      {square_width}px\n" +
                $"3. Square's High     {squares_high}\n" +
                $"4. Square's Wide     {squares_wide}\n" +
                $"5. Edge Thickness    {edge_thickness}px\n" +
                $"6. File Name         {fileName}\n" +
                $"\nActions\n" +
                $"7. Save Grid to PNG");
        }

        private static void DrawAndStoreGrid()
        {
            Console.WriteLine("Creating Image, please wait....");

            Image<Rgba32> image = new Image<Rgba32>((squares_wide * square_width) + (edge_thickness / 2), (squares_high * square_height) + (edge_thickness / 2));
            for (int x = 0, y = 0; y < squares_high;)
            {
                Rectangle r = new Rectangle(x * square_width, y * square_height, square_width, square_height);
                image.Mutate(x => x.Draw(Color.Black, edge_thickness, r));

                x++;
                if (x == squares_wide)
                {
                    x = 0;
                    y++;
                }
            }

            image.SaveAsPng($"./{fileName}.png");
            Console.WriteLine($"Saved Your Grid Image To '{fileName}.png'");
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DisplaySettings();

                Console.WriteLine("\nSelect A Item (1-7): ");

                ReadAndProcessValue(out int selection);

                Console.WriteLine("Input Your Desired Value: ");

                switch (selection)
                {
                    case 1:
                        ReadAndProcessValue(out square_height);
                        break;

                    case 2:
                        ReadAndProcessValue(out square_width);
                        break;

                    case 3:
                        ReadAndProcessValue(out squares_high);
                        break;

                    case 4:
                        ReadAndProcessValue(out squares_wide);
                        break;

                    case 5:
                        ReadAndProcessValue(out edge_thickness);
                        break;

                    case 6:
                        fileName = Console.ReadLine();
                        break;

                    case 7:
                        Console.Clear();
                        DrawAndStoreGrid();
                        break;

                    default:
                        Console.WriteLine("Unkown Selection");
                        break;
                }
            }
        }

        private static void ReadAndProcessValue(out int val)
        {
            string s = Console.ReadLine();
            if (!int.TryParse(s, out val))
            {
                Console.Clear();
                Console.WriteLine($"'{s}' Is an Invalid Value!");
                Main(null);
            }
            Console.WriteLine();
        }

        #endregion Methods
    }
}