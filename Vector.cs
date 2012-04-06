using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace raytracer
{
    class Vector
    {
        public double X;
        public double Y;
        public double Z;

        /**
         * Constructor
         * @param <double> x
         * @param <double> y
         * @param <double> z
         */
        public Vector(double x, double y, double z) { X = x; Y = y; Z = z; }

        /**
         * Subtract one vector from another.
         * @param <Vector> v1
         * @param <Vector> v2
         * @return <Vector>
         */
        public static Vector Minus(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        /**
         * Add two vectors together.
         * @param <Vector> v1
         * @param <Vector> v2
         * @return <Vector>
         */
        public static Vector Plus(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        /**
         * Find the dot-product of two vectors.
         * @param <Vector> v1
         * @param <Vector> v2
         * @return <double>
         */
        public static double Dot(Vector v1, Vector v2)
        {
            return (v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z);
        }

        /**
         * Find the magnitude of the given vector.
         * @param <Vector> v
         * @return <double>
         */
        public static double Mag(Vector v) { return Math.Sqrt(Dot(v, v)); }

        /**
         * Find the normalized version of the given vector.
         * @param <Vector> v
         * @return <Vector>
         */
        public static Vector Norm(Vector v)
        {
            double mag = Mag(v);
            double div = mag == 0 ? double.PositiveInfinity : 1 / mag;
            return Scale(v,div);
        }

        /**
         * Find the cross product of two vectors.
         * @param <Vector> v1
         * @param <Vector> v2
         * @return <Vector>
         */
        public static Vector Cross(Vector v1, Vector v2)
        {
            return new Vector(((v1.Y * v2.Z) - (v1.Z * v2.Y)), ((v1.Z * v2.X) - (v1.X * v2.Z)), ((v1.X * v2.Y) - (v1.Y * v2.X)));
        }

        /**
         * Scale a vector
         * @param <Vector> v
         * @param <double> x
         * @return <Vector>
         */
        public static Vector Scale(Vector v, double x)
        {
            return new Vector(v.X *x, v.Y*x,v.Z*x);
        }

        /**
         * Determine if two vectors are equivalent.
         * @param <Vector> v1
         * @param <Vector> v2
         * @return <bool>
         */
        public static bool Equals(Vector v1, Vector v2)
        {
            return (v1.X == v2.X) && (v1.Y == v2.Y) && (v1.Z == v2.Z);
        }
    }
}
