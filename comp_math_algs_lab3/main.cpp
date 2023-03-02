#include <iostream>

using namespace std;

double Lagrange(double xy[3][2], double x)
{
    double res = xy[0][1] *
                 (((x - xy[1][0]) * (x - xy[2][0]))
                  / ((xy[0][0] - xy[1][0]) * (xy[0][0] - xy[2][0])))
                 + xy[1][1] *
                   (((x - xy[0][0]) * (x - xy[2][0]))
                    / ((xy[1][0] - xy[0][0]) * (xy[1][0] - xy[2][0])))
                 + xy[2][1] *
                   (((x - xy[0][0]) * (x - xy[1][0]))
                    / ((xy[2][0] - xy[0][0]) * (xy[2][0] - xy[1][0])));
    return res;
}

double Newton(double xy[4][2], double x)
{
    double diff[3][3];

    diff[0][0] = (xy[1][1] - xy[0][1]) / (xy[1][0] - xy[0][0]);
    diff[1][0] = (xy[2][1] - xy[1][1]) / (xy[2][0] - xy[1][0]);
    diff[2][0] = (xy[3][1] - xy[2][1]) / (xy[3][0] - xy[2][0]);

    diff[0][1] = (diff[1][0] - diff[0][0]) / (xy[2][0] - xy[0][0]);
    diff[1][1] = (diff[2][0] - diff[1][0]) / (xy[3][0] - xy[1][0]);

    diff[0][2] = (diff[1][1] - diff[0][1]) / (xy[3][0] - xy[0][0]);

    double res =
            xy[0][1] + diff[0][0] * (x - xy[0][0])
            + diff[0][1] * (x - xy[0][0]) * (x - xy[1][0])
            + diff[0][2] * (x - xy[0][0]) * (x - xy[1][0]) * (x - xy[2][0]);
    return res;
}

int main(){
    double x = 0;

    double xyLagr [3][2] =
            {
            { -3.10, 9.99 },
            { -0.70, 7.55 },
            { 1.70, 12.06 },
            };
    double xyNewt [4][2] =
            {
            { -3.10, 9.99 },
            { -1.90, 8.20 },
            { -0.30, 7.73 },
            { 2.10, 13.78 },
            };

    cout << ("\nLagrange");
    x = -2.70;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    x = -2.30;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    x = -1.90;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    x = -1.50;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    x = -1.10;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    x = -0.30;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    x = 0.10;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    x = 0.50;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    x = 0.90;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    x = 1.30;
    cout << ("\n");
    cout << (Lagrange(xyLagr, x));
    cout << ("\nNewton");
    x = -2.7;
    cout << ("\n");
    cout << (Newton(xyNewt, x));
    x = -2.3;
    cout << ("\n");
    cout << (Newton(xyNewt, x));
    x = -1.5;
    cout << ("\n");
    cout << (Newton(xyNewt, x));
    x = -1.1;
    cout << ("\n");
    cout << (Newton(xyNewt, x));
    x = -0.7;
    cout << ("\n");
    cout << (Newton(xyNewt, x));
    x = 0.1;
    cout << ("\n");
    cout << (Newton(xyNewt, x));
    x = 0.5;
    cout << ("\n");
    cout << (Newton(xyNewt, x));
    x = 0.9;
    cout << ("\n");
    cout << (Newton(xyNewt, x));
    x = 1.3;
    cout << ("\n");
    cout << (Newton(xyNewt, x));
    x = 1.7;
    cout << ("\n");
    cout << (Newton(xyNewt, x));

    return 0;
}
