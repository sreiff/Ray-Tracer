namespace raytracer {
    class Camera {
        public Vector position;
        public Vector up;
        public Vector direction;
        public Vector right;
	
        /**
         * Constructor
         * @param <Vector> pos
         * @param <Vector> dir
         */
        public Camera(Vector pos, Vector dir) {
            position 	= pos;
            direction 	= Vector.Norm(Vector.Minus(dir, pos));
            right		= Vector.Times(1.5, Vector.Norm(Vector.Cross(direction, new Vector(0, -1, 0))));
            up		    = Vector.Times(1.5, Vector.Norm(Vector.Cross(direction, c.right)));
        }
    }
}
