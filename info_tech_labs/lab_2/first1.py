def multi(first, second):
    return first * second


def first_task():
    print()
    print("First task")
    print("First number:")
    first = input()
    print("Second number:")
    second = input()

    multiplication_res = multi(float(first), float(second))

    print("Multiplication result is " + str(multiplication_res))
    res = multiplication_res.is_integer()

    if res:
        string_res = " is "
    else:
        string_res = " is not "

    print(str(multiplication_res) + string_res + "an integer\n")


def main():
    first_task()


if __name__ == '__main__':
    first_task()
