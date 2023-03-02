# (Ревоция!)
def third_task():
    print("Third task")
    value = "Революция!"
    print()
    print(value)
    s1 = value[:4]
    i = len(value) - 4
    s2 = value[i:]
    res = s1 + s2
    print(res)
    if res == "Ревоция!":
        print("Success")
    print()


# Вывести на экран комплексную переменную z в виде: "z = [Re][Im]i" при [Im] 0 и "z = [Re]" при
# [Im] = 0. Здесь [Re]и [Im]действительная и мнимая часть числа, соответственно. Использовать
# только одну строку для форматирования.
def fourth_task():
    print("Fourth task")
    print("Действительная часть: ")
    first = input()
    print("Мнимая часть: ")
    second = input()
    fu = {'Re': first, 'Im': second}
    if int('{Im}'.format(**fu)) == 0:
        print(f"z = {fu['Re']}")
    else:
        print('z = {Re}*{Im}i'.format(**fu))

    print()


def main():
    fourth_task()


if __name__ == '__main__':
    fourth_task()
