using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;

namespace GridGenerator
{
    internal class Program
    {
        #region Methods

        private static void ReadAndProcessValue(out int val)
        {
            string s = Console.ReadLine();
            if (!int.TryParse(s,out val))
            {
                Console.WriteLine("Invalid Value!");
                Main(null);
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Square Height (px): ");
            ReadAndProcessValue(out int sh);

            Console.WriteLine("Square Width (px): ");
            ReadAndProcessValue(out int sw);

            Console.WriteLine("Squares High: ");
            ReadAndProcessValue(out int shc);

            Console.WriteLine("Squares Wide: ");
            ReadAndProcessValue(out int swc);

            Console.WriteLine("Edge Thickness (px): ");
            ReadAndProcessValue(out int sthick);

            Console.WriteLine("Creating Image, please wait....");

            Image<Rgba32> image = new Image<Rgba32>((swc * sw) + (sthick / 2), (shc * sh) + (sthick / 2));
            for (int x = 0, y = 0; y < sh;)
            {
                Rectangle r = new Rectangle(x * sw, y * sh, sw, sh);
                image.Mutate(x => x.Draw(Color.Black, sthick, r));

                x++;
                if (x == sw)
                {
                    x = 0;
                    y++;
                }
            }

            Console.WriteLine("Desired File Name: ");
            string fname = Console.ReadLine();
            image.SaveAsPng($"./{fname}.png");

            Console.WriteLine("Saved Your Grid Image!");
            Console.ReadLine();
        }

        #endregion Methods
    }
}