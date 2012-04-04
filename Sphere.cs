using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace raytracer
{
    class Sphere : SObject
    {
        public Vector Center;
        public double Radius;
        
        /**
         * Find the Intersect of the sphere and the given Ray.
         * @param <Ray> ray
         * @return <Intersect>
         */
        public override Intersect Intersect(Ray ray)
        {
            Vector eo = Vector.Minus(Center, ray.origin);
            double v = Vector.Dot(eo, ray.dir);
            double dist;
            if (v < 0)
            {
                dist = 0;
            }
            else
            {
                //Magnitude of eo ^2
                double eoMag2 = Vector.Dot(eo, eo);
                double disc = Math.Pow(Radius, 2) - (eoMag2 - Math.Pow(v, 2));
                if (disc < 0)
                {
                    dist = 0;
                }
                else
                {
                    dist = v - Math.Sqrt(disc);
                }
            }
            if (dist == 0)
            {
                return null;
            }
            return new Intersect() { obj = this, ray = ray, distance = dist };
        }

        /**
         * Find the normal vector of the sphere at the given position.
         * @param <Vector> pos
         * @return <Vector>
         */
        public override Vector Normal(Vector pos)
        {
            return Vector.Norm(Vector.Minus(pos, Center));
        }
    }
}