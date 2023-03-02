# Умножить все элементы произвольной матрицы на все её собственные числа поэлементно.
import numpy as np


def main():
    N = int(input())

    matrix = np.random.uniform(low=-5, high=5, size=(N,N))
    print(matrix)
    print("====================================================")

    eigh = np.linalg.eigh(matrix)[0]
    print(eigh)
    print("====================================================")
    new_matrix = matrix * eigh

    print(new_matrix)


if __name__ == "__main__":
    main()