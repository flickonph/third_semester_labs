# 5. Найти синус минимального из трех произвольных чисел без использования функции min().


import math
import random


def init_numbers():
    numbers = [random.randint(-100, 100), random.randint(-100, 100), random.randint(-100, 100)]
    for i in range(3):
        print(f"{i+1} число: {numbers[i]}")

    return numbers


def match():
    for_check = init_numbers()
    if for_check[0] < for_check[1]:
        if for_check[0] < for_check[2]:
            print(f"Наименьшее число: {for_check[0]}")
            return for_check[0]
        else:
            print(f"Наименьшее число: {for_check[2]}")
            return for_check[2]
    else:
        if for_check[1] < for_check[2]:
            print(f"Наименьшее число: {for_check[1]}")
            return for_check[1]
        else:
            print(f"Наименьшее число: {for_check[2]}")
            return for_check[2]


def main():
    print(f"Синус наименьшего числа: {math.sin(float(match()))}")


if __name__ == "__main__":
    main()
