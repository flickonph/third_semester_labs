# Для произвольной строки из неповторяющихся латинских символов произвести следующие операции с использованием сетов:
# a. Подсчитать количество гласных и согласных букв.
# b. Подсчитать каких букв алфавита нет в этой строке.
# c. Удалить все гласные из строки и сформировать фиксированный сет из них.
# d. Преобразовать исходную строку в кортеж символов
from typing import List, Any

latin = {
    "a": 1,
    "b": 0,
    "c": 0,
    "d": 0,
    "e": 1,
    "f": 0,
    "g": 0,
    "h": 0,
    "i": 1,
    "j": 0,
    "k": 0,
    "l": 0,
    "m": 0,
    "n": 0,
    "o": 1,
    "p": 0,
    "q": 0,
    "r": 0,
    "s": 0,
    "t": 0,
    "u": 1,
    "v": 0,
    "w": 0,
    "x": 0,
    "y": 1,
    "z": 0,
}

# latStr = input()
latStr = "aaaavoavoayytytytttttta"
print(latStr)
latList = []
for letter in latStr:
    latList.append(letter)

tempLatList = []
for el in latList:
    tempLatList.append(el)
counter = 0
gls = 0
sogl = 0
reqLetters = []

for letter in latList:
    i = latin.get(letter)
    if i == 1:
        reqLetters.append(letter)
        tempLatList.remove(letter)
        gls = gls + 1
    if i == 0:
        sogl = sogl + 1

print(f"Гласных: {gls}")
print(f"Согласных: {sogl}")

latList = tempLatList
print(f"Нет в строке: {set(latin) - set(latList)}")

letterSet = set(reqLetters)
print("Гласные в строке: ", letterSet)
print("Изначальная строка: ", latStr)
latStr = ''.join(latList)
stringTuple = tuple(latStr)
print("Изменённая строка: ", stringTuple)