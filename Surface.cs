using System;

namespace raytracer {
	static class Surfaces {
		/**
		 * A series of surfaces that are used throughout the codebase.
         * @var <Surface> ReflectiveRed
		 */
		public static readonly Surface ReflectiveRed = new Surface() {
			color 		= new Color(1, 0, 0),
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
