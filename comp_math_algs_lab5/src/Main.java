// Номер варианта: 48
// Параметры функциональной зависимости: a0 = -4,44;  a1 = 0,55;  a2 = -3,10;  a3 = 1,07.
// Пределы локализации: Хлев = -6,7;  Xпр = 13,0.
// Тип экстремумов: максимумы;	Вариант метода: ЧФ
// e = 0,001

// R(x)= a0 + a1x + a2 * sin(a3x)

// 0,1, 0,01, 0,001, 0,0001

import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {

        ArrayList<Double[]> allDots = new ArrayList<>();
        for (double x = -6.7; x <= 13.0; x += 0.1 ){
            allDots.add(new Double[] {x, func(x)});
        }

        int length = allDots.size();
        ArrayList<Double[]> ab = new ArrayList<>();

        for (int i = 1; i < length - 1; i++){
            if (allDots.get(i - 1)[1] < allDots.get(i)[1] && allDots.get(i)[1] > allDots.get(i + 1)[1]){
                ab.add(new Double[]{allDots.get(i - 1)[0], allDots.get(i + 1)[0]});
            }
        }

        double[] e = new double[] {0.1, 0.01, 0.001, 0.0001};
        for (int eIndex = 0; eIndex < e.length; eIndex++){
            for (int i = 0; i < ab.size(); i++){
                var res = fib_numbers(ab.get(i)[0], ab.get(i)[1], e[eIndex]);
                System.out.println("Max: [" + res[0] + "; " + res[1] + "], E = " + e[eIndex]);
            }
        }
    }

    static double[] fib_numbers(double a, double b, double e){
        double x1, x2;
        double f1, f2;
        int n = 2;
        double limit = (b - a) / e;
        /*System.out.println("\n------------------------------\n");
        System.out.println("a | b = " + a + " | " + b);
        System.out.println("(b-a)/eps = " + limit);*/

        while (fib(n) <= limit){
            n += 1;
        }
        /*System.out.println("N = " + n + "\n");*/

        x1 = a + (fib(n - 2)*1.0) / (fib(n)) * (b - a);
        /*System.out.println("x1=" + x1);*/
        f1 = func(x1);
        /*System.out.println("f1=" + f1);*/
        x2 = a + (fib(n - 1)*1.0) / (fib(n)) * (b - a);
        /*System.out.println("x2=" + x2);*/
        f2 = func(x2);
        /*System.out.println("f2=" + f2);
        System.out.println("\n");*/

        for (int k = 1; k < (n - 2); k++){
            if (f1 < f2){
                a = x1;
                x1 = x2;
                /*System.out.println("x1=" + x1);*/
                f1 = f2;
                /*System.out.println("f1=" + f1);*/
                x2 = a + (fib(n - k - 1)*1.0) / fib(n - k) * (b - a);
                /*System.out.println("x2=" + x2);*/
                f2 = func(x2);
                /*System.out.println("f2=" + f2);*/
                /*System.out.println("\n");*/
            }
            else {
                b = x2;
                x2 = x1;
                /*System.out.println("x2=" + x2);*/
                f2 = f1;
                /*System.out.println("f2=" + f2);*/
                x1 = a + (fib(n - k - 2)*1.0) / fib(n - k) * (b - a);
                /*System.out.println("x1=" + x1);*/
                f1 = func(x1);
                /*System.out.println("f1=" + f1);
                System.out.println("\n");*/
            }
        }
        return new double[]{x1, f1};
    }

    // R(x)= a0 + a1x + a2 * sin(a3x)
    public static double func(double x){
        double[] ai = { -4.44, 0.55, -3.10, 1.07 };
        return ai[0] + ai[1]*x + ai[2]*Math.sin(ai[3]*x);
    }

    private static long fib(int n) {
        if (n <= 1) {
            return n;
        }
        return fib(n - 2) + fib(n - 1);
    }
}