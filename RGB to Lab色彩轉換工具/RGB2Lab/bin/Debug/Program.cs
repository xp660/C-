using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCreateDLL
{
    unsafe public class ColorSpace
    {
        static void Main(string[] args)
        {

        }

        public void RGB2Lab(int R,int G,int B,double *L,double *a,double *b)
        {
            double X, Y, Z;
            RGB2XYZ(R, G, B, &X, &Y, &Z);
            XYZ2Lab(X, Y, Z, L, a, b);
        }

        public void RGB2XYZ(int R, int G, int B, double* X, double* Y, double* Z)
        {
            double r = degamma(R);
            double g = degamma(G);
            double b = degamma(B);
            *X = 0.436075 * r + 0.385065 * g + 0.14308 * b;
            *Y = 0.222505 * r + 0.716879 * g + 0.060617 * b;
            *Z = 0.013932 * r + 0.097105 * g + 0.714173 * b;
        }

        public void XYZ2Lab(double X, double Y, double Z, double* L, double* a, double* b)
        {
            double x0 = 0.96422, y0 = 1.00, z0 = 0.82521;  //chromatic adaptation : D50
            double Xx0, Yy0, Zz0;
            double x, y, z;
            Xx0 = X / x0; Yy0 = Y / y0; Zz0 = Z / z0;
            if (Xx0 > 0.008856)
                x = Math.Pow(Xx0, 0.333333);
            else
                x = 7.787 * Xx0 + 0.137931;

            if (Yy0 > 0.008856)
                y = Math.Pow(Yy0, 0.333333);
            else
                y = 7.787 * Yy0 + 0.137931;

            if (Zz0 > 0.008856)
                z = Math.Pow(Zz0, 0.333333);
            else
                z = 7.787 * Zz0 + 0.137931;

            *L = (116.0 * y) - 16.0;
            *a = 504.3 * (x - y);
            *b = 201.7 * (y - z);
        }

        public double degamma(int Rcolor)
        {
            double R = (double)Rcolor / 255.0;
            double r;
            if (R <= 0.04045)
                r = R / 12.92;
            else
                r = Math.Pow((R + 0.055) / 1.055, 2.4);
            return r;
        }

    }
}
