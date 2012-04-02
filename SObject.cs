using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace raytracer
{
    abstract class SObject
    {
        public Surface Surface;
        public abstract Intersect Intersect(Ray ray);
        public abstract Vector Normal(Vector pos);
    }
}
