# Составить список из 5 элементов. Каждый элемент содержит три произвольных числа типа float от 0 до 9,
# 999 включительно. Произвести следующие операции над списком: a. добавить два новых элемента, содержащих по три
# произвольных числа типа int каждый, посчитать количество элементов списка и вывести результат в консоль. b.
# Отсортировать по убыванию и вставить на третью позицию (со сдвигом остальных элементов) в виде кортежа числа (1,3,
# 0) и вывести результат в консоль. c. Очистить исходный список.

import random

fullList = []
for x in range(5):
    currentList = []
    for i in range(3):
        currentList.append(random.uniform(0, 9.999))
    fullList.append(currentList)
print("--------------------------------------------------------------------")
for y in range(5):
    print(fullList[y])
print("--------------------------------------------------------------------")

for z in range(2):
    currentList = []
    for i in range(3):
        currentList.append(random.randint(-9, 9))
    fullList.append(currentList)

counter = len(fullList)
print("--------------------------------------------------------------------")
for k in range(counter):
    print(fullList[k])
print("--------------------------------------------------------------------")

a = (1, 3, 0)
b = list(a)
fullList.insert(2, sorted(b, reverse=True))

counter = len(fullList)

print("--------------------------------------------------------------------")
for k in range(counter):
    print(fullList[k])
print("--------------------------------------------------------------------")

fullList.clear()
print("\nCleared!")
