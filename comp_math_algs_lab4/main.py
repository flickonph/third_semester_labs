# Номер варианта: 48
# Коэффициенты дифференциального уравнения: a0 = 0,202;  a1 = -0,965;  a2 = -0,926;  a3 = 0,179;  a4 = -0,021.
# Начальное условие: x0 = 1,6;  y0 = 1,0.
# Шаг интегрирования: dx = 0,05.
# Найти решение дифференциального уравнения в точке x = 2,1.
# Вариант метода 2 для п.4: ЭК
# Вариант метода для п.6: РК


def fx(xy):
    ai = [0.202, -0.965, -0.926, 0.179, -0.021, ]
    y = ai[0] + ai[1] * xy[0] + ai[2] * (xy[0] ** 2) + ai[3] * xy[1] + ai[4] * xy[0] * xy[1]
    return y


def RK(old_xy, new_xy, dx, x_res, debug):
    while new_xy[0] < x_res:
        new_xy[0] = old_xy[0] + dx
        temp_xy = [.0, .0]

        K1 = dx * fx(old_xy)

        temp_xy[0] = old_xy[0] + (dx / 2)
        temp_xy[1] = old_xy[1] + (K1 / 2)
        K2 = dx * fx(temp_xy)

        temp_xy[1] = old_xy[1] + (K2 / 2)
        K3 = dx * fx(temp_xy)

        temp_xy[0] = old_xy[0] + dx
        temp_xy[1] = old_xy[1] + K3
        K4 = dx * fx(temp_xy)

        new_xy[1] = old_xy[1] + (1 / 6) * (K1 + 2 * K2 + 2 * K3 + K4)
        if debug:
            print(f"{K1}\t{K2}\t{K3}\t{K4}")
        else:
            print(f"{new_xy[0]}\t{new_xy[1]}")

        old_xy[0] = new_xy[0]
        old_xy[1] = new_xy[1]

    return new_xy


def EK(old_xy, new_xy, dx, x_res, debug):
    while new_xy[0] < x_res:
        new_xy[0] = old_xy[0] + dx
        temp_xy = [.0, .0]

        K1 = dx * fx(old_xy)

        temp_xy[0] = old_xy[0] + dx
        temp_xy[1] = old_xy[1] + K1
        K2 = dx * fx(temp_xy)

        new_xy[1] = old_xy[1] + (1 / 2) * (K1 + K2)
        if debug:
            print(f"{K1}\t{K2}")
        else:
            print(f"{new_xy[0]}\t{new_xy[1]}")

        old_xy[0] = new_xy[0]
        old_xy[1] = new_xy[1]

    return new_xy


def RKdebug():
    x_res = 2.1
    dx = [0.1, 0.05, 0.025, 0.0125, ]
    for i in range(4):
        old_xy = [1.6, 1.0, ]
        new_xy = [1.6, 1.0, ]
        RK(old_xy, new_xy, dx[i], x_res, False)
        print("----------------------------------------")
        old_xy = [1.6, 1.0, ]
        new_xy = [1.6, 1.0, ]
        RK(old_xy, new_xy, dx[i], x_res, True)
        print("----------------------------------------")


def EKdebug():
    x_res = 2.1
    dx = [0.1, 0.05, 0.025, 0.0125, ]
    for i in range(4):
        old_xy = [1.6, 1.0, ]
        new_xy = [1.6, 1.0, ]
        EK(old_xy, new_xy, dx[i], x_res, False)
        print("----------------------------------------")
        old_xy = [1.6, 1.0, ]
        new_xy = [1.6, 1.0, ]
        EK(old_xy, new_xy, dx[i], x_res, True)
        print("----------------------------------------")


def main():
    RKdebug()
    EKdebug()
    # x_res = 2.1
    # old_xy = [1.6, 1.0, ]
    # new_xy = [1.6, 1.0, ]
    # dx = 0.005
    # print(RK(old_xy, new_xy, dx, x_res, False))


if __name__ == '__main__':
    main()
