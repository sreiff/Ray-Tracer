using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace raytracer
{
    public class Color
    {
        public double R;
        public double G;
        public double B;

        /**
         * Constructor
         * @param <double> r
         * @param <double> g
         * @param <double> b
         */
        public Color(double r, double g, double b) { R = r; G = g; B = b; }

        /**
         * Multiply a color's RGB values by the input.
         * @param <double> n
         * @param <Color> v
         * @return <Color>
         */
        public static Color Times(double n, Color v)
        {
            return new Color(n * v.R, n * v.G, n * v.B);
        }

        /**
         * Multiply the RGB values of two colors.
         * @param <Color> v1
         * @param <Color> v2
         * @return <Color>
         */
        public static Color Times(Color v1, Color v2)
        {
            return new Color(v1.R * v2.R, v1.G * v2.G, v1.B * v2.B);
        }

        /**
         * Add the RGB values of two colors.
         * @param <Color> v1
         * @param <Color> v2
         * @return <Color>
         */
        public static Color Plus(Color v1, Color v2)
        {
            return new Color(v1.R + v2.R, v1.G + v2.G, v1.B + v2.B);
        }

        /**
         * Subtract the RGB values of two colors.
         * @param <Color> v1
         * @param <Color> v2
         * @return <Color>
         */
        public static Color Minus(Color v1, Color v2)
        {
            return new Color(v1.R - v2.R, v1.G - v2.G, v1.B - v2.B);
        }

        /**
         * Validate input values as proper RGB values.
         * @param <double> d
         * @return <double>
         */
        public double Legalize(double d)
        {
            return d > 1 ? 1 : d;
        }

        /**
         * Overwrite system drawing function to convert new syntax, spanning
         * from 0 to 1, to normal rgb values that span from 0 to 255.
         * 
         * Special thanks to "The Internet" for this addition.
         */
        internal System.Drawing.Color ToDrawingColor()
        {
            return System.Drawing.Color.FromArgb((int)(Legalize(R) * 255), (int)(Legalize(G) * 255), (int)(Legalize(B) * 255));
        }


        /**
         * Simplified constants representing colors used throughout the project.
         * @var <Color> Background
         * @var <Color> DefaultColor
         */
        public static readonly Color Background = new Color(0, 0, 0);
        public static readonly Color DefaultColor = new Color(0, 0, 0);
    }
}
