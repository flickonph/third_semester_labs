# Создать вложенный список, заполненный случайными числами, преобразовав его в массив,
# определить наименьший элемент этого массива.

import random
import numpy as np


f = [random.sample(range(-100, 100), random.randint(2, 20))]
np_arr = np.array(f)
print(np_arr)
print(np_arr.min())
