namespace raytracer
{

    class Triangle : SObject
    {

        public Vector Position1;

        public Vector Position2;

        public Vector Position3;


        //Found idea for this code here... http://create.msdn.com/en-US/education/catalog/sample/picking_triangle
        public override Intersect Intersect(Ray iRay)
        {
            // Compute vectors along two edges of the triangle.
            Vector edge1, edge2;

            edge1 = Vector.Minus(Position2, Position1);
            edge2 = Vector.Minus(Position3, Position1);

            // Compute the determinant.
            Vector directionCrossEdge2 = Vector.Cross(iRay.dir, edge2);

            float determinant = (float)Vector.Dot(edge1, directionCrossEdge2);

            // If the ray is parallel to the triangle plane, there is no collision.
            if (determinant > -float.Epsilon && determinant < float.Epsilon)
            {
               return null;
            }

            float inverseDeterminant = 1.0f / determinant;

            // Calculate the U parameter of the intersection point.
            Vector distanceVector = Vector.Minus(iRay.origin, Position1);

            float triangleU = (float)Vector.Dot(distanceVector, directionCrossEdge2);
            triangleU *= inverseDeterminant;

            // Make sure it is inside the triangle.
            if (triangleU < 0 || triangleU > 1)
            {
                return null;
            }

            // Calculate the V parameter of the intersection point.
            Vector distanceCrossEdge1 = Vector.Cross(distanceVector,edge1);

            float triangleV = (float)Vector.Dot(iRay.dir, distanceCrossEdge1);
            triangleV *= inverseDeterminant;

            // Make sure it is inside the triangle.
            if (triangleV < 0 || triangleU + triangleV > 1)
            {
                return null;
            }

            // Compute the distance along the ray to the triangle.
            float rayDistance = (float)Vector.Dot(edge2, distanceCrossEdge1);
            rayDistance *= inverseDeterminant;

            // Is the triangle at or behind the ray origin?
            if (rayDistance <= 0)
            {
               return null;
            }

            return new Intersect() { obj=this, ray=iRay, distance=rayDistance };
            

        }


        public override Vector Normal(Vector pos)
        {
            Vector edge1 = Vector.Minus(Position2,Position1);
            Vector edge2 = Vector.Minus(Position3 ,Position1);

            // Might be wrong found it here:http://stackoverflow.com/questions/2414762/calculating-the-perpendicular-plane-to-a-triangle-in-3d-space
            Vector normal = Vector.Norm(Vector.Cross(edge1, edge2));
            return normal;

        }

    }

}
