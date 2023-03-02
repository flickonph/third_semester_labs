# Даны две строки: "I am 2nd year student. I am a future software developer. I will graduate university in
# 2024" и "I think programmers make a huge work in IT industry. I think this is an interesting direction.
# Programmers help us to reach a new level". Проверить состоят ли вторые половины строк из символов
# в верхнем регистре; из неотображаемых символов; начинаются ли слова в строке с заглавной буквы.

def check(option, current_str):
    to_add = "undef"

    if option == 0:  # is upper case
        current_div_str = current_str[len(current_str) // 2
                                      if len(current_str) % 2 == 0
                                      else ((len(current_str) // 2) + 1):]
        res = current_div_str.isupper()

        if res:
            to_add = "+"
        else:
            to_add = "-"
    elif option == 1:  # has invisible chars
        res = current_str.isprintable()

        if res:
            to_add = "+"
        else:
            to_add = "-"
    elif option == 2:  # has titled words
        res = current_str.istitle()

        if res:
            to_add = "+"
        else:
            to_add = "-"

    return to_add


def second_task():
    print("Second task")
    print()
    first_str = "I am 2nd year student. I am a future software developer. I will graduate university in 2024"
    second_str = "I think programmers make a huge work in IT industry. I think this is an interesting direction. " \
                 "Programmers help us to reach a new level "
    print(first_str)
    print(second_str)
    print()
    print("First string is in upper case: " + check(0, first_str))
    print("Second string is in upper case: " + check(0, second_str))
    print()
    print("First string contains invisible chars: " + check(1, first_str))
    print("Second string contains invisible chars: " + check(1, second_str))
    print()
    print("First string consists of all titled words: " + check(2, first_str))
    print("Second string consists of all titled words: " + check(2, second_str))
    print()


def main():
    second_task()


if __name__ == '__main__':
    second_task()
