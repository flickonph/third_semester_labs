import math


def func_1(a, b, y, x):
    f = (1 / b ** 2) * ((math.log(y / x)) + ((a * x) / y))
    return f


def func_2(a, x):
    f = -(x / a) * math.tan((a * x / 2)) + (2 / a ** 2) * math.log(math.sin((a * x) / 2))
    return f


def main():
    a = 4
    b = 2
    y = 3
    x = -math.pi
    while x <= 3 * math.pi:
        print(f"x: {x}")
        try:
            print(f"first func: {func_1(a, b, y, x)}")

        except:
            print("first func: math domain error")

        try:
            print(f"second func: {func_2(a, x)}")

        except:
            print("second func: math domain error")

        print("============================================")
        x += 0.05 * math.pi


if __name__ == "__main__":
    main()
