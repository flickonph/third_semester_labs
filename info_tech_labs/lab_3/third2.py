# Есть пользователи, имеющие уникальные идентификаторы «a», «b»,… «d». a. Создать словарь, в котором для каждого
# пользователя имеются поля для логина, пароля, ФИО, e-mail и набора из 3-х телефонов. b. При помощи функции input()
# выводить информацию о выбранной пользователем записи. c. В случае отсутствия запрошенной записи выводить сообщение
# об ошибке.

# Немного оверинжиниринга
def check(user_id):
    if users.__contains__(user_id):
        return True
    else:
        return False


def error_msg(user_id):
    if not check(user_id):
        print(f"Пользователь с id [{user_id}] не найден")
        return False
    else:
        return True


def third_task(user_id):
    user_info = {
        "a": ["adfef afefgdtrg kbtld", "login_1", "pass123", "mail@mali.ru", "88005553535", "2281337", "123456789"],
        "b": ["qkljcnqc islevo ogrsv", "logoff", "qwerty", "gmail@gmail.com", "4567890654", "234567890", "2345678901"],
        "c": ["saeg jdtkragergju sawaf", "100Login", "12345678", "lghjkkkl@yahoo.com", "8756789", "978987654",
              "6787689"],
        "d": ["srhbdhumf waekfwef aboba", "aboba", "000admin", "pochta@chtoto.kto", "89898989898", "098767",
              "678767876"],
    }

    return user_info[user_id]


def to_string(arr):
    print("=================================")
    print("Данные пользователя по его id")
    print(f"ФИО: {arr[0]}")
    print(f"Логин: {arr[1]}")
    print(f"Пароль: {arr[2]}")
    print(f"Эл. почта: {arr[3]}")
    print(f"Личный номер: {arr[4]}")
    print(f"Рабочий номер: {arr[5]}")
    print(f"Факс: {arr[6]}")
    print("=================================")


users = ["a", "b", "c", "d"]
uid = input()
if error_msg(uid):
    to_string(third_task(uid))
