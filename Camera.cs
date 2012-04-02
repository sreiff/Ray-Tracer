class Camera {
	public Vector position;
	public Vector up;
	public Vector direction;
	public Vector right;

	public static Camera New(Vector pos, Vector dir) {
		Camera c = new Camera();
		c.position 	= pos;
		c.direction 	= Vector.Norm(Vector.Minus(dir, pos));
		c.right		= Vector.Times(1.5, Vector.Norm(Vector.Cross(direction, new Vector(0, -1, 0))));
		c.up		= Vector.Times(1.5, Vector.Norm(Vector.Cross(direction, c.right)));

		return c;
	}
}
