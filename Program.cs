using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace GridGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Square Height: ");
            string str_sh = Console.ReadLine();
            int sh;
            if (!int.TryParse(str_sh, out sh))
            {
                Console.WriteLine("Inavlid Value");
                Main(args);
            }


            Console.WriteLine("Square Width: ");
            string str_sw = Console.ReadLine();
            int sw;
            if (!int.TryParse(str_sw, out sw))
            {
                Console.WriteLine("Inavlid Value");
                Main(args);
            }



            Console.WriteLine("Squares High: ");
            string str_shc = Console.ReadLine();
            int shc;
            if (!int.TryParse(str_shc, out shc))
            {
                Console.WriteLine("Inavlid Value");
                Main(args);
            }


            Console.WriteLine("Squares Wide: ");
            string str_swc = Console.ReadLine();
            int swc;
            if (!int.TryParse(str_swc, out swc))
            {
                Console.WriteLine("Inavlid Value");
                Main(args);
            }

            Console.WriteLine("Edge Thickness: ");
            string str_sthick = Console.ReadLine();
            int sthick;
            if (!int.TryParse(str_sthick, out sthick))
            {
                Console.WriteLine("Inavlid Value");
                Main(args);
            }

            Image<Rgba32> image = new Image<Rgba32>((swc * sw) + (sthick/2), (shc * sh) + (sthick/2));
            for (int x = 0, y = 0; y < sh;)
            {
                Rectangle r = new Rectangle(x*sw,y*sh,sw,sh);
                image.Mutate(x => x.Draw(Color.Black, sthick, r));

                x++;
                if (x == sw)
                {
                    x = 0;
                    y++;
                }
            }

            Console.WriteLine("File name: ");
            string fname = Console.ReadLine();
            image.SaveAsPng($"./{fname}.png");

            Console.WriteLine("Saved Grid Image");
        }
    }
}
