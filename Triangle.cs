namespace raytracer
{
    class Triangle : SObject
    {
        /**
         * Points must follow right hand rule for normal to work
         *      P1 -> P2 -> P3 must be counter clockwise
         * 
         * @var <Vector> Position1
         * @var <Vector> Position2
         * @var <Vector> Position3
         **/
        public Vector Position1;
        public Vector Position2;
        public Vector Position3;

        /**
         * Find the intersect of the given Ray and the triangle.
         * Based on Ray Tracing Lab
         *  
         * @param <Ray> iRay
         * @return <Intersect>
         */
        public override Intersect Intersect(Ray iRay)
        {
            double rayDistance = 0.0;
            //  t = d-n*P / d*n
            double t = Vector.Dot(Vector.Minus(iRay.dir, this.Normal()), iRay.origin) / Vector.Dot(iRay.dir,this.Normal());
            // Q = P + td
            Vector Q = Vector.Plus(iRay.origin, Vector.Scale(iRay.dir,t));


            Vector BA = Vector.Minus(Position2,Position1);
            Vector QA = Vector.Minus(Q,Position1);
            Vector CB = Vector.Minus(Position3,Position2);
            Vector QB = Vector.Minus(Q,Position2);
            Vector AC = Vector.Minus(Position1,Position3);
            Vector QC = Vector.Minus(Q,Position3);

            //[(B-A)X(Q-A)] dot n >=0
            //[(C-B)X(Q-B)] dot n >=0
            //[(A-C)X(Q-C)] dot n >=0
            if ((Vector.Dot(Vector.Cross(BA, QA),this.Normal()) < 0) ||
                (Vector.Dot(Vector.Cross(CB, QB), this.Normal()) < 0) ||
                (Vector.Dot(Vector.Cross(AC, QC), this.Normal()) < 0))
            {
                return null;
            }

            //Calc distance and return intersection
            rayDistance = Vector.Mag(Vector.Minus(Q,iRay.origin));
            return new Intersect() { obj=this, ray=iRay, distance=rayDistance };
        }

        /**
         * Calculate the normal vector of the triangle at the given position.
         * @param <Vector> pos
         * @return <Vector>
         */
        public override Vector Normal(Vector pos)
        {
            Vector edge1 = Vector.Minus(Position2,Position1);
            Vector edge2 = Vector.Minus(Position3 ,Position1);
            Vector normal = Vector.Norm(Vector.Cross(edge1, edge2));
            return normal;

        }

        /**
         * Helper function simplifying the call to the Normal() function.
         * @return <Vector>
         */
        public Vector Normal()
        {
            return this.Normal(null);
        }
    }
}
