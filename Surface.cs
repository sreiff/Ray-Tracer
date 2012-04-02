using System.Drawing;

namespace raytracer {
	static class Surfaces {
		/*
		 * This is a sample surface. We don't necessarily need to use it.
		 */
		public static readonly Surface ReflectiveRed = new Surface() {
			color 		= new Color(1, 0, 0);
			diffuse 	= pos => new Color(1, 1, 1),
			specular 	= pos => new Color(.5, .5, .5),
			reflect		= pos => .6,
			roughness	= 50
		};
	}

	class Surface {
		public Color color;
		public Func<Vector, Color> diffuse;
		public Func<Vector, Color> specular;
		public Func<Vector, double> reflect;
		public double roughness;
	}
}
