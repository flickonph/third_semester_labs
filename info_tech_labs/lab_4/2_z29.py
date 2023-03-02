# 29. Запросить у пользователя непустой набор целых чисел А. Собрать все числа от 1 до 1000,
# делящиеся без остатка…
# a. хотя бы на одно из чисел в А в список В.
# b. на 2 и более из чисел в А в список С.
# c. на все числа из А в список D.


def ask_for_num():
    numbers = []
    while True:
        ch = input()
        if ch == "q":
            return numbers
        else:
            numbers.append(int(ch))


def all_num():
    numbers = []
    for i in range(1, 1001):
        numbers.append(i)
    return numbers


def check_a(ask_nums, all_nums):
    list_b = []
    for i in range(1000):
        for j in range(len(ask_nums)):
            if all_nums[i] % ask_nums[j] == 0:
                list_b.append(all_nums[i])
    return list_b


def check_b(ask_nums, all_nums):
    list_c = []
    for i in range(1000):
        for j in range(len(ask_nums)):
            if all_nums[i] % ask_nums[j] == 0:
                for k in range(j + 1, len(ask_nums)):
                    if all_nums[i] % ask_nums[k] == 0:
                        list_c.append(all_nums[i])
    return list_c


def check_c(ask_nums, all_nums):
    list_d = []
    for i in range(1000):
        check_num = 0
        for j in range(len(ask_nums)):
            check_num += all_nums[i] % ask_nums[j]

        if check_num == 0:
            list_d.append(all_nums[i])
    return list_d


def main():
    ask_nums = ask_for_num()
    all_nums = all_num()
    print(check_a(ask_nums, all_nums))
    print(check_b(ask_nums, all_nums))
    print(check_c(ask_nums, all_nums))


if __name__ == "__main__":
    main()
